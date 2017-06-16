using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Drawing;


public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Login"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            string session_user = (string)Session["Login"];
        }
    }

    protected void clk1(object sender, EventArgs e)
    {

      

        string dt = TextBox2.Text;
      
        if (TextBox2.Text == "" )
        {
            Label2.Text = "error";
            return;
        }


       // string str2 = "Azi";
        string filename = "pec_acc.xls";
        Class_reps db = new Class_reps();
        DataSet ds = new DataSet();
        ds = db.jads_one(dt);
        if (ds!=null && ds.Tables[0].Rows.Count>0)
        {
           //gridview1.DataSource = ds.Tables[0];
          //  gridview1.DataBind();
            DataTable dt1 = ds.Tables[0];
            Response.Clear();
            //Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", "pec_file1"));
            Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", "pec_file'" + DateTime.Now + "'"));
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            Response.Expires = 300;

            Response.Write("<table border=\"0\" style=\"font-family:tahoma;font-size:X-Small;\">"); Response.Write("\n");
            Response.Write("<tr>"); Response.Write("\n");
            Response.Write("<td colspan=\"5\" style=\"font-weight:bold; padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write(" در تاریخPEC مانده حسابهای" + DateTime.Now);
            Response.Write("</td></tr><tr>");
            //****
            Response.Write("<td style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write("تاریخ");
            Response.Write("</td>");
            //****
            Response.Write("<td style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write("شماره حساب");
            Response.Write("</td>");
            //****
            Response.Write("<td style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write("نام فروشگاه");
            Response.Write("</td>");
            //****
            Response.Write("<td style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write("تعداد");
            Response.Write("</td>");
            //****
            Response.Write("<td style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:center;\">");
            Response.Write("مانده حساب");
            Response.Write("</td>");
            //****
            Response.Write("</tr>");

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Response.Write("<tr>");
                for (int j = 0; j < dt1.Columns.Count; j++)
                {
                    //Response.Write("<td dir=\"ltr\" style=\"padding:.3em .3em .3em .3em;border-style:groove;border-width:thin;text-align:left;vertical-align:top;\">");
                    Response.Write("<td>");
                    Response.Write(dt1.Rows[i][j].ToString());
                    Response.Write("</td>");
                }
                Response.Write("</tr>");
                Response.Write("\n");
                Response.Flush();
            }
            Response.Write("</table>");
            Response.Flush();
            Response.End();
        }

    }


    protected void clkexcel(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        this.EnableViewState = false;
        //Remove the charset from the Content-Type header
        Response.Charset = String.Empty;

        Response.Charset = "";
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
      gridview1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();


    }



    protected void excell3(string str2, string filename)
    {
      
    }




    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }


    protected void gridindex(object sender, GridViewPageEventArgs e)
    {

      
        DataSet ds = new DataSet();
        ds= (DataSet)Session["grid"];
        gridview1.DataSource = ds.Tables[0];
        gridview1.PageIndex = e.NewPageIndex;
        gridview1.DataBind();
    }

}