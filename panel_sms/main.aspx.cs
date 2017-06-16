using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class Default2 : System.Web.UI.Page
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
        Label50.Text = "";

    }

    protected void form1_load(object sender, EventArgs e)
    {

        //  if (TextBox2.Attributes.GetType("onkeydown") == null)
        //   {
        TextBox1.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        TextBox2.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        TextBox3.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        TextBox4.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        TextBox5.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        TextBox6.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        //   }


    }

    protected void clk1(object sender, EventArgs e)
    {

        string s = (string)Session["value"];
        string s1 = "مشخصات شناسنامه ای";
        string s2 = Session["Login"].ToString();
        bool res;
        connectDb db = new connectDb();
        DataSet ds1 = new DataSet();
        if (Session["dsclk1"] == null)
        {
            switch ((int)Session["Case_select"])
            {
                case 0:
                    ds1 = db.basic_b(s);
                    Session["dsclk1"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 1:
                    ds1 = db.basic_b1(s);
                    Session["dsclk1"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 2:
                    ds1 = db.basic_b3(s);
                    Session["dsclk1"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 3:
                    ds1 = db.basic_b2(s);
                    Session["dsclk1"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
            }
        }
        else
        {
            ds1 = (DataSet)Session["dsclk1"];
        }

        //if (RadioButtonList1.SelectedIndex == 0)
        //{
        //    TextBox2.Text = "";
        //    TextBox3.Text = "";
        //    TextBox4.Text = "";
        //    TextBox5.Text = "";
        //    TextBox6.Text = "";
        //    s = TextBox1.Text;
        //    if (Session["dsclk1"] == null)
        //    {
        //        ds1 = db.basic_b(s);
        //        Session["dsclk1"] = ds1;
        //        res = db.writelog(s2, s1, s);
        //    }

        //}
        //if (RadioButtonList1.SelectedIndex == 1)
        //{
        //    TextBox1.Text = "";
        //    TextBox3.Text = "";
        //    TextBox4.Text = "";
        //    TextBox5.Text = "";
        //    TextBox6.Text = "";
        //    s = TextBox2.Text;
        //    ds1 = db.basic_b1(s);
        //    res = db.writelog(s2, s1, s);
        //}
        //if (RadioButtonList1.SelectedIndex == 2)
        //{
        //    TextBox1.Text = "";
        //    TextBox2.Text = "";
        //    TextBox4.Text = "";
        //    TextBox5.Text = "";
        //    TextBox6.Text = "";
        //    s = TextBox3.Text;
        //    ds1 = db.basic_b3(s);
        //    res = db.writelog(s2, s1, s);
        //}


        //if (RadioButtonList1.SelectedIndex == 3)
        //{
        //    TextBox1.Text = "";
        //    TextBox2.Text = "";
        //    TextBox3.Text = "";
        //    s = TextBox4.Text + "-" + TextBox5.Text + "-" + TextBox6.Text;
        //    ds1 = db.basic_b2(s);
        //    res = db.writelog(s2, s1, s);
        //}

        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            gridview1.DataSource = ds1.Tables[0];
            gridview1.DataBind();
            Session["custid"] = ds1.Tables[0].Rows[0]["NO"];
        }
        else
        {
            Label50.Text = "داده ای یافت نشد";
            gridview1.DataSource = null;
            gridview1.DataBind();
        }

        multuview1.ActiveViewIndex = 0;



    }

    protected void rch1(object sender, EventArgs e)
    {



    }

    protected void clk2(object sender, EventArgs e)
    {
        string s = (string)Session["value"];
        string s1 = "اطلاعات حساب";
        string s2 = Session["Login"].ToString();
        bool res;
        hesab db = new hesab();
        DataSet ds1 = new DataSet();

        if (Session["dsclk2"] == null)
        {
            switch ((int)Session["Case_select"])
            {
                case 0:
                    ds1 = db.hesab1(s);
                    Session["dsclk2"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 1:
                    ds1 = db.hesab2(s);
                    Session["dsclk2"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 2:
                    ds1 = db.hesab4(s);
                    Session["dsclk2"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 3:
                    ds1 = db.hesab3(s);
                    Session["dsclk2"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
            }
        }
        else
        {
            ds1 = (DataSet)Session["dsclk2"];
        }



        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            gridview2.DataSource = ds1.Tables[0];
            gridview2.DataBind();
        }
        else
        {
            Label50.Text = "داده ای یافت نشد";
            gridview2.DataSource = null;
            gridview2.DataBind();

        }
        multuview1.ActiveViewIndex = 1;



    }

    protected void clk3(object sender, EventArgs e)
    {
        string s = (string)Session["value"];
        string s1 = "اطلاعات کارت";
        string s2 = Session["Login"].ToString();
        bool res;
        card db = new card();
        DataSet ds1 = new DataSet();


        if (Session["dsclk3"] == null)
        {
            switch ((int)Session["Case_select"])
            {
                case 0:
                    ds1 = db.card1(s);
                    Session["dsclk3"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 1:
                    ds1 = db.card2(s);
                    Session["dsclk3"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 2:
                    ds1 = db.card4(s);
                    Session["dsclk3"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
                case 3:
                    ds1 = db.card3(s);
                    Session["dsclk3"] = ds1;
                    res = db.writelog(s2, s1, s);
                    break;
            }
        }
        else
        {
            ds1 = (DataSet)Session["dsclk3"];
        }



        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            gridview3.DataSource = ds1.Tables[0];
            gridview3.DataBind();
        }
        else
        {
            Label50.Text = "داده ای یافت نشد";
            gridview3.DataSource = null;
            gridview3.DataBind();
        }
        multuview1.ActiveViewIndex = 2;
    }

    protected void clk5(object sender, EventArgs e)
    {
        bool res;
        
        string s = (string)Session["value"];
        string s1 = "خروج";
        string s2 = Session["Login"].ToString();
        jozcard db = new jozcard();
        res = db.writelog(s2, s1, s);

        Session["Login"] = null;
        Response.Redirect("login.aspx");
    }

    protected void clk6(object sender, EventArgs e)
    {

        string s1 = "مشخصات شناسنامه ای";
        string s2 = Session["Login"].ToString();
        bool res;
        connectDb db = new connectDb();
        DataSet ds1 = new DataSet();
        string s = "";
        Session["dsclk1"] = null;
        Session["dsclk2"] = null;
        Session["dsclk3"] = null;
        Session["dsclk9_mob"] = null;
        Session["jozcrd"] = null;
        Session["jozcrd1"] = null;
        Session["jozhes"] = null;
        Session["jozhes1"] = null;
        Session["mob"] = null;
        Session["sms"] = null;
        Session["email"] = null;
        Session["email_hesab"] = null;
        Session["int"] = null;
        Session["tel"] = null;



        Session["Case_select"] = RadioButtonList1.SelectedIndex;
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                s = TextBox1.Text;
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                ds1 = db.basic_b(s);
               // Session["custid"] = ds1.Tables[0].Rows[0]["NO"];
                Session["dsclk1"] = ds1;
                clk1(this, e);

                break;
            case 1:
                s = TextBox2.Text;
                TextBox1.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                ds1 = db.basic_b1(s);
                Session["dsclk1"] = ds1;
                clk1(this, e);
                break;
            case 2:
                s = TextBox3.Text;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                ds1 = db.basic_b3(s);
                Session["dsclk1"] = ds1;
                clk1(this, e);
                break;
            case 3:
                s = TextBox4.Text + "-" + TextBox5.Text + "-" + TextBox6.Text;
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox1.Text = "";
                ds1 = db.basic_b2(s);
                Session["dsclk1"] = ds1;
                clk1(this, e);

                break;

        }


     
        res = db.writelog(s2, s1, s);
        Session["value"] = s;
        // gridview1.DataSource = null;
        //  gridview1.DataBind();
        gridview2.DataSource = null;
        gridview2.DataBind();
        gridview3.DataSource = null;
        gridview3.DataBind();
        Button1.Visible = true;
        Button2.Visible = true;
        Button3.Visible = true;
        Button5.Visible = true;
        Button12.Visible = true;

    }

    protected void clk7(object sender, EventArgs e)
    {

        string s1 = "جزییات حساب";
        string s2 = Session["Login"].ToString();
        bool res;
        jozhesab db = new jozhesab();
        DataSet ds1 = new DataSet();
        for (int i = 0; i < gridview2.Rows.Count; i++)
        {
            if ((Button)gridview2.Rows[i].FindControl("Button4") == sender)
            {

                Label l1 = (Label)gridview2.Rows[i].FindControl("Label38");
                string s = l1.Text;
                ds1 = db.jozhesab1(s);
                res = db.writelog(s2, s1, s);

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Session["jozhes"] = ds1;
                    DataTable dt = ds1.Tables[0];
                    Session["jozhes1"] = dt;
                    Random r = new Random(); 
            Response.Redirect("acntdetail.aspx");
                   // string URL = "http://intranettools.parsian-bank.com/services/callcenterservice/acntdetail.aspx?val=" + Session["jozhes1"] + "&rand=" + r.Next();
                   //string str = "<script language=javascript>window.open(\"" + URL + "\",'acntdetail' , 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no, left=10px,top=20px,width=450px,height=500'); </script>";
                  //  Page.RegisterStartupScript("Pop", str);

                }
                else
                {
                    Label50.Text = "داده ای یافت نشد";

                }


            }

        }

    }

    protected void clk8(object sender, EventArgs e)
    {

        string s1 = "جزییات کارت";
        string s2 = Session["Login"].ToString();
        bool res;
        jozcard db = new jozcard();
        DataSet ds1 = new DataSet();
        for (int i = 0; i < gridview3.Rows.Count; i++)
        {
            if ((Button)gridview3.Rows[i].FindControl("Button6") == sender)
            {

                Label l1 = (Label)gridview3.Rows[i].FindControl("Label51");
                string s = l1.Text;
                ds1 = db.jozcard1(s);
                res = db.writelog(s2, s1, s);

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Session["jozcrd"] = ds1;
                    DataTable dt = ds1.Tables[0];
                    Session["jozcrd1"] = dt;
                   Response.Redirect("carddtl.aspx");
                    Random r = new Random();
                  // string URL = "http://localhost:3391/panel_sms/carddtl.aspx?val=" + Session["jozcrd1"] + "&rand=" + r.Next();
                   // string URL = "http://intranettools.parsian-bank.com/services/callcenterservice/carddtl.aspx?val=" + Session["jozcrd1"] + "&rand=" + r.Next();
                    // string str = "<script language=javascript>window.open(\"" + URL + "\",'acntdetail' , 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no, left=10px,top=20px,width=900px,height=520'); </script>";
                   //Page.RegisterStartupScript("Pop", str);

                }
                else
                {
                    Label50.Text = "داده ای یافت نشد";

                }


            }

        }

    }

    protected void clk9(object sender, EventArgs e)
    {
        Label73.Text = "";
        Label83.Text = "";
        Label72.Text = "";
        Label88.Text = "";
        Label82.Text = "";
        Label71.Text = "";



        string s = (string)Session["value"];
        string s1 = "sms_email_mob";
        string s2 = Session["Login"].ToString();
        bool res;
        jozcard db1 = new jozcard();
     

        modernservs db = new modernservs();
        DataSet ds_mob = new DataSet();

        string s3 = Session["custid"].ToString();

        res = db1.writelog(s2, s1, s3);


        if (Session["mob"] == null)
        {
            ds_mob = db.cust_modservs1(s3);
            Session["mob"] = ds_mob;
        }
        else
	{
        ds_mob=(DataSet) Session["mob"];
	}
        
        if (ds_mob != null && ds_mob.Tables[0].Rows.Count > 0)
        {
            gridview6.DataSource = ds_mob.Tables[0];
            gridview6.DataBind();
        }
        else
        {
            Label73.Text = "دارای سرویس موبایل بانک نمی باشد";
            gridview6.DataSource = null;
            gridview6.DataBind();

        }

        sms_email db_sms = new sms_email();
        DataSet ds_sms_stat = new DataSet();
        string er = "";

        if (Session["sms"] == null)
        {
            ds_sms_stat = db_sms.sms_stat(s3, out er);
            Session["sms"] = ds_sms_stat;
        }
        else
        {
            ds_sms_stat = (DataSet)Session["sms"];
        }
       
               
        if (ds_sms_stat != null && ds_sms_stat.Tables[0].Rows.Count > 0)
        {
            gridview8.DataSource = ds_sms_stat.Tables[0];
            gridview8.DataBind();
        }


        else if (er == "Fatal error encountered during command execution.")
        {
            Label82.Text = "ارتباط با مرکز قطع می باشد";
            gridview8.DataSource = null;
            gridview8.DataBind();
        }
        else
        {
            Label82.Text = "دارای سرویس sms نمی باشد";
            gridview8.DataSource = null;
            gridview8.DataBind();
        }

        DataSet ds_email_stat = new DataSet();

        if (Session["email"] == null)
        {
            ds_email_stat = db_sms.email_stat(s3, out er);
            Session["email"] = ds_email_stat;
        }
        else
        {
            ds_email_stat = (DataSet)Session["email"];
        }
       

        if (ds_email_stat != null && ds_email_stat.Tables[0].Rows.Count > 0)
        {

          
            Label71.Text = ds_email_stat.Tables[0].Rows[0]["active"].ToString();
            Label83.Text = ds_email_stat.Tables[0].Rows[0]["email"].ToString();
     
        }
        else if (er == "Fatal error encountered during command execution.")
        {
            Label88.Text = "ارتباط با مرکز قطع می باشد";
          
        }
        else
        {
            Label88.Text = "دارای سرویسemail نمی باشد";
          
        }

         multuview1.ActiveViewIndex = 3;
    }

    protected void clk10(object sender, EventArgs e)
    {
        
        Label75.Text = "";
        Label70.Text = "";
        Label91.Text = "";
        Label90.Text = "";
        bool res;
        string er = "";
        string s = (string)Session["value"];
        string s1 = "تلفن باک- اینترنت بانک";
        string s2 = Session["Login"].ToString();
        jozcard db = new jozcard();
        res = db.writelog(s2, s1, s);

        internet_bank db_int = new internet_bank();
        DataSet ds_int_stat = new DataSet();
        string s3 = Session["custid"].ToString();
        if (Session["int"] == null)
        {
             ds_int_stat = db_int.isuser(s3, out er);
            Session["int"] = ds_int_stat;
        }
        else
        {
            ds_int_stat = (DataSet)Session["int"];
        }
       

        if (ds_int_stat != null && ds_int_stat.Tables[0].Rows.Count > 0)
        {
            gridview7.DataSource = ds_int_stat.Tables[0];
            gridview7.DataBind();
            Label70.Text = ds_int_stat.Tables[0].Rows[0]["lastlog"].ToString();
        }

        else
        {
            Label75.Text = "دارای سرویس اینترنت بانک نمی باشد";
            gridview7.DataSource = null;
            gridview7.DataBind();
        }


        er = "";
        tel_bank db_tel = new tel_bank();
        DataSet ds_tel_stat = new DataSet();

        if (Session["tel"] == null)
        {
            ds_tel_stat = db_tel.telbank_stat(s3, out er);

            Session["tel"] = ds_tel_stat;
        }
        else
        {
            ds_tel_stat = (DataSet)Session["tel"];
        }


        if (ds_tel_stat != null && ds_tel_stat.Tables[0].Rows.Count > 0)
        {
            gridview9.DataSource = ds_tel_stat.Tables[0];
            gridview9.DataBind();
        }

        else
        {
            Label90.Text = "دارای سرویس تلفن بانک نمی باشد";
            gridview9.DataSource = null;
            gridview9.DataBind();
        }

        DataSet ds_tel_vorood = new DataSet();
        ds_tel_vorood = db_tel.telbank_vorood(s3);

        if (ds_tel_vorood != null && ds_tel_vorood.Tables[0].Rows.Count > 0)
        {
            Label91.Text = ds_tel_vorood.Tables[0].Rows[0]["lastlog"].ToString();
        }


        multuview1.ActiveViewIndex = 4;
    }

    protected void clksaghf(object sender, EventArgs e)
    {

        string s1 = "سقف اینترنت بانک";
        string s2 = Session["Login"].ToString();
        bool res;
        jozcard db = new jozcard();
        res = db.writelog(s2, s1, Session["custid"].ToString());
        Random r = new Random();
      //  string URL = "http://localhost:53434/panel_sms/int_saghf.aspx?val=" + Session["custid"] + "&rand=" + r.Next();
       //      string URL = "http://intranettools.parsian-bank.com/services/callcenterservice/int_saghf.aspx?val=" + Session["custid"]+ "&rand=" + r.Next();
        //string str = "<script language=javascript>window.open(\"" + URL + "\",'int_saghf' , 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no, left=10px,top=20px,width=500px,height=200'); </script>";
        //Page.RegisterStartupScript("Pop", str);
        Response.Redirect("int_saghf.aspx");

    }

    protected void saghf_tel(object sender, EventArgs e)
    {
        string s1 = "سقف تلفن بانک";
        string s2 = Session["Login"].ToString();
        bool res;
        jozcard db = new jozcard();
        res = db.writelog(s2, s1, Session["custid"].ToString());
        
        Random r = new Random();
     //   string URL = "http://localhost:53434/panel_sms/tel_saghf.aspx?val=" + Session["custid"] + "&rand=" + r.Next();
        //    string URL = "http://intranettools.parsian-bank.com/services/callcenterservice/tel_saghf.aspx?val=" + Session["custid"]+ "&rand=" + r.Next();
        //string str = "<script language=javascript>window.open(\"" + URL + "\",'tel_saghf' , 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no, left=10px,top=20px,width=500px,height=200'); </script>";
        //Page.RegisterStartupScript("Pop", str);
        Response.Redirect("tel_saghf.aspx");

    }

    protected void hesabha(object sender, EventArgs e)
    {
        string s1 = "حسابهای ارسال ایمیل";
        string s2 = Session["Login"].ToString();
        bool res;
        jozcard db = new jozcard();
        res = db.writelog(s2, s1, Session["custid"].ToString());


        Random r = new Random();
      //  string URL = "http://localhost:53434/panel_sms/viewacnt.aspx?val=" + Session["custid"] + "&rand=" + r.Next();
        // string URL = "http://intranettools.parsian-bank.com/services/callcenterservice/viewacnt.aspx?val=" + Session["custid"]+ "&rand=" + r.Next();
       //string str = "<script language=javascript>window.open(\"" + URL + "\",'viewacnt' , 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no, left=10px,top=20px,width=1100px,height=230'); </script>";
       //Page.RegisterStartupScript("Pop", str);

        Response.Redirect("viewacnt.aspx");

    }
}

