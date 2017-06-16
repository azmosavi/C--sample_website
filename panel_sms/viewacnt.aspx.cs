using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class viewacnt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        sms_email db_email = new sms_email();
        DataSet ds_email_hesab = new DataSet();

        if (Session["email_hesab"] == null)
        {
            ds_email_hesab = db_email.email_hesabha(Session["custid"].ToString());
            Session["email_hesab"] = ds_email_hesab;
        }
        else
        {
            ds_email_hesab = (DataSet)Session["email_hesab"];
        }


       // ds_email_hesab = db_email.email_hesabha(Session["custid"].ToString());

        if (ds_email_hesab != null && ds_email_hesab.Tables[0].Rows.Count > 0)
        {
            gridview2.DataSource = ds_email_hesab.Tables[0];
            gridview2.DataBind();

        }

        else
        {
            Label9.Text ="error";
            gridview2.DataSource = null;
            gridview2.DataBind();
        }
    }


    protected void clk1(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");

    }
}