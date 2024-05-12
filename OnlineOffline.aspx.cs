using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FinalYearProject
{
    public partial class OnlineOffline : System.Web.UI.Page
    {
        static int f = 0;
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Fid"] = "202403011";
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            sqlConnection.Open();
            showonline();

            sqlConnection.Close();
        }
        protected void setsession(object sender, EventArgs e)
        {
            Session["CFid"] = ((Button)sender).ID.ToString();
        }
        protected void showonline()
        {
            sqlCommand = new SqlCommand("listFromOnlineFriend", sqlConnection);
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
            sqlDataReader = sqlCommand.ExecuteReader();
            Table tbl1 = new Table();
            tbl1.CssClass = "tbl";

            while (sqlDataReader.Read())
            {

                SqlCommand command = new SqlCommand("select LiveInfo Info from LiveUser where Fid='" + sqlDataReader[3].ToString() + "'", sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                int status = -1;
                while (reader.Read())
                {
                    status = Convert.ToInt32(reader[0]);
                }
                TableRow row = new TableRow();

                Image img = new Image();
                Image img2 = new Image();
                byte[] bytes = (byte[])sqlDataReader[2];
                string i = Convert.ToBase64String(bytes);
                img.ImageUrl = "data:Image1/png;base64," + i;
                img.Height = 100;
                img.Width = 100;
                img.CssClass = "aa";

                if (status == 1)
                {
                    img2.ImageUrl = "~/IMAGES/green.gif";
                    img2.CssClass = "lowerimg2";
                }
                else
                {
                    img2.ImageUrl = "~/IMAGES/offlinered.png";
                }

                string temp = string.Empty;
                SqlCommand Command = new SqlCommand("getchatonemessage", sqlConnection);
                Command.CommandType = System.Data.CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@Fid", Session["Fid"].ToString());
                Command.Parameters.AddWithValue("@CFid", sqlDataReader[3].ToString());
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    if (sqlDataReader[0].ToString().Equals(Session["Fid"].ToString())){

                    }
                    else{
                        temp = Reader[2].ToString();
                    }
                }

                img2.Height = 10;
                img2.Width = 10;
                Button btn = new Button();
                btn.Width = 150;
                btn.Text = " " + sqlDataReader[0].ToString() + " " + sqlDataReader[1].ToString() + "\n" + temp;
                btn.CssClass = "aa";
                //btn.ForeColor = System.Drawing.Color.White;
                btn.ID = sqlDataReader[3].ToString();
                btn.Click += new EventHandler(setsession);

                //adding profile image to table cell
                TableCell cell1 = new TableCell();
                cell1.Controls.Add(img);
                //cell1.BackColor = System.Drawing.Color.Gray;

                //adding online icon to table cell
                TableCell cell2 = new TableCell();
                cell2.Controls.Add(img2);
                //cell2.BackColor = System.Drawing.Color.Gray;

                //adding friend name to table cell
                TableCell cell3 = new TableCell();
                cell3.Controls.Add(btn);
                //cell3.BackColor = System.Drawing.Color.Gray;
                //cell3.Controls.Add(lbl);


                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                //row.CssClass = "row";
                //row.BackColor = System.Drawing.Color.Gray;
                tbl1.Rows.Add(row);
                //tbl1.BackColor = System.Drawing.Color.Gray;
            }
            pnl1.Controls.Add(tbl1);
            //sqlConnection.Close();
        }


    }
}