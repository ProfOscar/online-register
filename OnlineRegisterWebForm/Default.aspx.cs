using System;
using System.Web.UI;

namespace OnlineRegisterWebForm
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DbTools db = new DbTools();
                string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES;";
                DropDownListTabelle.DataSource = db.GetDataList(sql);
                DropDownListTabelle.DataBind();
                sql = "SELECT Id, CONCAT(Firstname,' ',LastName) as Description FROM Student ORDER BY LastName, FirstName";
                DropDownListStudenti.DataValueField = "Id";
                DropDownListStudenti.DataTextField = "Description";
                DropDownListStudenti.DataSource = db.GetDataTable(sql);
                DropDownListStudenti.DataBind();
                sql = "SELECT Id, CONCAT(Year,Section,' ',Specialization) as Description FROM Class ORDER BY Specialization,Year,Section";
                DropDownListClassi.DataValueField = "Id";
                DropDownListClassi.DataTextField = "Description";
                DropDownListClassi.DataSource = db.GetDataTable(sql);
                DropDownListClassi.DataBind();
                sql = "SELECT Id, Description FROM Subject ORDER BY Description";
                DropDownListMaterie.DataValueField = "Id";
                DropDownListMaterie.DataTextField = "Description";
                DropDownListMaterie.DataSource = db.GetDataTable(sql);
                DropDownListMaterie.DataBind();
                // load first table at first launch
                DropDownListTabelle_SelectedIndexChanged(sender, e);
            }
        }

        protected void DropDownListTabelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbTools db = new DbTools();
            string tableName = DropDownListTabelle.SelectedValue;
            string query = "SELECT * FROM " + tableName;
            loadData(query);
        }

        protected void DropDownListStudenti_SelectedIndexChanged(object sender, EventArgs e)
        {
            int studentId = int.Parse(DropDownListStudenti.SelectedValue);
            // Response.Write(studentId);
            string query = "SELECT ...";
            loadData(query);
        }

        protected void DropDownListClassi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int classId = int.Parse(DropDownListClassi.SelectedValue);
            string query = "SELECT ...";
            loadData(query);
        }

        protected void DropDownListMaterie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int subjectId = int.Parse(DropDownListMaterie.SelectedValue);
            string query = "SELECT ...";
            loadData(query);
        }

        private void loadData(string sqlQuery)
        {
            GridViewTable.DataSource = new DbTools().GetDataTable(sqlQuery);
            GridViewTable.DataBind();
        }
    }
}