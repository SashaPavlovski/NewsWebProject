using HtmlAgilityPack;
using NewsWebProject.Dal;
using NewsWebProject.Model.Tables;
using System.Data;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData
{
    interface IProvideData
    {
        public DataTable DataTable { get; set; }
        public Task QueueTask { get; set; }
        public bool StopLoop { get; set; }
        public List<TBRSSWebs> WebsData { get; set; }
        public void Init();
        public void GettingEachCategoryNews(List<TBRSSWebs> WebsData);
        public void SubstringImageAndDescription(string descriptionString, out string src, out string description);
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
            dataTable.Columns.Add("RSSWeb", typeof(TBRSSWebs));
            dataTable.Columns.Add("Active", typeof(bool));

            return dataTable;
        }


    }
}
