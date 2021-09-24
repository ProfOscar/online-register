using System.Data.SqlClient;
using System.IO;

namespace OnlineRegisterClassLibrary
{
    public class DbTools
    {
        private string ConnectionString;

        public DbTools(string connStr)
        {
            ConnectionString = connStr;
        }

        public string ExecuteSqlScript(string sqlScriptPath)
        {
            string stOut = "";
            try
            {
                string scriptContent = File.ReadAllText(sqlScriptPath);
                using (SqlConnection dbConn = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand dbCmd = new SqlCommand(scriptContent, dbConn))
                    {
                        dbConn.Open();
                        dbCmd.ExecuteNonQuery();
                    }
                }
                stOut = "Sql Script SUCCESS!";
            }
            catch (SqlException sqlExc)
            {
                stOut = "Error in SQL query: " + sqlExc.Message;
            }
            catch (System.Exception exc)
            {
                stOut = "Generic error: " + exc.Message;
            }
            return stOut;
        }

        public string GetTableList(string tableName)
        {
            string stOut = "";
            using (SqlConnection dbConn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand dbCmd = new SqlCommand("SELECT * FROM " + tableName, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader dbReader = dbCmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            stOut += dbReader.GetString(1) + " - " + dbReader.GetString(2) + "\n";
                        }
                    }
                }
            }
            return stOut;
        }
    }
}
