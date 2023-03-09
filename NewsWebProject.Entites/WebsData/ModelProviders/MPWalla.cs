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

        object jj = new object();
        public MPWalla(Logger logger, List<TBRSSWebs> wallaData) : base(logger)
        {
            WebsData = wallaData;

            Init();
        }
        public void Init()
        {
            QueueTask = Task.Run(() =>
            {
                DataTable = this.CreateDataTableTable();

                while (!StopLoop)
                {
                    if (WebsData.Count > 0)
                    {
                        lock(jj)
                        {

                            GettingEachCategoryNews(WebsData);

                        }

                    }

                    //  DataTable.Clear();
                    //  Console.WriteLine( DataTable.ToString());

                    DataTable.Rows.Count.ToString();
                    Thread.Sleep(1000*60*60);
                    Console.ReadLine();
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

                int startIndex = descriptionString.IndexOf("<br/>") + "<br/>".Length;

                int endIndex = descriptionString.IndexOf("</p>", startIndex);

                description = descriptionString.Substring(startIndex, endIndex - startIndex);


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
                    string hhh = xmlDocument.SelectNodes("//item").Count.ToString();

                    foreach (XmlNode node in xmlDocument.SelectNodes("//item"))
                    {
                        string src;
                        string description;

                        this.SubstringImageAndDescription(node["description"].InnerText, out src, out description);

                        DataTable.Rows.Add(node["title"].InnerText, node["enclosure"].Attributes["url"].Value, description, node["link"].InnerText, 0, WebData, true);

                        //לנסות לעשות אינדאקאר
                    }

                    DataTable.Rows.Count.ToString();


                }
            }

        }
    }
}