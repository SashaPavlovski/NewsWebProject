using HtmlAgilityPack;
using NewsWebProject.Model.Tables;
using System.Data;
using System.Xml;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData.ModelProviders
{
    public class MPYnet: BaseWebsData, IProvideData
    {
        public DataTable DataTable { get; set; }
        public Task QueueTask { get; set; }
        public bool StopLoop { get; set; } = false;
        public List<TBRSSWebs> WebsData { get; set; }
        public DateTime StartRead { get; set; } 
        public MPYnet(Logger logger, List<TBRSSWebs> ynetData) : base(logger)
        {
            WebsData = ynetData;

            Init();
        }
        public void Init()
        {
            QueueTask = Task.Run(() =>
            {
                DataTable = this.CreateDataTableTable();

                while (!StopLoop)
                {
                    if (WebsData!= null && WebsData.Count > 0)
                    {
                        GettingEachCategoryNews(WebsData);

                    }

                    //  DataTable.Clear();
                    DataTable.Rows.Count.ToString();
                    Thread.Sleep(1000 * 60 * 3);
                    int x = 1;
                }
            });
        }

        public async void GettingEachCategoryNews(List<TBRSSWebs> WebsData)
        {
            StartRead = DateTime.Now;

            foreach (TBRSSWebs WebData in WebsData)
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(WebData.RSSWebUrl);
                    response.EnsureSuccessStatusCode();
                    var contact = await response.Content.ReadAsStringAsync();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(contact);
                    Console.WriteLine(contact);
                    string hhh = xmlDocument.SelectNodes("//item").Count.ToString();

                    foreach (XmlNode node in xmlDocument.SelectNodes("//item"))
                    {
                        string src;
                        string description;

                        this.SubstringImageAndDescription(node["description"].InnerText, "</div>", null, out src, out description);

                        DataTable.Rows.Add(node["title"].InnerText, src, description, node["link"].InnerText, 0, WebData, true, StartRead);
                        //לנסות לעשות אינדאקאר
                    }
                    DataTable.Rows.Count.ToString();

                }
            }
        }
    }
}
