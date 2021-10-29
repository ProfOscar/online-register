using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRegisterWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnStudent_Click(object sender, EventArgs e)
        {
            // OnlineRegisterClassLibrary.DbTools db;
            LblOutput.Text = GetTableList("Student");
        }

        public string GetTableList(string tableName)
        {
            const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data\onlineregister\register.mdf;Integrated Security=True;Connect Timeout=30";

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
                            for (int i = 0; i < dbReader.FieldCount; i++)
                            {
                                stOut += dbReader.GetValue(i) + " - ";
                            }
                            stOut = stOut.Remove(stOut.Length - 3) + "\n";
                        }
                    }
                }
            }
            return stOut;
        }

        protected void BtnTeacher_Click(object sender, EventArgs e)
        {
            LblOutput.Text = GetTableList("Teacher");
        }
    }
}