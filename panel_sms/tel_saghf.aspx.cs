using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;

public partial class tel_saghf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       tel_bank db_tel = new tel_bank();
        DataSet ds_tel_saghf = new DataSet();
        ds_tel_saghf = db_tel.saghf(Session["custid"].ToString());

        if (ds_tel_saghf != null && ds_tel_saghf.Tables[0].Rows.Count > 0)
        {
            gridview2.DataSource = ds_tel_saghf.Tables[0];
            gridview2.DataBind();
        
        }

        else
        {
            Label9.Text = "error";
            gridview2.DataSource = null;
            gridview2.DataBind();
        }
    }


    protected void clk1(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");

    }

    }

