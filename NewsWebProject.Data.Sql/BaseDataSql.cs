using System.Data.SqlClient;
using Utilities.Logger;

namespace NewsWebProject.Data.Sql
{
    public class BaseDataSql
    {
        public Logger Logger;
        public BaseDataSql(Logger logger)
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
    }
    interface IGetData
    {
        public string Insert {  get; set; }
        public object GetFromDataBase(params object[] argv);
        public void SetValues(SqlCommand command, params object[] argv);
        public object GetData(object value);
    }
}
