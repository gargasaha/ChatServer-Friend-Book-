using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class Container : System.Web.UI.MasterPage
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Session["Fid"] = "202404301";
            //lbl.Text = Request.QueryString["t1"];
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("select  Image from Friendinfo where Fid='" + Session["Fid"].ToString() + "'", sqlConnection);
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                byte[] bytes = (byte[])sqlDataReader[0];
                string i = Convert.ToBase64String(bytes);
                usrimg.ImageUrl = "data:Image1/png;base64," + i;
            }
        }
        protected void gotoaf(object sender, EventArgs e)
        {
            Response.Redirect("addFriend.aspx");
        }
        protected void gotoch(object sender, EventArgs e)
        {
            Response.Redirect("ChatPage.aspx");
        }
    }
}