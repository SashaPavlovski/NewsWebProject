using HtmlAgilityPack;
using NewsWebProject.Model.Tables;
using System.Data;
using System.Reflection.Emit;
using System.Xml;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData.ModelProviders
{
    public class MPWalla: BaseWebsData,IProvideData
    {
        public DataTable DataTable { get; set; }
        public Task QueueTask { get; set; }
        public bool StopLoop { get; set; } = false;
        public List<TBRSSWebs> WebsData { get; set; }
        public DateTime StartRead { get; set; } 

        object jj = new object();
        public MPWalla(Logger logger, List<TBRSSWebs> wallaData) : base(logger)
        {
            WebsData = wallaData;

            Init();
        }
        public void Init()
        {
            DataTable = this.CreateDataTableTable();

            QueueTask = Task.Run(() =>
            {
                while (!StopLoop)
                {
                    if (WebsData != null && WebsData.Count > 0)
                    {
                            GettingEachCategoryNews(WebsData);
                    }

                    //  DataTable.Clear();
                    //  Console.WriteLine( DataTable.ToString());

                    DataTable.Rows.Count.ToString();
                    Thread.Sleep(1000*60*3);
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

                        this.SubstringImageAndDescription(node["description"].InnerText, "<br/>", "</p>", out src, out description);

                        DataTable.Rows.Add(node["title"].InnerText, node["enclosure"].Attributes["url"].Value, description, node["link"].InnerText, 0, WebData, true, StartRead);
                        int xd = 1;

                        //לנסות לעשות אינדאקאר
                    }

                    DataTable.Rows.Count.ToString();

                }
            }
        }
    }
}