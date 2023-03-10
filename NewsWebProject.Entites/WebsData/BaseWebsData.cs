using HtmlAgilityPack;
using NewsWebProject.Dal;
using NewsWebProject.Model.Tables;
using System.Data;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData
{
    interface IProvideData
    {
        protected DataTable DataTable { get; set; }
        protected Task QueueTask { get; set; }
        protected bool StopLoop { get; set; }
        protected List<TBRSSWebs> WebsData { get; set; }
        protected DateTime StartRead { get; set; }
        public void Init();
        public void GettingEachCategoryNews(List<TBRSSWebs> WebsData);
    }
    public class BaseWebsData:BaseDal
    {
        public Logger Logger;

        public BaseWebsData(Logger logger)
        {
            Logger = logger;

            try
            {
                if (Logger != null)
                {
                    Logger.LogEvent("The Logger initialization operation was performed successfully");

                    Logger.LogEvent("In the BaseDataSql constructor");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable CreateDataTableTable()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("NewsItemTitle", typeof(string));
            dataTable.Columns.Add("NewsItemImage", typeof(string));
            dataTable.Columns.Add("NewsItemDescription", typeof(string));
            dataTable.Columns.Add("NewsItemUrl", typeof(string));
            dataTable.Columns.Add("NewsItemEntriesCount", typeof(int));
            dataTable.Columns.Add("RSSWeb_RSSWebID", typeof(TBRSSWebs));
            dataTable.Columns.Add("Active", typeof(bool));
            dataTable.Columns.Add("NewsItemDate", typeof(DateTime));

            return dataTable;
        }

        /// <summary>
        /// Separates the description tag,
        /// that a picture and description are received separately
        /// </summary>
        /// <param name="descriptionString">All description tag text</param>
        /// <param name="startChar">The char or string that we start the cutting operation of the description</param>
        /// <param name="endChar">The char or string that we end the cutting operation of the description,
        /// Or null if no unique ending </param>
        /// <param name="src">Img src</param>
        /// <param name="description">Only description</param>
        public void SubstringImageAndDescription(string descriptionString,string startChar, string endChar, out string src, out string description)
        {
            try
            {
                if (descriptionString != null && startChar != null)
                {
                    int startIndex;

                    int endIndex;

                    var htmlDoc = new HtmlDocument();

                    htmlDoc.LoadHtml(descriptionString);

                    var imgNode = htmlDoc.DocumentNode.SelectSingleNode($"//img");

                    src = imgNode.Attributes["src"].Value;

                    startIndex = descriptionString.IndexOf(startChar) + startChar.Length;

                    if (endChar != null)
                    {
                        endIndex = descriptionString.IndexOf(endChar, startIndex);
                    }
                    else
                    {
                        endIndex = descriptionString.Length;
                    }

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
            catch (Exception Ex)
            {

                throw;
            }

        }

    }
}
