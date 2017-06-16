using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class bankstatement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        DataSet ds = new DataSet();
       
        ds = (DataSet)Session["sorathesab"];
        if (ds!=null && ds.Tables[0].Rows.Count>0)
        {
            gridview1.DataSource = ds.Tables[0];
            gridview1.DataBind();

        }
        else
        {

        }



    }

    protected void btn1(object sender, EventArgs e)
    {
       
        Response.Redirect("main.aspx");
    }
}