using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void radioch(object sender, EventArgs e)
    {
         switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                 TextBox1.Enabled = true;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                 break;
            case 1:
                 TextBox3.Enabled = true;
                 TextBox4.Text = "";
                 TextBox5.Text = "";
                 TextBox6.Text = "";
                 TextBox1.Text = "";
                TextBox1.Enabled = false;
                TextBox4.Enabled = false;
                TextBox5.Enabled = false;
                TextBox6.Enabled = false;
                 break;
            case 2:
                 TextBox3.Enabled = false;
                TextBox1.Enabled = false;
                TextBox3.Text = "";
                TextBox1.Text = "";
                TextBox4.Enabled = true;
                TextBox5.Enabled = true;
                TextBox6.Enabled = true;
                 break;

        }
    }

    protected void clk1(object sender, EventArgs e)
    {

        string s1 =  "error";
        string s2 = Session["Login"].ToString();
        bool res;
        bccif db = new bccif();
        DataSet ds1 = new DataSet();
        Label106.Text = "";

        string s = "";
        Session["dsclk1"] = null;
        Session["ID"] = null;
        Session["paia"] = null;
        Session["int1"] = null;
        Session["int2"] = null;
        Session["int3"] = null;
        Session["cardsys"] = null;
        Session["dat1"] = null;
        Session["dat2"] = null;

        Session["Case_select"] = RadioButtonList1.SelectedIndex;
        switch (RadioButtonList1.SelectedIndex)
        {
            case 0:
                s = TextBox1.Text;
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                ds1 = db.bc(s);
                Session["dsclk1"] = ds1;
                TextBox1.Enabled = true;
                


                break;
            case 1:
                s = TextBox3.Text;
                TextBox1.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                ds1 = db.bc1(s);
                Session["dsclk1"] = ds1;
                TextBox3.Enabled = true;
                

                break;
            case 2:
                s = TextBox4.Text + "-" + TextBox5.Text + "-" + TextBox6.Text;
                TextBox1.Text = "";
                TextBox3.Text = "";
                ds1 = db.bc2(s);
                Session["dsclk1"] = ds1;
                TextBox4.Enabled = true;
                TextBox5.Enabled = true;
                TextBox6.Enabled = true;
                
               

                break;


        }
        Session["value"] = s;

        if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
        {
            gridview1.DataSource = ds1.Tables[0];
            gridview1.DataBind();
            Session["ID"] = ds1.Tables[0].Rows[0]["no"].ToString();
            DropDownList1.Visible = true;
            Label44.Visible = true;
            Label42.Visible = true;
            Label45.Visible = true;
            TextBox2.Visible = true;
            TextBox7.Visible = true;
            clksch.Visible = true;



        }

        else
        {

            Label106.Text = "داده ای یافت نشد";
            gridview1.DataSource = null;
            gridview1.DataBind();
            gridview_khadamat.DataSource = null;
            gridview_khadamat.DataBind();
            gridview_int1.DataSource = null;
            gridview_int1.DataBind();
            gridview_int2.DataSource = null;
            gridview_int2.DataBind();
            gridview_int3.DataSource = null;
            gridview_int3.DataBind();
            gridview_card.DataSource = null;
            gridview_card.DataBind();
            clksch.Visible = false;

        }

        multuview1.ActiveViewIndex = 0;
        res = db.writelog(s2, s1, s);

    }
    protected void dpch1(object sender, EventArgs e)
    {
        multuview1.ActiveViewIndex = 1;

        Label56.Text = "";
        Label88.Text = "";
        bccif db = new bccif();
        bool res;
        string s_job = "";
        string s2 = Session["Login"].ToString();
        gridview_khadamat.DataSource = null;
        gridview_khadamat.DataBind();
        gridview_card.DataSource = null;
        gridview_card.DataBind();
        gridview_int1.DataSource = null;
        gridview_int1.DataBind();
        gridview_int2.DataSource = null;
        gridview_int2.DataBind();
        gridview_int3.DataSource = null;
        gridview_int3.DataBind();
        gridview_pardakhtcard.DataSource = null; 
        gridview_pardakhtcard.DataBind();


        int_bank db_int = new int_bank();

        DataSet ds_fcard = new DataSet();
        DataSet ds_paia = new DataSet();
        DataSet ds_int1 = new DataSet();
        DataSet ds_int2 = new DataSet();
        DataSet ds_int3 = new DataSet();

        DataSet ds_sorathesab1 = new DataSet();
        DataSet ds_sorathesab2 = new DataSet();
        DataSet ds_sorathesab3 = new DataSet();

        string s = Session["ID"].ToString();

        if (s == "")
        {
            Label56.Text =  "error";
            return;
        }

        if (TextBox2.Text == "" || TextBox7.Text == "")
        {
            Label56.Text =  "error";
            return;
        }

        if (DropDownList1.SelectedValue == "")
        {
            Label56.Text =  "error";
            return;
        }


        else
        {
            string dat1 = TextBox2.Text;
            string dat2 = TextBox7.Text;
            string dat11_m = dat1.Replace("/", "");
            string dat21_m = dat2.Replace("/", "");
            if (Int32.Parse(dat21_m) <Int32.Parse(dat11_m))
            {
                Label56.Text =  "error";
            return;
            }
            paia db_paia = new paia();
            DataSet ds_dat = new DataSet();
            ds_dat = db_paia.finddat(dat11_m);
            string ds_dat_eval = ds_dat.Tables[0].Rows[0]["dat"].ToString();
            int ds_dat_eval1 = Int32.Parse(ds_dat_eval);
            int ds_dat_eval2 = Int32.Parse(dat21_m);
            if (ds_dat_eval2 > ds_dat_eval1)
            {
                Label56.Text =  "error";
            }
            else if (ds_dat_eval2 <= ds_dat_eval1)
            {

                string dat11 = String.Format("{0:yy/MM/dd}", dat1).Substring(2);
                string dat21 = String.Format("{0:yy/MM/dd}", dat2).Substring(2);

                DateTime dat1_main = dat.PersianToGregorian(dat11, dat.DateFormat.YY_MM_DD);
                DateTime dat2_main = dat.PersianToGregorian(dat21, dat.DateFormat.YY_MM_DD);

                string dat11_main = string.Format("{0:yyyyMMdd}", dat1_main);
                string dat21_main = string.Format("{0:yyyyMMdd}", dat2_main);

                int dat11_p = Int32.Parse(dat11_m);
                int dat21_p = Int32.Parse(dat21_m);

                switch (DropDownList1.SelectedIndex)
                {

                    case 1:
                        s_job = "پایا";
                        res = db.writelog(s2, s_job, s);
                        if (Session["paia"] == null || (Session["dat1"].ToString() != TextBox2.Text) || (Session["dat2"].ToString() != TextBox7.Text))
                        {
                            ds_paia = db_paia.khadamat(s, dat1, dat2);
                            Session["paia"] = ds_paia;
                            Session["dat1"] = TextBox2.Text;
                            Session["dat2"] = TextBox7.Text;
                        }
                        else if ((Session["paia"] != null) && (Session["dat1"].ToString() == TextBox2.Text) && Session["dat2"].ToString() == TextBox7.Text)
                        {
                            ds_paia = (DataSet)Session["paia"];
                        }
                        if (ds_paia != null && ds_paia.Tables[0].Rows.Count > 0)
                        {
                            gridview_khadamat.DataSource = ds_paia.Tables[0];
                            gridview_khadamat.DataBind();
                        }
                        else
                        {
                            Label56.Text = "داده ای یافت نشد";
                            gridview_khadamat.DataSource = null;
                            gridview_khadamat.DataBind();
                        }

                        break;
                    case 2:

                        s_job =  "error";
                        res = db.writelog(s2, s_job, s);

                      
                        //asli ghabli
                        if (Session["int1"] == null || (Session["dat1_int1"].ToString() != TextBox2.Text) || (Session["dat2_int1"].ToString() != TextBox7.Text))
                        {
                            ds_int1 = db_int.smallest_archive(s, dat11_m, dat21_m);
                            Session["int1"] = ds_int1;
                            Session["dat1_int1"] = TextBox2.Text;
                            Session["dat2_int1"] = TextBox7.Text;
                        }
                        else if ((Session["int1"] != null) && (Session["dat1_int1"].ToString() == TextBox2.Text) && Session["dat2_int1"].ToString() == TextBox7.Text)
                        {
                            ds_int1 = (DataSet)Session["int1"];
                        }


                        if (ds_int1 != null && ds_int1.Tables[0].Rows.Count > 0)
                        {
                            gridview_int1.DataSource = ds_int1.Tables[0];
                            gridview_int1.DataBind();
                            Button2.Visible = true;
                            Button10.Visible = true;
                        }
                        else
                        {
                            gridview_int1.DataSource = null;
                            gridview_int1.DataBind();

                        
                            if (Session["int2"] == null || (Session["dat1_int2"].ToString() != TextBox2.Text) || (Session["dat2_int2"].ToString() != TextBox7.Text))
                            {
                                ds_int2 = db_int.smaller_archive(s, dat11_m, dat21_m);
                                Session["int2"] = ds_int2;
                                Session["dat1_int2"] = TextBox2.Text;
                                Session["dat2_int2"] = TextBox7.Text;
                            }
                            else if ((Session["int2"] != null) && (Session["dat1_int2"].ToString() == TextBox2.Text) && Session["dat2_int2"].ToString() == TextBox7.Text)
                            {
                                ds_int2 = (DataSet)Session["int2"];
                            }

                            if (ds_int2 != null && ds_int2.Tables[0].Rows.Count > 0)
                            {
                                multuview1.ActiveViewIndex = 2;
                                gridview_int2.DataSource = ds_int2.Tables[0];
                                gridview_int2.DataBind();
                                Button3.Visible = true;
                                Button11.Visible = true;
                            }
                            else
                            {
                                gridview_int2.DataSource = null;
                                gridview_int2.DataBind();
                                if (Session["int3"] == null || (Session["dat1_int3"].ToString() != TextBox2.Text) || (Session["dat2_int3"].ToString() != TextBox7.Text))
                                {
                                    ds_int3 = db_int.biger_archive(s, dat11_m, dat21_m);
                                    Session["int3"] = ds_int3;
                                    Session["dat1_int3"] = TextBox2.Text;
                                    Session["dat2_int3"] = TextBox7.Text;

                                }
                                else if ((Session["int3"] != null) && (Session["dat1_int3"].ToString() == TextBox2.Text) && Session["dat2_int3"].ToString() == TextBox7.Text)
                                {
                                    ds_int3 = (DataSet)Session["int3"];
                                }

                                if (ds_int3 != null && ds_int3.Tables[0].Rows.Count > 0)
                                {
                                    multuview1.ActiveViewIndex = 3;
                                    Button12.Visible = false;
                                    gridview_int3.DataSource = ds_int3.Tables[0];
                                    gridview_int3.DataBind();
                                }
                                else
                                {
                                    gridview_int3.DataSource = null;
                                    gridview_int3.DataBind();
                                    Label56.Text =  "error";

                                }

                            }
                        }
                

                
                  


                break;

                    case 3:
                        s_job = "پرداخت کارت";
                        res = db.writelog(s2, s_job, s);
                        ds_fcard = db_paia.findcardno(s);

                        if (ds_fcard != null && ds_fcard.Tables[0].Rows.Count > 0)
                        {
                            multuview1.ActiveViewIndex = 4;
                            gridview_card.DataSource = ds_fcard.Tables[0];
                            gridview_card.DataBind();

                        }

                        else
                        {
                            gridview_card.DataSource = null;
                            gridview_card.DataBind();
                            Label56.Text =  "error";

                        }
                        break;

                }

            }


        }
    }


    protected void clkcard(object sender, EventArgs e)
    {

      
        multuview1.ActiveViewIndex = 4;
        gridview_pardakhtcard.DataSource = null;
        gridview_pardakhtcard.DataBind();
        Label88.Text = "";
        DataSet ds_card = new DataSet();
        bool res;
        bccif db = new bccif();

        card db_card = new card();

        string dat1 = TextBox2.Text;
        string dat2 = TextBox7.Text;

        string dat11 = String.Format("{0:yy/MM/dd}", dat1).Substring(2);
        string dat21 = String.Format("{0:yy/MM/dd}", dat2).Substring(2);



        DateTime dat1_main = dat.PersianToGregorian(dat11, dat.DateFormat.YY_MM_DD);
        DateTime dat2_main = dat.PersianToGregorian(dat21, dat.DateFormat.YY_MM_DD);

        string dat11_main = string.Format("{0:yyyyMMdd}", dat1_main);
        string dat21_main = string.Format("{0:yyyyMMdd}", dat2_main);

        string er = "";
        string s2 = Session["Login"].ToString();
        string s_job =  "error";

        for (int i = 0; i < gridview_card.Rows.Count; i++)
        {
            if ((Button)gridview_card.Rows[i].FindControl("Button7") == sender)
            {

                Label l4 = (Label)gridview_card.Rows[i].FindControl("Label90");
                string sl4 = l4.Text;
                Label82.Text = sl4;
                res = db.writelog(s2, s_job, sl4);
                if (Session["cardsys"] == null || (Session["dat1"].ToString() != TextBox2.Text) || (Session["dat2"].ToString() != TextBox7.Text))
                {
                    ds_card = db_card.extract(sl4, dat11_main, dat21_main, out er);
                    Session["cardsys"] = ds_card;
                    Session["dat1"] = TextBox2.Text;
                    Session["dat2"] = TextBox7.Text;
                }
                else if ((Session["cardsys"] != null) && (Session["dat1"].ToString() == TextBox2.Text) && Session["dat2"].ToString() == TextBox7.Text)
                {
                    ds_card = (DataSet)Session["cardsys"];
                }

                if (ds_card != null && ds_card.Tables[0].Rows.Count > 0)
                {

                    gridview_pardakhtcard.DataSource = ds_card.Tables[0];
                    gridview_pardakhtcard.DataBind();
                    panel1.Visible = true;
                  //  Label88.Text = "hiii";
                }
                else
                {
                    Label88.Text =  "error";
                    gridview_pardakhtcard.DataSource = null;
                    gridview_pardakhtcard.DataBind();
                }



            }



        }



    }

    protected void clkhesab1(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        paia db = new paia();
        bccif db1 = new bccif();
        bool res;
        string s_job =  "error";
        string s2 = Session["Login"].ToString();
        for (int i = 0; i < gridview_int1.Rows.Count; i++)
        {
            if ((Button)gridview_int1.Rows[i].FindControl("Button4") == sender)
            {

                Label l1 = (Label)gridview_int1.Rows[i].FindControl("Labell57");
                string sl1 = l1.Text;
                Label l2 = (Label)gridview_int1.Rows[i].FindControl("Label38");
                string dat1 = l2.Text;
                res = db1.writelog(s2, s_job, sl1);
                ds1 = db.fsorathesab(sl1, dat1, dat1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
        
                    Session["sorathesab"] = ds1;
                    Response.Redirect("bankstatement.aspx");


                }
                else
                {
                     Label56.Text =  "error";

                }
            }

        }

    }
    protected void clkhesab2(object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        paia db = new paia();
        bccif db1 = new bccif();
        bool res;
        string s_job = "صورت حساب";
        string s2 = Session["Login"].ToString();
        for (int i = 0; i < gridview_int2.Rows.Count; i++)
        {
            if ((Button)gridview_int2.Rows[i].FindControl("Button5") == sender)
            {

                Label l1 = (Label)gridview_int2.Rows[i].FindControl("Label159");
               string sl1 = l1.Text;
                Label l2 = (Label)gridview_int2.Rows[i].FindControl("Label71");
                string dat1 = l2.Text;
                res = db1.writelog(s2, s_job, sl1);

                ds1 = db.fsorathesab(sl1, dat1, dat1);
                //    res = db.writelog(s2, s1, s);

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                 
                    Session["sorathesab"] = ds1;
                    Response.Redirect("bankstatement.aspx");


                }
                else
                {
                     Label63.Text =  "error";

                }
            }

        }

    }

    protected void clkhesab3 (object sender, EventArgs e)
    {
        DataSet ds1 = new DataSet();
        paia db = new paia();
        bccif db1 = new bccif();
        bool res;
        string s_job =  "error";
        string s2 = Session["Login"].ToString();
        for (int i = 0; i < gridview_int3.Rows.Count; i++)
        {
            if ((Button)gridview_int3.Rows[i].FindControl("Button6") == sender)
            {

                Label l1 = (Label)gridview_int3.Rows[i].FindControl("Labellee");
                string sl1 = l1.Text;
                Label l2 = (Label)gridview_int3.Rows[i].FindControl("Label77");
                string dat1 = l2.Text;
                res = db1.writelog(s2, s_job, sl1);
                ds1 = db.fsorathesab(sl1, dat1, dat1);

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    Session["sorathesab"] = ds1;
                    Response.Redirect("bankstatement.aspx");

                }
                else
                {
                     Label69.Text = "error";

                }
            }

        }

    }



    protected void soratcard(object sender, EventArgs e)
    {

        multuview1.ActiveViewIndex = 4;
        DataSet ds_cardsorat = new DataSet();
        DataSet ds_cardhesab = new DataSet();
        paia db_cardsorat = new paia();
        bccif db1 = new bccif();
        bool res;
        string s_job = "صورت حساب";
        string s2 = Session["Login"].ToString();


        string sl5 = Label82.Text;
        ds_cardhesab = db_cardsorat.cardhesab(sl5);
        if (ds_cardhesab != null && ds_cardhesab.Tables[0].Rows.Count > 0)
        {
            string hes = ds_cardhesab.Tables[0].Rows[0]["hesab"].ToString();
            Session["hesab"] = hes;
            for (int i = 0; i < gridview_pardakhtcard.Rows.Count; i++)
            {
                if ((Button)gridview_pardakhtcard.Rows[i].FindControl("Button9") == sender)
                {
                    Label l5 = (Label)gridview_pardakhtcard.Rows[i].FindControl("Label52");
                    string sl6 = l5.Text;
                    res = db1.writelog(s2, s_job, hes);
                    string dat1 = String.Format("{0:yy/MM/dd}", sl6).Substring(2);
                    ds_cardsorat = db_cardsorat.fsorathesab(hes, dat1, dat1);
                    if (ds_cardsorat != null && ds_cardsorat.Tables[0].Rows.Count > 0)
                    {
                        Session["sorathesab"] = ds_cardsorat;
                        Response.Redirect("bankstatement.aspx");
                    }
                    else
                    {
                        Label88.Text =  "error";
                    }

                }

            }
        }

        else
        {
           
        }
    }


    protected void clkkhesabhad(object sender, EventArgs e)
    {

        DataSet ds1 = new DataSet();
        paia db = new paia();
        bccif db1 = new bccif();
        bool res;
        string s_job =  "error";
        string s2 = Session["Login"].ToString();

        for (int i = 0; i < gridview_khadamat.Rows.Count; i++)
        {
            if ((Button)gridview_khadamat.Rows[i].FindControl("btkhadamat") == sender)
            {

                Label l1 = (Label)gridview_khadamat.Rows[i].FindControl("Label98");
                string sl1 = l1.Text;
                res = db1.writelog(s2, s_job, sl1);
                Label l2 = (Label)gridview_khadamat.Rows[i].FindControl("Label39");
                string sl6 = l2.Text;
                string dat1 = String.Format("{0:yy/MM/dd}", sl6).Substring(2);
                ds1 = db.fsorathesab(sl1, dat1, dat1);
                //    res = db.writelog(s2, s1, s);

                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                  
                    Response.Redirect("bankstatement.aspx");


                }
                else
                {
                     Label56.Text =  "error";

                }
            }

        }





    }

    protected void clk2(object sender, EventArgs e)
    {
        Session["Login"] = null;
        Response.Redirect("login.aspx");
    }

    protected void pagefirs(object sender, EventArgs e)
    {
        multuview1.ActiveViewIndex = 1;

        DataSet ds_int1 = new DataSet();
        int_bank db_int = new int_bank();
        string dat1 = TextBox2.Text;
        string dat2 = TextBox7.Text;

        string dat11_m = dat1.Replace("/", "");
        string dat21_m = dat2.Replace("/", "");
        string s = Session["ID"].ToString();

        if (Session["int1"] == null || (Session["dat1_int1"].ToString() != TextBox2.Text) || (Session["dat2_int1"].ToString() != TextBox7.Text))
        {
           ds_int1 = db_int.smallest_archive(s, dat11_m, dat21_m);
            //ds_int1 = db_int.main_archive(s, dat11_m, dat21_m);
            Session["int1"] = ds_int1;
            Session["dat1_int1"] = TextBox2.Text;
            Session["dat2_int1"] = TextBox7.Text;

        }
        else if ((Session["int1"] != null) && (Session["dat1_int1"].ToString() == TextBox2.Text) && Session["dat2_int1"].ToString() == TextBox7.Text)
        {
            ds_int1 = (DataSet)Session["int1"];
        }

        if (ds_int1 != null && ds_int1.Tables[0].Rows.Count > 0)
        {
            gridview_int1.DataSource = ds_int1.Tables[0];
            gridview_int1.DataBind();
            Button3.Visible = true;
        }
        else
        {
            gridview_int1.DataSource = null;
            gridview_int1.DataBind();
            Label56.Text = "error";
        }

    }
    protected void pagesec(object sender, EventArgs e)
    {
        multuview1.ActiveViewIndex = 2;
        Button11.Visible = true;
        Button3.Visible = true;

        DataSet ds_int2 = new DataSet();
        int_bank db_int = new int_bank();
        string dat1 = TextBox2.Text;
        string dat2 = TextBox7.Text;

        string dat11_m = dat1.Replace("/", "");
        string dat21_m = dat2.Replace("/", "");
        string s = Session["ID"].ToString();

        if (Session["int2"] == null || (Session["dat1_int2"].ToString() != TextBox2.Text) || (Session["dat2_int2"].ToString() != TextBox7.Text))
        {
            ds_int2 = db_int.smaller_archive(s, dat11_m, dat21_m);
            Session["int2"] = ds_int2;
            Session["dat1_int2"] = TextBox2.Text;
            Session["dat2_int2"] = TextBox7.Text;

        }
        else if ((Session["int2"] != null) && (Session["dat1_int2"].ToString() == TextBox2.Text) && Session["dat2_int2"].ToString() == TextBox7.Text)
        {
            ds_int2 = (DataSet)Session["int2"];
        }

        if (ds_int2 != null && ds_int2.Tables[0].Rows.Count > 0)
        {
            gridview_int2.DataSource = ds_int2.Tables[0];
            gridview_int2.DataBind();
            Button3.Visible = true;
        }
        else
        {
            gridview_int2.DataSource = null;
            gridview_int2.DataBind();
            Label63.Text =  "error";
        }

    }


    protected void pagethi(object sender, EventArgs e)
    {
        multuview1.ActiveViewIndex = 3;
        Button12.Visible = true;
        DataSet ds_int3 = new DataSet();
        int_bank db_int = new int_bank();
        string dat1 = TextBox2.Text;
        string dat2 = TextBox7.Text;

        string dat11_m = dat1.Replace("/", "");
        string dat21_m = dat2.Replace("/", "");
        string s = Session["ID"].ToString();

        if (Session["int3"] == null || (Session["dat1_int3"].ToString() != TextBox2.Text) || (Session["dat2_int3"].ToString() != TextBox7.Text))
        {
            ds_int3 = db_int.biger_archive(s, dat11_m, dat21_m);
            Session["int3"] = ds_int3;
            Session["dat1_int3"] = TextBox2.Text;
            Session["dat2_int3"] = TextBox7.Text;


        }
        else if ((Session["int3"] != null) && (Session["dat1_int3"].ToString() == TextBox2.Text) && Session["dat2_int3"].ToString() == TextBox7.Text)
        {
            ds_int3 = (DataSet)Session["int3"];
        }

        if (ds_int3 != null && ds_int3.Tables[0].Rows.Count > 0)
        {
            gridview_int3.DataSource = ds_int3.Tables[0];
            gridview_int3.DataBind();
        }
        else
        {
            gridview_int3.DataSource = null;
            gridview_int3.DataBind();
            Label69.Text =  "error";
        }

    }


    protected void gridview_int1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        multuview1.ActiveViewIndex = 1;
        DataSet ds1 = new DataSet();
        ds1 = (DataSet)Session["int1"];
        gridview_int1.DataSource = ds1.Tables[0];
        gridview_int1.PageIndex = e.NewPageIndex;
        gridview_int1.DataBind();
    }
    protected void gridview_int2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        multuview1.ActiveViewIndex = 2;
        DataSet ds2 = new DataSet();
        ds2 = (DataSet)Session["int2"];
        gridview_int2.DataSource = ds2.Tables[0];
        gridview_int2.PageIndex = e.NewPageIndex;
        gridview_int2.DataBind();
    }
    protected void gridview_int3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        multuview1.ActiveViewIndex = 3;
        DataSet ds3 = new DataSet();
        ds3 = (DataSet)Session["int3"];
        gridview_int3.DataSource = ds3.Tables[0];
        gridview_int3.PageIndex = e.NewPageIndex;
        gridview_int3.DataBind();
    }

    protected void grid_khadamat(object sender, GridViewPageEventArgs e)
    {

        multuview1.ActiveViewIndex = 1;
        DataSet ds4 = new DataSet();
        ds4 = (DataSet)Session["paia"];
        gridview_khadamat.DataSource = ds4.Tables[0];
        gridview_khadamat.PageIndex = e.NewPageIndex;
        gridview_khadamat.DataBind();
    }
    protected void grid_card(object sender, GridViewPageEventArgs e)
    {

        multuview1.ActiveViewIndex = 4;
        DataSet ds5 = new DataSet();
        ds5 = (DataSet)Session["cardsys"];
        gridview_pardakhtcard.DataSource = ds5.Tables[0];
        gridview_pardakhtcard.PageIndex = e.NewPageIndex;
        gridview_pardakhtcard.DataBind();
    }



}





