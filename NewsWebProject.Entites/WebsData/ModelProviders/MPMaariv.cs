using HtmlAgilityPack;
using NewsWebProject.Model.Tables;
using System.Data;
using System.Xml;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData.ModelProviders
{
    public class MPMaariv: BaseWebsData, IProvideData
    {
        public DataTable DataTable { get; set; }
        public Task QueueTask { get; set; }
        public bool StopLoop { get; set; } = false;
        public List<TBRSSWebs> WebsData { get; set; }
        public MPMaariv(Logger logger, List<TBRSSWebs> maarivData) : base(logger)
        {
            WebsData = maarivData;

            Init();
        }
        public void Init()
        {
            QueueTask = Task.Run(() =>
            {
               // this.CreateDataTableTable(DataTable);

                while (!StopLoop)
                {

                    if (WebsData.Count > 0)
                    {
                        GettingEachCategoryNews(WebsData);

                    }

                    //  DataTable.Clear();

                    Thread.Sleep(100);
                }
            });
        }

        public void SubstringImageAndDescription(string descriptionString, out string src, out string description)
        {
            if (descriptionString != null)
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(descriptionString);

                var imgNode = htmlDoc.DocumentNode.SelectSingleNode($"//img");
                src = imgNode.Attributes["src"].Value;
                var descriptionNode = htmlDoc.DocumentNode.SelectSingleNode($"//img");
                description = descriptionNode.NextSibling.InnerText.Trim();

                Console.WriteLine(src);
                Console.WriteLine(description);
            }
            else
            {
                src = null;
                description = null;
            }

        }


        public async void GettingEachCategoryNews(List<TBRSSWebs> WebsData)
        {
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

                    foreach (XmlNode node in xmlDocument.SelectNodes("//item"))
                    {
                        string src;
                        string description;

                        this.SubstringImageAndDescription(node["description"].InnerText, out src, out description);

                        DataTable.Rows.Add(node["title"].InnerText, src, description, node["link"].InnerText, 0, WebData, true);
                        //לנסות לעשות אינדאקאר
                    }
                }
            }
        }
    }
}
