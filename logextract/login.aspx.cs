using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;

public partial class Default3 : System.Web.UI.Page
{

  
    {
        Label3.Text = "";

    }

    protected void clk1(object sender, EventArgs e)
    {
       string session_user = TextBox1.Text;
       bccif db = new bccif();
       DataSet ds1= new DataSet();

       
            SqlConnection sqlcon = new SqlConnection(sqldb);
            SqlCommand sqlcom = new SqlCommand();
            sqlcom.CommandText = "select password from Users where PersCode='" + TextBox1.Text + "' and PassWord='" + TextBox2.Text + "'";
            sqlcom.Connection = sqlcon;
            sqlcon.Open();
            SqlDataReader sqldr = default(SqlDataReader);
            sqldr = sqlcom.ExecuteReader();


            com.parsian_bank.intranettools.Service1 srv = new com.parsian_bank.intranettools.Service1();

            bool logonOk = false;
            string[] st = null;
            st = srv.Login(TextBox1.Text, TextBox2.Text);

            if (st[0] == "Ok")
            {

                Session["Login"] = session_user;
                Response.Redirect("main.aspx");
                Session.Add("Login", session_user);

            }


            else
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
                Label3.Text = "error";
            }



             
             }
          
    
}