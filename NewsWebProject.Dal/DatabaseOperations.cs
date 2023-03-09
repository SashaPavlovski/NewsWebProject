using System.Data.SqlClient;

namespace NewsWebProject.Dal
{
    public class DatabaseOperations:BaseDal
    {
        public SqlConnection connection;

        public delegate void DelegateSetValus(SqlCommand command,params object[] argv);

        public delegate object DelegateReader(params object[] argv);

        public virtual void RunCommand (string SqlInsert, DelegateReader Func, params object[] argv)
        {
            try
            {
                if (!(Connect())) return;

                using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                {
                    Func(command, argv);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public virtual object GetData(string SqlInsert, DelegateSetValus setValues, DelegateReader Func, params object[] argv)
        {
            try
            {
                if (!(Connect())) return null;

                object DataList = null;

                using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                {
                    setValues(command, argv);


                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataList = Func(command, reader, argv);
                    }
                }

                return DataList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>   Connects with database. </summary>
        /// <returns>   True if it succeeds, false if it fails. </returns>
        private bool Connect()
        {
            try
            {
                connection = new SqlConnection(ConnectionString);

                connection.Open();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
