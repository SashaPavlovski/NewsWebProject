﻿using HtmlAgilityPack;
using NewsWebProject.Model.Tables;
using System.Data;
using System.Xml;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData.ModelProviders
{
    public class MPGlobes: BaseWebsData, IProvideData
    {
        public DataTable DataTable { get; set; }
        public Task QueueTask { get; set; }
        public bool StopLoop { get; set; } = false;
        public List<TBRSSWebs> WebsData { get; set; }
        public DateTime StartRead { get; set; }
        public MPGlobes(Logger logger, List<TBRSSWebs> globesData) : base(logger)
        {
            WebsData = globesData;

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

                    foreach (XmlNode node in xmlDocument.SelectNodes("//item"))
                    {
                        DataTable.Rows.Add(node["title"].InnerText, node["media:content"].Attributes["url"].Value,node["description"].InnerText,node["link"].InnerText,0, WebData, true, StartRead) ;

                        //לנסות לעשות אינדאקאר
                        //להוסיף תאריך
                    }
                }
            }
        }

    }
}
