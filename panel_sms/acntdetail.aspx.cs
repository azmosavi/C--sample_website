using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class acntdetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
       DataTable dt = new DataTable();
       dt =(DataTable) Session["jozhes1"];


        if (dt != null && dt.Rows.Count > 0)
        {
            gridview4.DataSource = dt;
            gridview4.DataBind();
        }
        else
        {

            Label9.Text ="error";
            gridview4.DataSource = null;
            gridview4.DataBind();
        }
       
        
    }


    protected void clk1(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");

    }

}