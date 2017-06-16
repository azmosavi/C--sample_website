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
            try
            {
                Table tb1 = new Table();
                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                {
                    TableRow tr = new TableRow();
                    for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                    {
                        TableCell tc1 = new TableCell();
                        tc1.Text = ds.Tables[0].Rows[r][c].ToString();
                        tr.Cells.Add(tc1);
                    }
                    tb1.Rows.Add(tr);
                }

                Response.Clear();
                Response.AddHeader("content-disposition", String.Format("attachment;filename={0}.xls", "test_pec"));
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                System.IO.StringWriter sw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

                tb1.RenderControl(hw);
                Response.Write(sw.ToString());

                hw.Flush();
                sw.Flush();
                hw.Close();
                sw.Close();
                Response.End();
            }
            catch(Exception ex)
            {
                lbl1.Text = ex.ToString();
            }


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