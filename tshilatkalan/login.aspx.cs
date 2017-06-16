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

    
    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = "";

    }

    protected void clk1(object sender, EventArgs e)
    {
        string session_user = TextBox1.Text;
     

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