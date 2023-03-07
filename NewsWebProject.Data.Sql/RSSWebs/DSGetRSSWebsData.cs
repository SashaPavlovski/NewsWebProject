using Utilities.Logger;
using System.Data.SqlClient;
using NewsWebProject.Model.Tables;

namespace NewsWebProject.Data.Sql.RSSWebs
{
    public class DSGetRSSWebsData:BaseDataSql, IGetData
    {
        public DSGetRSSWebsData(Logger Logger) : base(Logger)
        {
            GetSql = new Dal.GetSqlData();
        }

        public Dal.GetSqlData GetSql;
        public object GetFromDataBase(params object[] argv)
        {
            //Logger.LogEvent("Enter into GetFromDataBase function");

            //Logger.LogEvent("Starting the data of the business company representative");


            List<TBRSSWebs> RSSWebs = new List<TBRSSWebs>();

            if (argv.Length > 0) 
            {
                try
                {
                    SqlDataReader reader = argv.OfType<SqlDataReader>().FirstOrDefault();

                    if (reader != null && reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            RSSWebs.Add(new TBRSSWebs
                            {
                                RSSWebName = reader["RSSWebName"].ToString(),
                                RSSWebID = int.Parse(reader["RSSWebID"].ToString()),
                                RSSWebUrl = reader["RSSWebUrl"].ToString(),
                                Category = new TBCategories
                                {
                                    CategoryID = int.Parse(reader["CategoryID"].ToString()),
                                    CategoryName = reader["CategoryName"].ToString()
                                }
                            });
                        }

                        // Logger.LogEvent("End AddBusinessCompanyInformation function and taking the data of business company representative");

                        return RSSWebs;
                    }
                }
                catch (SqlException Ex)
                {
                   // Logger.LogException(Ex.Message, Ex);

                    throw;
                }
                catch (Exception Ex)
                {
                   // Logger.LogException(Ex.Message, Ex);

                    throw;
                }

            }


            return null;

        }
        public void SetValues(SqlCommand command, params object[] argv)
        {
            return;
        }
        
        public string Insert { get; set; } = " select *,*\r\n from [dbo].[TBRSSWebs] TB1 inner join [dbo].[TBCategories] TB2\r\n on TB1.Category_CategoryID = TB2.CategoryID";
        public object GetData(object value)
        {
           // Logger.LogEvent("\n\nEnter into GetBusinessCompanyUserRow function");

            List<TBRSSWebs> WebsList = null;
            try
            {
                object listObjectWebs = GetSql.GetData(Insert, SetValues, GetFromDataBase);

                if (listObjectWebs is List<TBRSSWebs>)
                {
                    WebsList = (List<TBRSSWebs>)listObjectWebs;
                }
            }
            catch (Exception Ex)
            {
                //Logger.LogException(Ex.Message, Ex);

                throw;
            }

           // Logger.LogEvent("End GetBusinessCompanyUserRow function");

            return WebsList;

        }


    }
}
