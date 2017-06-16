using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void clck(object sender, EventArgs e)
    {
        connectDb db = new connectDb();
        string s_mob = db.connFun(Textbox1.Text);
      //  ServiceReference1.ProvidersSoapClient s = new ServiceReference1.ProvidersSoapClient();
       // res.Text = s.Atiye(s_mob, txt.Value);

    }
    protected void clk1(object sender, EventArgs e)
    {
        label1.Text = "";
        label2.Text = "";
        connectDb db = new connectDb();
        label1.Text = db.retName(Textbox1.Text);

    }



}