using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class carddtl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        DataTable dt = new DataTable();
        dt = (DataTable)Session["jozcrd1"];
        DataSet ds1 = new DataSet();
    


        if (dt != null && dt.Rows.Count > 0)
        {

            gridview5.DataSource = dt;
            gridview5.DataBind();

            for (int i = 0; i < gridview5.Rows.Count; i++)
            {


                Label l1 = (Label)gridview5.Rows[i].FindControl("Label5");
                string s = l1.Text;
                Label4.Text = s;

            }

        }

        else
        {

            Label9.Text = "error";
            gridview5.DataSource = null;
            gridview5.DataBind();
        }
       



    }

    protected void clk1(object sender, EventArgs e)
    {
        Response.Redirect("main.aspx");

    }

   

}