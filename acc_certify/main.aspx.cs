using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        group_introduction db = new group_introduction();
        panel_reg_cheq.Visible = true;


     


    }

    protected void frm_load(object sender, EventArgs e)
    {

        // txt_serial.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        txt_from_seri.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");
        txt_ta_seri.Attributes.Add("onkeydown", "return KeyDownNumber(this,event)");

    }

    protected void clear_form()
    {

        drp_typ.ClearSelection();
        // txt_serial.Text = string.Empty;
        txt_from_seri.Text = string.Empty;
        txt_ta_seri.Text = string.Empty;
        lbl_result.Text = "";
        lbl_result.CssClass = "error";
        btn_bale.Visible = false;
        btn_kheir.Visible = false;

    }

    protected void reg_cheq(object sender, EventArgs e)
    {

        DataSet res = new DataSet();
        DataSet ds = new DataSet();
        string er = "";
        int status;


        string ch_typ = "";
        //string acc_typ = "";
        string serial = "";
        string from_seri;
        string ta_seri;
        string brcod;
        string usercod;
        long diff;

        from_seri = txt_from_seri.Text;
        ta_seri = txt_ta_seri.Text;
        long ta;
        long az;

        try
        {
            ta = Int64.Parse(txt_ta_seri.Text);
        }
        catch (Exception)
        {

            ta = 0;
        }

        try
        {
            az = Int64.Parse(txt_from_seri.Text);
        }
        catch (Exception)
        {

            az = 0;
        }



        diff = (ta - az) + 1;
        if (diff>1000) 
        {

            lbl_result.Text ="error";
            return;
        }
        else
        {
            lbl_result.Text = "error";
            btn_bale.Visible = true;
             btn_bale.Visible = true;
             btn_kheir.Visible = true;

        }
       

    }

    protected void clk_bale(object sender, EventArgs e)
    {
        DataSet res = new DataSet();
        DataSet ds = new DataSet();
        string er = "";
        int status;


        string ch_typ = "";
        //string acc_typ = "";
        string serial = "";
        string from_seri;
        string ta_seri;
        string brcod;
        string usercod;
        long diff;

        from_seri = txt_from_seri.Text;
        ta_seri = txt_ta_seri.Text;
        long ta;
        long az;

        try
        {
            ta = Int64.Parse(txt_ta_seri.Text);
        }
        catch (Exception)
        {

            ta = 0;
        }

        try
        {
            az = Int64.Parse(txt_from_seri.Text);
        }
        catch (Exception)
        {

            az = 0;
        }



        diff = (ta - az) + 1;
        switch (drp_typ.SelectedIndex)
        {
            case 0: ch_typ = "0";

                break;
            case 1: ch_typ = "1";
                break;
            default:
                break;
        }


        brcod = lbl_brcod.Text;
        usercod = lbl_usercod.Text;
        group_introduction db = new group_introduction();
        status = db.reg_sep(ch_typ, from_seri.ToString(), ta_seri.ToString(), lbl_brcod.Text, lbl_usercod.Text, out er);

        if (status == 0)
        {
            allocate_cheque(this, e);
            clear_form();
            lbl_result.Text = "error";

        }
        else if (status == 1)
        {
            clear_form();
            lbl_result.Text = "error";
        }


    }

    protected void clk_kheir(object sender, EventArgs e)
    {

        clear_form();
        
    }

    protected void allocate_cheque(object sender, EventArgs e)
    {

        lbl_show_res.Text = "";
        panel_view_cheques.Visible = true;

    }

    protected void drp_siz_ch(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string er = "";

        group_introduction db = new group_introduction();
        //  string s = drp_siz_show.SelectedValue.Trim();
        string s = "1";
        string s2 = "0";
        drp_kind.Items.Clear();
        DataSet ds1 = new DataSet();
        ds1 = db.fill_combo_ser1(lbl_brcod.Text.Trim(), out er);
      

      


    }

    protected void drp_kind_ch(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string er = "";

        group_introduction db = new group_introduction();
        //   string s = drp_siz_show.SelectedValue.Trim();
        string s = "1";
        string s1 = drp_kind.SelectedItem.ToString().Trim();
        string s2 = "201";
       

    }


    protected void view_chs(object sender, EventArgs e)
    {
        lbl_show_res.Text = string.Empty;
        gridviewcheques.DataSource = null;
        gridviewcheques.DataBind();

        grid_extract_cheq.DataSource = null;
        grid_extract_cheq.DataBind();

        DataSet ds = new DataSet();
        string er = "";
        string ch_typ = "";
        string serial = "0";

        group_introduction db = new group_introduction();

        switch (drp_kind.SelectedIndex)
        {
            case 0: ch_typ = "0";

                break;
            case 1: ch_typ = "1";
                break;
           

            default:
                break;
        }


        ds = db.fill_gridview(lbl_brcod.Text, ch_typ.ToString(),out er);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            gridviewcheques.DataSource = ds;
            gridviewcheques.DataBind();

          

        }


    }

    protected void gridviewcheques_delrow(object sender, GridViewDeleteEventArgs e)
    {

        bool res = new bool();
        group_introduction db = new group_introduction();
        string s = gridviewcheques.Rows[e.RowIndex].Cells[0].Text;
        res = db.del_row(s);
        if (res == true)
        {
            view_chs(this, e);
            lbl_show_res.Text = "error";
          //  drp_siz_ch(this, e);
        }
        else
        {
            lbl_show_res.Text = "error";
        }


    }

    protected void gridviewcheques_edt(object sender, EventArgs e)
    {
        grid_extract_cheq.DataSource = null;
        grid_extract_cheq.DataBind();

        DataSet ds = new DataSet();
        string er = "";

        group_introduction db = new group_introduction();
        ds = db.ext_cheq(gridviewcheques.SelectedRow.Cells[0].Text, out er);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            grid_extract_cheq.DataSource = ds;
            grid_extract_cheq.DataBind();
            Session["ds_ch"] = ds;
            for (int k = 0; k < grid_extract_cheq.Rows.Count; k++)
            {

                switch (ds.Tables[0].Rows[k]["allocate"].ToString().Trim())
                {

                    case "0":
                        grid_extract_cheq.Rows[k].Cells[2].Text ="error";
                        break;

                    case "1":
                        grid_extract_cheq.Rows[k].Cells[2].Text = "error";
                        break;


                    default:
                        break;
                }



            }


        }
    }

    protected void grid_extract_cheq_edt(object sender, EventArgs e)
    {
        panel_allocate.Visible = true;
        refresh_allocated();

    }

    protected void linkclk(object sender, EventArgs e)
    {
        lbl_showname.Text = string.Empty;
        DataSet ds = new DataSet();
        string er = "";
        group_introduction db = new group_introduction();
        string s = txtlast.Text.Trim() + "-" + txtmid.Text.Trim() + "-" + txtfirst.Text.Trim();
        ds = db.findcustid_hesab(s, out er);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {

            lbl_showname.Text = ds.Tables[0].Rows[0]["tdtitle"].ToString();
        }
        else
        {
            lbl_showname.Text = "error";
        }

        lbl_reg_acnt.Text = string.Empty;
    }

    protected void clkreg_acnt(object sender, EventArgs e)
    {

        DataSet res = new DataSet();
        string er = "";
        group_introduction db = new group_introduction();
        string s = txtlast.Text.Trim() + "-" + txtmid.Text.Trim() + "-" + txtfirst.Text.Trim();

        res = db.findcustid_hesab(s, out er);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {

            lbl_showname.Text = res.Tables[0].Rows[0]["tdtitle"].ToString();
        }
        else
        {
            lbl_showname.Text = "error";
            lbl_reg_acnt.Text = string.Empty;
            return;
        }



        DataSet ds = new DataSet();
        int status;
        s = txtlast.Text.Trim() + "-" + txtmid.Text.Trim() + "-" + txtfirst.Text.Trim();
        ds = db.link_per_ch(grid_extract_cheq.SelectedRow.Cells[0].Text, s, lbl_showname.Text.Trim(), out er, out status);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {
                clear_form_reg_acnt();
                lbl_reg_acnt.Text = "error";
                refresh_allocated();

            }
            else if (status == 1)
            {
                clear_form_reg_acnt();
                lbl_reg_acnt.Text = "error";
            }

        }

        else
        {
            clear_form_reg_acnt();
            lbl_reg_acnt.Text = "error";
        }

    }


    private void clear_form_reg_acnt()
    {
        txtlast.Text = string.Empty;
        txtmid.Text = string.Empty;
        txtfirst.Text = string.Empty;
        lbl_showname.Text = string.Empty;
    }

    private void refresh_allocated()
    {
        DataSet ds = new DataSet();
        string er = "";
        int status;
        group_introduction db = new group_introduction();
        ds = db.show_allocatd(lbl_brcod.Text, out er);
        gr_allocatd.DataSource = ds;
        gr_allocatd.DataBind();
        Session["allocated"] = ds;

        for (int k = 0; k < gr_allocatd.Rows.Count; k++)
        {

            switch (ds.Tables[0].Rows[k]["typ"].ToString().Trim())
            {

                case "0":
                  
                        gr_allocatd.Rows[k].Cells[1].Text = "error";
              
                    break;

                case "1":
                    gr_allocatd.Rows[k].Cells[1].Text = "error";
                    break;


                default:
                    break;
            }



        }


    }

    protected void gr_allocatd_delrow(object sender, GridViewDeleteEventArgs e)
    {

        bool res = new bool();
        group_introduction db = new group_introduction();
        string s = gr_allocatd.Rows[e.RowIndex].Cells[0].Text;
        res = db.del_row_allocated(s);
        if (res == true)
        {
            refresh_allocated();
            lbl_reg_acnt.Text = "error";

        }



    }

    protected void grid_extract_cheq_paging(object sender, GridViewPageEventArgs e)
    {

        DataSet ds1 = new DataSet();
        ds1 = (DataSet)Session["ds_ch"];
        grid_extract_cheq.DataSource = ds1.Tables[0];
        grid_extract_cheq.PageIndex = e.NewPageIndex;
        grid_extract_cheq.DataBind();
    }

    protected void gr_allocatd_paging(object sender, GridViewPageEventArgs e)
    {
         DataSet ds1 = new DataSet();
        ds1 = (DataSet)Session["allocated"];
        gr_allocatd.DataSource = ds1.Tables[0];
        gr_allocatd.PageIndex = e.NewPageIndex;
        gr_allocatd.DataBind();
    }



}

