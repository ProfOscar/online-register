using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineRegisterWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data\onlineregister\register.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string sql = "SELECT LastName FROM Student ORDER BY LastName";
                DropDownListStudenti.DataSource = GetDataForCombo(sql);
                DropDownListStudenti.DataBind();
            }
        }

        public DataTable GetDataTable(string tableName)
        {
            string query = "SELECT * FROM " + tableName;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            conn.Close();
            adapter.Dispose();
            return table;
        }

        public List<string> GetDataForCombo(string sqlQuery)
        {
            List<string> lstOut = new List<string>(); ;
            using (SqlConnection dbConn = new SqlConnection(connectionString))
            {
                using (SqlCommand dbCmd = new SqlCommand(sqlQuery, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader dbReader = dbCmd.ExecuteReader())
                    {
                        while (dbReader.Read())
                        {
                            lstOut.Add(dbReader.GetString(0));
                        }
                    }
                }
            }
            return lstOut;
        }

    }
}