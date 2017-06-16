using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using MySql.Data.MySqlClient;

public partial class int_saghf : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        internet_bank db_int = new internet_bank();
        DataSet ds_int_saghf = new DataSet();
        ds_int_saghf = db_int.saghf(Session["custid"].ToString());

        if (ds_int_saghf != null && ds_int_saghf.Tables[0].Rows.Count > 0)
        {
            gridview1.DataSource = ds_int_saghf.Tables[0];
            gridview1.DataBind();
        }

        else
        {
            Label9.Text = "error";
            gridview1.DataSource = null;
            gridview1.DataBind();
        }
    }


    protected void clk1(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");

    }

}
