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
       


    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        switch (TreeView1.SelectedNode.Value)
        {
            case "hagh": gri_hagh(this, e);
                break;
            case "hogh": gri_hogh(this, e);
                break;
            case "subgr":
                sub_gri(this, e);
                break;

            case "ashkhasmortabet":
                ashkhasmortabet(this, e);
                break;

            case "viraiesh":
                viraiesh(this, e);
                break;

            case "sabtid":
                sabtcustid(this, e);
                break;
            case "jad1":
                jad1 (this, e);
                break;

            case "khorooj":
                kharej(this, e);
                break;

        }
    }

    //khorooj
    protected void kharej(object sender, EventArgs e)
    {

        Session["Login"] = null;
        Response.Redirect("login.aspx");

    }

    //grouphaghighi
    protected void chdrop1(object sender, EventArgs e)
    {

        switch (Dropiscust.SelectedIndex)
        {
            case 1: Textcustidhagh.Visible = false;


                break;

            case 0: Textcustidhagh.Visible = true;

                break;
        }


    }

    protected void gri_hagh(object sender, EventArgs e)
    {
        newgrhagh(this, e);
        MultiView1.ActiveViewIndex = 0;
        switch (Dropiscust.SelectedIndex)
        {
            case 1: Textcustidhagh.Visible = false;


                break;

            case 0: Textcustidhagh.Visible = true;

                break;
        }

    }

    protected void clk1save(object sender, EventArgs e)
    {
        Label108.Visible = false;
        if (Textgrnam.Text=="" )
        {
            Label108.Visible = true;
            return;
          //  newgrhagh(this, e);
        }
        DataSet res = new DataSet();
        string er = "";
        int status;

        string grname = Textgrnam.Text;
        string cust_id = Textcustidsub.Text;
        string name = Texthaghname.Text;
        string family = Texthaghfamilyname.Text;
        string bc = Texthaghid.Text;
        string father = Texthaghpedar.Text;
        string plc = Texthaghbc.Text;
        string nationalcode = Texthaghcodmeli.Text;
        Textcustidhagh.Enabled = true;
        if (cust_id == "")
        {
            cust_id = "0";
        }

        group_introduction db = new group_introduction();
        res = db.group_hagh(grname, cust_id, name, family, bc, father, plc, nationalcode, out er, out status);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {

                Label53.Text = res.Tables[0].Rows[0]["group_cod"].ToString();
                Label54.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                grcomplete.Visible = true;
                // sabtcustidhagh.Visible = true;
            }

            else if (status == 1)
            {
                Label36.Text = "error";
                Label36.Visible = true;
                Label87.Visible = true;
                Label10.Visible = true;
                Label10.Text = res.Tables[0].Rows[0]["group_name"].ToString();

            }
        }

        else
        {

            Label36.Text = "error";
            Label36.Visible = true;
            Label87.Visible = true;
            Label10.Visible = true;

        }


    }

    protected void clk1_baziabi(object sender, EventArgs e)
    {
        Label36.Text = "";
        grinthagh.Visible = true;
      
        string cust_id = Textcustidhagh.Text;
        //Textcustidhagh.Enabled = false;
        iscust db = new iscust();
        DataSet ds = new DataSet();
        ds = db.findcust_hagh(cust_id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            Texthaghname.Text = ds.Tables[0].Rows[0]["bc_nam"].ToString();
            Texthaghfamilyname.Text = ds.Tables[0].Rows[0]["bc_family"].ToString();
            Texthaghid.Text = ds.Tables[0].Rows[0]["bc_id"].ToString();
            Texthaghpedar.Text = ds.Tables[0].Rows[0]["bc_pedar"].ToString();
            Texthaghbc.Text = ds.Tables[0].Rows[0]["bc_plc"].ToString();
            Texthaghcodmeli.Text = ds.Tables[0].Rows[0]["bc_codmelli"].ToString();

        }
        else if (Dropiscust.SelectedIndex == 1)
        {

        }

        else if (Dropiscust.SelectedIndex == 0 && ds == null)
        {
            Label36.Text = "مشتری موردنظر یافت نشد";
            Textcustidsub.Text = "";

        }

    }
    protected void sabtcustidhaghigh(object sender, EventArgs e)
    {
        group_introduction db = new group_introduction();
        DataSet ds = new DataSet();
        int status;
        string err = "";
        string cust_id = TextBox38.Text;
        string grcod = Label51.Text;
        ds = db.sabtidhagh(cust_id, grcod, out err, out status);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {

            }

            else if (status == 1)
            {


            }
        }


    }

    protected void sabtcustidhogh(object sender, EventArgs e)
    {
        group_introduction db = new group_introduction();
        DataSet ds = new DataSet();
        int status = 0;
        string err = "";
        //string cust_id = TextBox38.Text;
        //string grcod = Label51.Text;
        // ds = db.sabtidhogh(cust_id, grcod, out err, out status);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {

            }

            else if (status == 1)
            {


            }
        }


    }

    protected void newgrhagh(object sender, EventArgs e)
    {
        Textcustidhagh.Enabled = true;
        Textgrnam.Text = "";
        Textcustidhagh.Text = "";
        Texthaghname.Text = "";
        Texthaghfamilyname.Text = "";
        Texthaghid.Text = "";
        Texthaghpedar.Text = "";
        Texthaghbc.Text = "";
        Texthaghcodmeli.Text = "";
        Label36.Visible = false;
        Label10.Text = "";
        Label10.Visible = false;
        Label87.Visible = false;
        grinthagh.Visible = false;
        grcomplete.Visible = false;
        sabtcustidhagh.Visible = false;
        Label108.Visible = false;

    }




    //grouphoghoghi
    protected void gri_hogh(object sender, EventArgs e)
    {
        newgrhogh(this, e);
        MultiView1.ActiveViewIndex = 1;
        switch (DropDownList2.SelectedIndex)
        {
            case 1: TextBox12.Visible = false;


                break;

            case 0: TextBox12.Visible = true;

                break;
        }


    }

    protected void newgrhogh(object sender, EventArgs e)
    {
        TextBox11.Text = "";
        TextBox12.Enabled = true;
        TextBox12.Text = "";
        TextBox13.Text = "";
        TextBox14.Text = "";
        TextBox15.Text = "";
        TextBox16.Text = "";
        TextBox17.Text = "";
        TextBox18.Text = "";
        TextBox19.Text = "";
        grinthogh.Visible = false;
        grcompletehogh.Visible = false;
        Label114.Visible = false;
        Label111.Visible = false;
        Label112.Visible = false;
        Label113.Visible = false;
    }

    protected void chdrop2(object sender, EventArgs e)
    {

        switch (DropDownList2.SelectedIndex)
        {
            case 1: TextBox12.Visible = false;


                break;

            case 0: TextBox12.Visible = true;

                break;
        }
    }

    protected void clk2save(object sender, EventArgs e)
    {
        Label111.Visible = false;
        Label112.Visible = false;
        Label113.Visible = false;
        Label114.Visible = false;
       
        if (TextBox11.Text == "")
        {
            Label114.Visible = true;
            return;
            //  newgrhagh(this, e);
        }
        Label114.Visible = false;
        DataSet res = new DataSet();
        int status;
        string er = "";
        string grname = TextBox11.Text;
        string cust_id = TextBox12.Text;
        string name = TextBox13.Text;
        string sabt = TextBox14.Text;
        string dat = TextBox15.Text;
        string plc = TextBox16.Text;
        string kind = TextBox17.Text;
        string center = TextBox18.Text;
        string cod = TextBox19.Text;
        TextBox12.Enabled = true;
        if (cust_id == "")
        {
            cust_id = "0";
        }

        group_introduction db = new group_introduction();
        res = db.group_hogh(grname, cust_id, name, sabt, dat, plc, kind, center, cod, out er, out status);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {
                Label58.Text = res.Tables[0].Rows[0]["group_cod"].ToString();
                Label59.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                grcompletehogh.Visible = true;
            }

            else if (status == 1)
            {
                Label111.Text ="error";
                Label111.Visible = true;
                Label113.Visible = true;
                Label112.Visible = true;
                Label112.Text = res.Tables[0].Rows[0]["group_name"].ToString();

                // Label11.Text = "امکان تعریف گروه با چنین مشخصاتی وجود ندارد";
                //Label11.Text = er;

            }
        }
        else
        {
            Label111.Text ="error";
            Label111.Visible = true;
            Label113.Visible = true;
            Label112.Visible = true;

        }

    }

    protected void clk2_baziabi(object sender, EventArgs e)
    {
        Label11.Text = "";
        grinthogh.Visible = true;
       
        string cust_id = TextBox12.Text;
        TextBox12.Enabled = false;
        iscust db = new iscust();
        DataSet ds = new DataSet();
        ds = db.findcust_hogh(cust_id);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            TextBox13.Text = ds.Tables[0].Rows[0]["name"].ToString();
            TextBox14.Text = ds.Tables[0].Rows[0]["sabt"].ToString();
            TextBox15.Text = ds.Tables[0].Rows[0]["dat_sabt"].ToString();
            TextBox16.Text = ds.Tables[0].Rows[0]["bc_plc"].ToString();
            TextBox17.Text = ds.Tables[0].Rows[0]["kind"].ToString();
            TextBox18.Text = ds.Tables[0].Rows[0]["adrs"].ToString();
            TextBox19.Text = ds.Tables[0].Rows[0]["bicod"].ToString();



        }
        else if (DropDownList2.SelectedIndex == 1)
        {

        }

        else if (DropDownList2.SelectedIndex == 0 && ds == null)
        {
            Label11.Text = "error";
            TextBox12.Text = "";
        }

    }







    //subgroup

    protected void sub_gri(object sender, EventArgs e)
    {
        confsub_gr.Visible = true;
        Session["mode"] = 1;
        labelcaption_total.Text = "error";


        confsub_gr.Visible = false;
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        mortabetrelation.Visible = false;
        confsabtid.Visible = false;
        sabtid.Visible = false;
        relationpanel.Visible = false;
        Panelmortabetcof.Visible = false;
        panelreport.Visible = false;

        Label101.Visible = false;
        Label102.Visible = false;
        Label109.Visible = false;
        newsubgrhagh(this, e);
        newsubgrhogh(this, e);

        DataSet res = new DataSet();
        DataSet res_subgr = new DataSet();
        group_introduction db = new group_introduction();
        string er;



        res = db.fill_combo_gr(out er);
        DropDownList3.DataSource = res.Tables[0];
        DropDownList3.DataTextField = "group_name";
        DropDownList3.DataValueField = "group_cod";
        DropDownList3.DataBind();
        if (res.Tables[0].Rows.Count > 0)
        {
            Bind();

            res = db.fill_combo_relation(out er);
            DropDownList4.DataSource = res.Tables[0];
            DropDownList4.DataTextField = "re_desc";
            DropDownList4.DataValueField = "relation_cod";
            DropDownList4.DataBind();

            string s1 = "1";
            res = db.fill_combo_sub_relation(s1, out er);
            DropDownList5.DataSource = res.Tables[0];
            DropDownList5.DataTextField = "subre_desc";
            DropDownList5.DataValueField = "subrelation_cod";
            DropDownList5.DataBind();
            relationpanel.Visible = true;
            confsub_gr.Visible = true;

            MultiView1.ActiveViewIndex = 2;

            Label75.Text = DropDownList3.SelectedItem.ToString();
            Label104.Text = DropDownList3.SelectedItem.ToString();
            Label981.Text = DropDownList3.SelectedItem.ToString();
            Label77.Text = DropDownList4.SelectedItem.ToString();
            Label79.Text = DropDownList5.SelectedItem.ToString();


        }
        else
        {

            return;
            


        }


       

    }

    public void Bind()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
        string s = DropDownList3.SelectedItem.Value;
        ds = db.find_grcod(s, out er);
        if (TreeViewsubgr.SelectedValue != null)
        {
            Label1.Text = TreeViewsubgr.SelectedValue.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    TreeNode no = new TreeNode();
                    no.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    no.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    no.PopulateOnDemand = true;
                    no.SelectAction = TreeNodeSelectAction.SelectExpand;
                    no.ChildNodes.Add(no);
                    this.TreeViewsubgr.Nodes.Add(no);

                }

            }
            else
            {


            }
        }
        else
        {

        }
    }

    protected void treeView1_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {


        if (e.Node.ChildNodes.Count == 0)
        {

            getchild(e.Node);

        }
    }


    protected void trexpand(object sender, TreeNodeEventArgs e)
    {




   if (e.Node.ChildNodes.Count == 0)
        {

    
            getchild(e.Node);

        }


    }


    protected void trch(object sender, EventArgs e)
    {

     
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        Label75.Text = TreeViewsubgr.SelectedNode.Text;
        Label104.Text = TreeViewsubgr.SelectedNode.Text;
       Label981.Text = TreeViewsubgr.SelectedNode.Text;
       Label115.Text = TreeViewsubgr.SelectedNode.Text;

        subgrcomplete.Visible = false;
        // mortabetrelation.Visible = false;
        if ((int)Session["mode"] == 1)
        {
            confsub_gr.Visible = true;
            relationpanel.Visible = true;
          
        }

        else if ((int)Session["mode"] == 2)
        {
            mortabetrelation.Visible = true;
            Panelmortabetcof.Visible = true;
           
        }

        else if ((int)Session["mode"] == 3)
        {

            confsabtid.Visible = true;
            sabtid.Visible = false;
            
           
        }
        else if ((int)Session["mode"] == 3)
        {

            relationpanel.Visible = true;

        }

        else if ((int)Session["mode"] == 4)
        {

            panelreport.Visible = true;

        }




    }

    private void getchild(TreeNode node)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
        if (node.Value == "")
        {


        }


        else if (node != null)
        {

            ds = db.find_grcod(node.Value.ToString(), out er);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode NewNode = new TreeNode();
                    NewNode.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    NewNode.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    NewNode.PopulateOnDemand = true;
                    node.ChildNodes.Add(NewNode);
                    //NewNode.SelectAction = TreeNodeSelectAction.SelectExpand;
                    
                }

            }
            else
            {

            }


        }

    }

       

    protected void drop4ch(object sender, EventArgs e)
    {
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er;
        string s = "";

        switch (DropDownList4.SelectedIndex)
        {
            case 0: s = "1";
                break;
            case 1: s = "2";
                break;
            case 2: s = "3";
                break;
        }

        res = db.fill_combo_sub_relation(s, out er);
        DropDownList5.DataSource = res.Tables[0];
        DropDownList5.DataTextField = "subre_desc";
        DropDownList5.DataValueField = "subrelation_cod";
        DropDownList5.DataBind();

        Label77.Text = DropDownList4.SelectedItem.ToString();
        Label79.Text = DropDownList5.SelectedItem.ToString();
        subgrcomplete.Visible = false;
        confsub_gr.Visible = true;


    }

    protected void drop3ch(object sender, EventArgs e)
    {
        //confsabtid.Visible = true;
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        

        TreeViewsubgr.Nodes.Clear();

        Bind();

        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er;
        string s = "";

        switch (DropDownList4.SelectedIndex)
        {
            case 0: s = "1";
                break;
            case 1: s = "2";
                break;
            case 2: s = "3";
                break;
        }

        res = db.fill_combo_sub_relation(s, out er);
        DropDownList5.DataSource = res.Tables[0];
        DropDownList5.DataTextField = "subre_desc";
        DropDownList5.DataValueField = "subrelation_cod";
        DropDownList5.DataBind();

        Label75.Text = DropDownList3.SelectedItem.ToString();
        Label104.Text = DropDownList3.SelectedItem.ToString();
        Label981.Text = DropDownList3.SelectedItem.ToString();
        Label77.Text = DropDownList4.SelectedItem.ToString();
        Label79.Text = DropDownList5.SelectedItem.ToString();
       

        if ((int)Session["mode"] == 1)
        {
            confsub_gr.Visible = true;
            relationpanel.Visible = true;
        }
        else if ((int)Session["mode"] == 2)
        {
          //  Panelmortabetcof.Visible = true;
            mortabetrelation.Visible = true;
            Panelmortabetcof.Visible = true;
        }


        else if ((int)Session["mode"] == 3)
        {

            confsabtid.Visible = true;
            sabtid.Visible = false;
        }
        else if ((int)Session["mode"] == 4)
        {

            panelreport.Visible = true;

        }



    }

    protected void dropsgrch(object sender, EventArgs e)
    {

        
        subgrcomplete.Visible = false;
        confsub_gr.Visible = true;
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er;
        string s = "";

        switch (DropDownList4.SelectedIndex)
        {
            case 0: s = "1";
                break;
            case 1: s = "2";
                break;
            case 2: s = "3";
                break;
        }

        res = db.fill_combo_sub_relation(s, out er);
        DropDownList5.DataSource = res.Tables[0];
        DropDownList5.DataTextField = "subre_desc";
        DropDownList5.DataValueField = "subrelation_cod";
        DropDownList5.DataBind();

        Label104.Text = TreeViewsubgr.SelectedValue.ToString();
        Label75.Text = TreeViewsubgr.SelectedValue.ToString();
        Label77.Text = DropDownList4.SelectedItem.ToString();
        Label79.Text = DropDownList5.SelectedItem.ToString();
    }

    protected void drop5ch(object sender, EventArgs e)
    {
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        confsub_gr.Visible = true;
        Label77.Text = DropDownList4.SelectedItem.ToString();
        Label79.Text = DropDownList5.SelectedItem.ToString();
    }

    protected void sub_baleh(object sender, EventArgs e)
    {
       // newsubgrhagh(this,e);

        confsub_gr.Visible = false;
        Label101.Visible = false;
        Label102.Visible = false;
        Label109.Visible = false;
        TextBox26.Text = "";
        TextBox27.Text = "";
        TextBox28.Text = "";
        TextBox29.Text = "";
        TextBox30.Text = "";
        TextBox31.Text = "";
        TextBox1.Text = "";
        Labelerrhogh.Text = "";
        Textcustidhogh.Text = "";


        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        TextBox23.Text = "";
        TextBox24.Text = "";
        TextBox25.Text = "";
        TextBox28.Text = "";
        Labelerr.Text = "";
        Textcustidsub.Text = "";
        sahmtext.Visible = false;
        sahmprc.Visible = false;
        sahmtext_hogh.Visible = false;
        sahmprc_hogh.Visible = false;

        if ((int)Session["mode"] == 1)
        {
            panelsubgr.Visible = true;
            panelsubgr1.Visible = true;
            subgriscusthagh.Visible = true;
            subgriscusthogh.Visible = true;
            labelcaption_hagh.Text ="error";
            labelcaption_hogh.Text ="error";
        
        }
        else if ((int)Session["mode"] == 2)
        {
            panelsubgr1.Visible = false;
            panelsubgr.Visible = true;
            subgriscusthogh.Visible = false;
            labelcaption_hagh.Text  ="error";
            sahmtext.Visible = true;
            sahmprc.Visible = true;
       
            switch (DropDownList8.SelectedIndex)
            {
                case 4: panelsubgr1.Visible = true;
                    subgriscusthogh.Visible = true;
                    labelcaption_hogh.Text = "error";
                    sahmtext_hogh.Visible = true;
                     sahmprc_hogh.Visible = true;
                    break;
                case 5: panelsubgr1.Visible = true;
                    subgriscusthogh.Visible = true;
                    labelcaption_hogh.Text = "error";
                      sahmtext_hogh.Visible = true;
                     sahmprc_hogh.Visible = true;
                    break;
               
            }


            subgriscusthagh.Visible = true;
            Panelmortabetcof.Visible = false;
           

        }



        subgrcomplete.Visible = false;
        Textcustidsub.Enabled = true;
        Button3.Enabled = true;
        DropDownList6.Enabled = true;
        Textcustidhogh.Enabled = true;
        Button11.Enabled = true;
        DropDownList7.Enabled = true;

        switch (DropDownList6.SelectedIndex)
        {
           
            case 1: Textcustidsub.Visible = false;


                break;

            case 0: Textcustidsub.Visible = true;

                break;
        }


        switch (DropDownList7.SelectedIndex)
        {
            case 1: Textcustidhogh.Visible = false;


                break;

            case 0: Textcustidhogh.Visible = true;

                break;
        }

    }

    protected void drp6ch(object sender, EventArgs e)
    {
        //Panelmortabetcof.Visible = true;

        switch (DropDownList6.SelectedIndex)
        {
            case 1: Textcustidsub.Visible = false;


                break;

            case 0: Textcustidsub.Visible = true;

                break;
        }
        subgrcomplete.Visible = false;
        confsub_gr.Visible = true;
    }

    protected void drp7ch(object sender, EventArgs e)
    {
        //Panelmortabetcof.Visible = true;
        switch (DropDownList7.SelectedIndex)
        {
            case 1: Textcustidhogh.Visible = false;


                break;

            case 0: Textcustidhogh.Visible = true;

                break;
        }
        subgrcomplete.Visible = false;
        confsub_gr.Visible = true;
    }

    protected void clk3_baziabi(object sender, EventArgs e)
    {
       
        subgrinthagh.Visible = true;
        switch (DropDownList6.SelectedIndex)
        {
            case 1: Textcustidsub.Visible = false;
                Labelerr.Text = "";
                break;

            case 0: Textcustidsub.Visible = true;


                 string cust_id = Textcustidsub.Text;
        // 
        iscust db = new iscust();
        DataSet ds = new DataSet();
        ds = db.findcust_hagh(cust_id);
        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {
            TextBox20.Text = ds.Tables[0].Rows[0]["bc_nam"].ToString();
            TextBox21.Text = ds.Tables[0].Rows[0]["bc_family"].ToString();
            TextBox22.Text = ds.Tables[0].Rows[0]["bc_id"].ToString();
            TextBox23.Text = ds.Tables[0].Rows[0]["bc_pedar"].ToString();
            TextBox24.Text = ds.Tables[0].Rows[0]["bc_plc"].ToString();
            TextBox25.Text = ds.Tables[0].Rows[0]["bc_codmelli"].ToString();
            Labelerr.Text = "";
            //Textcustidsub.Enabled = false;
        }
        else 
        {
            Labelerr.Text = "error";
            Labelerr.Visible = true;
            Textcustidsub.Text = "";


        }

                break;
        }


       
       
    
       

    }

    protected void clk3save(object sender, EventArgs e)
    {
        DataSet res = new DataSet();
        DataSet ds_level = new DataSet();
        DataSet ds_stat = new DataSet();

        group_introduction db = new group_introduction();
        string er = "";
        int status;
        string err;
        string grcod = "";
        string level = "";
        if (TreeViewsubgr.SelectedValue.ToString() == "")
        {
            grcod = DropDownList3.SelectedValue;
            level = "1";
        }
        else
        {
            grcod = TreeViewsubgr.SelectedValue.ToString();
            ds_level = db.find_level(TreeViewsubgr.SelectedValue.ToString(), out err);
            string level1 = ds_level.Tables[0].Rows[0]["levels"].ToString();
            int level2 = Int32.Parse(level1) + 1;
            level = level2.ToString();
        }


        string relation_cod = DropDownList4.SelectedValue;
        string subrelation_cod = DropDownList5.SelectedValue;
        string mortabt = DropDownList8.SelectedValue;
        string cust_id = Textcustidsub.Text;
        string name = TextBox20.Text;
        string family = TextBox21.Text;
        string bc = TextBox22.Text;
        string father = TextBox23.Text;
        string plc = TextBox24.Text;
        string nationalcode = TextBox25.Text;
        string sahmprc = sahmtext.Text;
        Textcustidsub.Enabled = true;
        if (cust_id == "" || Textcustidsub.Visible == false)
        {
            cust_id = "0";
        }

        if ((int)Session["mode"] == 1)
        {
            res = db.sub_group_hagh(grcod, relation_cod, subrelation_cod, cust_id, name, family, bc, father, plc, nationalcode, level, out er, out status);

            if (res != null && res.Tables[0].Rows.Count > 0)
            {
                if (status == 0)
                {

                    Label86.Text = res.Tables[0].Rows[0]["group_cod"].ToString();
                    Label84.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                   subgrcomplete.Visible = true;
                    confsub_gr.Visible = false;
                    TextBox20.Text = "";
                    TextBox21.Text = "";
                    TextBox22.Text = "";
                    TextBox23.Text = "";
                    TextBox24.Text = "";
                    TextBox25.Text = "";
                    TextBox28.Text = "";
                    Labelerr.Text = "";
                    Textcustidsub.Text = "";
                    TreeViewsubgr.Nodes.Clear();
                    Bind();
                    Button27.Visible = true;
                    Button7.Visible = true;


                }
                else if (status == 1)
                {

                    Label101.Text = "error";
                    Label101.Visible = true;
                    Label102.Visible = true;
                    Label109.Visible = true;
                    Label102.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                    confsub_gr.Visible = true;

                    TextBox20.Text = "";
                    TextBox21.Text = "";
                    TextBox22.Text = "";
                    TextBox23.Text = "";
                    TextBox24.Text = "";
                    TextBox25.Text = "";
                    TextBox28.Text = "";
                    Textcustidsub.Text = "";
                    sub_gri(this, e);
                    Button27.Visible = true;
                    Button7.Visible = true;
                 
                }

            }
        }
        else if ((int)Session["mode"] == 2)
        {
            ds_stat = db.find_stat(grcod, out err);
            string stat1 = ds_stat.Tables[0].Rows[0]["stat"].ToString();
            int stat = Int32.Parse(stat1);
            if (stat == 1)
            {
                res = db.sabtmortabet(grcod, mortabt, cust_id, name, family, bc, father, plc, nationalcode,sahmprc, out er, out status);
                if (res != null && res.Tables[0].Rows.Count > 0)
                {
                    if (status == 0)
                    {
                        //Panelmortabetcof.Visible = false;
                        TextBox20.Text = "";
                        TextBox21.Text = "";
                        TextBox22.Text = "";
                        TextBox23.Text = "";
                        TextBox24.Text = "";
                        TextBox25.Text = "";
                        TextBox28.Text = "";
                        Labelerr.Text = "";
                        Textcustidsub.Text = "";

                    }
                    else if (status == 1)
                    {
                        Label101.Text ="error";
                        Label101.Visible = true;
                        Label102.Visible = true;
                        Label109.Visible = true;
                        Label102.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                       // sub_baleh(this, e);
                        confsub_gr.Visible = true;
                        TextBox20.Text = "";
                        TextBox21.Text = "";
                        TextBox22.Text = "";
                        TextBox23.Text = "";
                        TextBox24.Text = "";
                        TextBox25.Text = "";
                        TextBox28.Text = "";
                     

                    }

                }




            }
            else if (stat == 0)
            {

            }

        }


        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;

    }

    protected void clknewsubgr(object sender, EventArgs e)
    {
        sub_gri(this, e);

    }

    protected void newsubgrhagh(object sender, EventArgs e)
    {

        Label101.Visible = false;
        Label102.Visible = false;
        Label109.Visible = false;
        TreeViewsubgr.Nodes.Clear();
        
        Textcustidsub.Text = "";
        Textcustidsub.Enabled = false;
        Button3.Enabled = false;
        DropDownList6.Enabled = false;
        Textcustidhogh.Enabled = false;
        Button11.Enabled = false;
        DropDownList7.Enabled = false;
        TextBox20.Text = "";
        TextBox21.Text = "";
        TextBox22.Text = "";
        TextBox23.Text = "";
        TextBox24.Text = "";
        TextBox25.Text = "";
        TextBox28.Text = "";
        Labelerr.Text = "";
        confsub_gr.Visible = false;
        panelsubgr.Visible = false;
        subgrinthagh.Visible = false;
        mortabetrelation.Visible = false;
        Panelmortabetcof.Visible = false;
        sabtid.Visible = false;
        relationpanel.Visible = false;
        panelreport.Visible = false;
        Button27.Visible = false;
       

    }

    protected void clk4_baziabi(object sender, EventArgs e)
    {
        subgrinthogh.Visible = true;
        switch (DropDownList7.SelectedIndex)
        {
            case 1: Textcustidhogh.Visible = false;


                break;

            case 0: Textcustidhogh.Visible = true;

                 string cust_id = Textcustidhogh.Text;

        iscust db = new iscust();
        DataSet ds = new DataSet();
        ds = db.findcust_hogh(cust_id);

        if (ds != null && ds.Tables[0].Rows.Count > 0)
        {

            TextBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
            TextBox26.Text = ds.Tables[0].Rows[0]["sabt"].ToString();
            TextBox27.Text = ds.Tables[0].Rows[0]["dat_sabt"].ToString();
            TextBox28.Text = ds.Tables[0].Rows[0]["bc_plc"].ToString();
            TextBox29.Text = ds.Tables[0].Rows[0]["kind"].ToString();
            TextBox30.Text = ds.Tables[0].Rows[0]["adrs"].ToString();
            TextBox31.Text = ds.Tables[0].Rows[0]["bicod"].ToString();
            Labelerrhogh.Text = "";
        }

        else
              
        {
           
            Labelerrhogh.Text = "error";
            Labelerrhogh.Visible = true;
            Textcustidhogh.Text = "";

        }


                break;
          
        }


        }   

    protected void clk4save(object sender, EventArgs e)
    {
        DataSet ds_level = new DataSet();
        DataSet res = new DataSet();
        DataSet ds_stat=new DataSet();
        group_introduction db = new group_introduction();
        string er;
        string err;
        int status;
        string grcod = "";
        string level = "";
        if (TreeViewsubgr.SelectedValue.ToString() == "")
        {
            grcod = DropDownList3.SelectedValue;
            level = "1";
        }
        else
        {
            grcod = TreeViewsubgr.SelectedValue.ToString();
            ds_level = db.find_level(TreeViewsubgr.SelectedValue.ToString(), out err);
            string level1 = ds_level.Tables[0].Rows[0]["levels"].ToString();
            int level2 = Int32.Parse(level1) + 1;
            level = level2.ToString();
        }



        labelnamgr.Text = Label75.Text;
        string relation_cod = DropDownList4.SelectedValue;
        string subrelation_cod = DropDownList5.SelectedValue;
        string mortabet = DropDownList5.SelectedValue;
        string cust_id = Textcustidhogh.Text;
        string name = TextBox1.Text;
        string sabt = TextBox26.Text;
        string dat = TextBox27.Text;
        string plc = TextBox28.Text;
        string kind = TextBox29.Text;
        string center = TextBox30.Text;
        string cod = TextBox31.Text;
        string shamprc = sahmtext_hogh.Text;
           string mortabt = DropDownList8.SelectedValue;

        Textcustidhogh.Enabled = true;
        if (cust_id == "" || Textcustidhogh.Visible == false)
        {
            cust_id = "0";
        }
        if ((int)Session["mode"] == 1)
        {

            res = db.sub_group_hogh(grcod, relation_cod, subrelation_cod, cust_id, name, sabt, dat, plc, kind, center, cod, level, out er, out status);
            if (res != null && res.Tables[0].Rows.Count > 0)
            {
                if (status == 0)
                {

                    Label86.Text = res.Tables[0].Rows[0]["group_cod"].ToString();
                    Label84.Text = res.Tables[0].Rows[0]["name"].ToString();
                    subgrcomplete.Visible = true;
                    confsub_gr.Visible = false;
                    Session["subgr"] = res.Tables[0].Rows[0]["group_cod"].ToString();
                    TextBox26.Text = "";
                    TextBox27.Text = "";
                    TextBox28.Text = "";
                    TextBox29.Text = "";
                    TextBox30.Text = "";
                    TextBox31.Text = "";
                    TextBox1.Text = "";
                    Labelerrhogh.Text = "";
                    Textcustidhogh.Text = "";
                    TreeViewsubgr.Nodes.Clear();
                    Bind();
                    Button27.Visible = true;

                }
                else if (status == 1)
                {
                    Label101.Text = "error";
                    Label101.Visible = true;
                    Label102.Visible = true;
                    Label109.Visible = true;
                    Label102.Text = res.Tables[0].Rows[0]["name"].ToString();
                    confsub_gr.Visible = true;

                    TextBox26.Text = "";
                    TextBox27.Text = "";
                    TextBox28.Text = "";
                    TextBox29.Text = "";
                    TextBox30.Text = "";
                    TextBox31.Text = "";
                    TextBox1.Text = "";
                    Textcustidhogh.Text = "";
                    TreeViewsubgr.Nodes.Clear();
                    Bind();
                    Button27.Visible = true;


                }
            }
        }


        else if ((int)Session["mode"] == 2)
        {
            ds_stat = db.find_stat(grcod, out err);
            string stat1 = ds_stat.Tables[0].Rows[0]["stat"].ToString();
            int stat = Int32.Parse(stat1);
            if (stat == 1)
            {
                
        
         // res = db.sabtmortabet_hogh(grcod, mortabt, cust_id, name, sabt, dat, plc, kind, center, sahmprc, cod, out er, out status);
                status = 0;
                if (res != null && res.Tables[0].Rows.Count > 0)
                {
                    if (status == 0)
                    {

                        //  gridview3.DataSource = res.Tables[0];
                        //   gridview3.DataBind();

                        //Panelmortabetcof.Visible = false;
                        TextBox20.Text = "";
                        TextBox21.Text = "";
                        TextBox22.Text = "";
                        TextBox23.Text = "";
                        TextBox24.Text = "";
                        TextBox25.Text = "";
                        TextBox28.Text = "";
                        Labelerr.Text = "";
                        Textcustidsub.Text = "";

                    }
                    else if (status == 1)
                    {
                        Label101.Text = "error";
                        Label101.Visible = true;
                        Label102.Visible = true;
                        Label109.Visible = true;
                        Label102.Text = res.Tables[0].Rows[0]["group_name"].ToString();
                        // sub_baleh(this, e);
                        confsub_gr.Visible = true;
                        TextBox20.Text = "";
                        TextBox21.Text = "";
                        TextBox22.Text = "";
                        TextBox23.Text = "";
                        TextBox24.Text = "";
                        TextBox25.Text = "";
                        TextBox28.Text = "";
                        //Labelerr.Text = "error";
                        //Labelerr.Text = er;

                    }

                }


            }

        }
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
    }

    protected void newsubgrhogh(object sender, EventArgs e)
    {
        Label101.Visible = false;
        Label102.Visible = false;
        Label109.Visible = false;
        TreeViewsubgr.Nodes.Clear();
        DropDownList3.Enabled = true;
        relationpanel.Visible = false;
        Textcustidhogh.Text = "";
        Textcustidhogh.Enabled = false;
        Button11.Enabled = false;
        DropDownList7.Enabled = false;
        Textcustidsub.Enabled = false;
        Button3.Enabled = false;
        DropDownList6.Enabled = false;
        TextBox26.Text = "";
        TextBox27.Text = "";
        TextBox28.Text = "";
        TextBox29.Text = "";
        TextBox30.Text = "";
        TextBox31.Text = "";
        TextBox1.Text = "";
        Labelerrhogh.Text = "";
        confsub_gr.Visible = false;
        subgrinthogh.Visible = false;
        panelsubgr1.Visible = false;
        mortabetrelation.Visible = false;
        //Panelmortabetcof.Visible = false;
        sabtid.Visible = false;
        panelreport.Visible = false;
        //confsabtid.Visible = false;
        Button27.Visible = false;
    }
    protected void clklinkrel(object sender, EventArgs e)
    {

        ashkhasmortabet(this, e);
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er = "";

        res = db.findgr_relat(Label86.Text, out er);
        trch_mortabet(res.Tables[0].Rows[0]["group_name"].ToString(), res.Tables[0].Rows[0]["group_cod"].ToString(), Label84.Text);
       

    }







    //ashkhas mortabet


    protected void ashkhasmortabet(object sender, EventArgs e)
    {

        Session["mode"] = 2;
        confsub_gr.Visible = false;
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        relationpanel.Visible = false;
        confsabtid.Visible = false;
        labelcaption_total.Text = "error";


        newsubgrhagh(this, e);
        newsubgrhogh(this, e);


        mortabetrelation.Visible = true;
        Panelmortabetcof.Visible = true;
        DataSet res = new DataSet();
        DataSet res_mortabet = new DataSet();
        group_introduction db = new group_introduction();
        string er;

        res = db.fill_combo_gr(out er);
        DropDownList3.DataSource = res.Tables[0];
        DropDownList3.DataTextField = "group_name";
        DropDownList3.DataValueField = "group_cod";
        DropDownList3.DataBind();

        res_mortabet = db.fill_combo_mortabet(out er);
        DropDownList8.DataSource = res_mortabet.Tables[0];
        DropDownList8.DataTextField = "pers_desc";
        DropDownList8.DataValueField = "pers_cod";
        DropDownList8.DataBind();

        if (res.Tables[0].Rows.Count > 0)
        {
            Bind();

            MultiView1.ActiveViewIndex = 2;
            Label981.Text = DropDownList3.SelectedItem.ToString();
            Label100.Text = DropDownList8.SelectedItem.ToString();
        }

        else
        {
            return;
        }

    }
    protected void drop8ch(object sender, EventArgs e)
    {

        Label100.Text = DropDownList8.SelectedItem.ToString();
        subgrcomplete.Visible = false;
        Panelmortabetcof.Visible = true;
        panelsubgr.Visible = false;
    }
  
    protected void trch_mortabet(string s,string s2 ,string s1)
    {

        panelsubgr.Visible = false;
        DropDownList3.ClearSelection();
        DropDownList3.SelectedItem.Text = s;
        Label981.Text = s1;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
       

        ds = db.find_grcod(s2, out er);
        if (TreeViewsubgr.SelectedValue != null)
        {
            Label1.Text = TreeViewsubgr.SelectedValue.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    TreeNode no = new TreeNode();
                    no.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    no.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    no.PopulateOnDemand = true;
                    no.SelectAction = TreeNodeSelectAction.SelectExpand;
                    no.ChildNodes.Add(no);
                    this.TreeViewsubgr.Nodes.Add(no);

                }

            }
            else
            {


            }
        }
        else
        {

        }
     

        subgrcomplete.Visible = false;


        if ((int)Session["mode"] == 2)
        {
            mortabetrelation.Visible = true;
            Panelmortabetcof.Visible = true;

        }

    }


   




    //sabt cust id


    protected void sabtcustid(object sender, EventArgs e)
    {

        confsabtid.Visible = true;
        Session["mode"] = 3;

        confsub_gr.Visible = false;
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        mortabetrelation.Visible = false;
        
        sabtid.Visible = false;
        relationpanel.Visible = false;
        confsub_gr.Visible = false;


   
        newsubgrhagh(this, e);
        newsubgrhogh(this, e);

        //confsabtid.Visible = true;


        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er;

        res = db.fill_combo_gr(out er);
        DropDownList3.DataSource = res.Tables[0];
        DropDownList3.DataTextField = "group_name";
        DropDownList3.DataValueField = "group_cod";
        DropDownList3.DataBind();
     

        if (res.Tables[0].Rows.Count > 0)
        {
            Label104.Text = DropDownList3.SelectedItem.ToString();
            Bind();

            MultiView1.ActiveViewIndex = 2;
            confsabtid.Visible = true;
            Label80.Text = "";
        }

        else
        {
            return;
        }

       
       
        //Label102.Text = DropDownList3.SelectedItem.ToString();


    }
    protected void sabtcustomerid(object sender, EventArgs e)
    {
        sabtid.Visible = true;
        confsabtid.Visible = false;
        Label80.Text = "";
     

     }
    protected void dosabt(object sender, EventArgs e)
    {

        DataSet res = new DataSet();
        DataSet ds_stat = new DataSet();
        group_introduction db = new group_introduction();
        string err;
        int status;
        string grcod;
        string cust_id = TextBox39.Text;


        if (TreeViewsubgr.SelectedValue.ToString() == "")
        {
            grcod = DropDownList3.SelectedValue;
        }
        else
        {
            grcod = TreeViewsubgr.SelectedValue.ToString();
        }


        ds_stat = db.find_stat(grcod, out err);
        string stat1 = ds_stat.Tables[0].Rows[0]["stat"].ToString();
        int stat = Int32.Parse(stat1);
        if (stat == 0)
        {

            res = db.sabtidhagh(grcod, cust_id, out err, out status);
            if (res != null && res.Tables[0].Rows.Count > 0)
            {
               
                if (status == 0)
                {
                    TextBox39.Text = "";
                    Label80.Text = "error";


                }
                else if (status == 1)
                {
                    TextBox39.Text = "";
                    Label80.Text = "error";
                }
            }
            else
            {

            }

        }

        else if (stat == 1)
        {

            res = db.sabtidhogh(grcod, cust_id, out err, out status);
            if (res != null && res.Tables[0].Rows.Count > 0)
            {
                if (status == 0)
                {
                    TextBox39.Text = "";
                    Label80.Text = "error";


                }
                else if (status == 1)
                {
                    TextBox39.Text = "";
                    Label80.Text = "error";
                }
            }
            else
            {

            }

        }

    }
    protected void clklinkbtn(object sender, EventArgs e)
    {
        DataSet res = new DataSet();
        iscust db = new iscust();
        string er;

        res=db.control_cust(TextBox39.Text, out er);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {

             string nam = res.Tables[0].Rows[0]["nam"].ToString();
            string family = res.Tables[0].Rows[0]["family"].ToString();
            Label116.Text=nam+"  "+family;
        }


    }
    protected void clklinkcustid (object sender, EventArgs e)
    {

        sabtcustid(this, e);
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er = "";

        res = db.findgr_relat(Label86.Text, out er);
        trch_custid(res.Tables[0].Rows[0]["group_name"].ToString(), res.Tables[0].Rows[0]["group_cod"].ToString(), Label84.Text);


    }
    protected void trch_custid(string s, string s2, string s1)
    {

        panelsubgr.Visible = false;
        DropDownList3.ClearSelection();
        DropDownList3.SelectedItem.Text = s;
        Label104.Text = s1;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";

        ds = db.find_grcod(s2, out er);
        if (TreeViewsubgr.SelectedValue != null)
        {
            Label1.Text = TreeViewsubgr.SelectedValue.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    TreeNode no = new TreeNode();
                    no.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    no.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    no.PopulateOnDemand = true;
                    no.SelectAction = TreeNodeSelectAction.SelectExpand;
                    no.ChildNodes.Add(no);
                    this.TreeViewsubgr.Nodes.Add(no);

                }

            }
            else
            {


            }
        }
        else
        {

        }


        subgrcomplete.Visible = false;


        if ((int)Session["mode"] == 3)
        {
            confsabtid.Visible = true;
            sabtid.Visible = false;
           // relationpanel.Visible = true;

        }

    }


    //viraiesh

    protected void viraiesh(object sender, EventArgs e)
    {


        panel5.Visible = false;
        panel8.Visible = false;
        Paneledithogh.Visible = false;
        Paneledithagh.Visible = false;
        panel9.Visible = false;
        labeleditcom.Text = "";
        TreeViewedit.Nodes.Clear();
        DataSet res = new DataSet();
        DataSet res_subgr = new DataSet();
        group_introduction db = new group_introduction();
        string er;



        res = db.fill_combo_gr(out er);
        DropDownList1.DataSource = res.Tables[0];
        DropDownList1.DataTextField = "group_name";
        DropDownList1.DataValueField = "group_cod";
        DropDownList1.DataBind();
        if (res.Tables[0].Rows.Count > 0)
        {
            Label49.Text = DropDownList1.SelectedItem.ToString();
            Bind2();
            MultiView1.ActiveViewIndex = 3;

        }

        else
        {
            return;
        }
        


    }
    protected void drop1ch(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        panel5.Visible = false;
        panel8.Visible = false;
        Paneledithogh.Visible = false;
        Paneledithagh.Visible = false;
        panel9.Visible = false;
        labeleditcom.Text = "";
        Label49.Text = DropDownList1.SelectedItem.ToString();
        TreeViewedit.Nodes.Clear();

        Bind2();
    }
    public void Bind2()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
        string s = DropDownList1.SelectedItem.Value;
        ds = db.find_grcod(s, out er);
        if (TreeViewedit.SelectedValue != null)
        {
            Label1.Text = TreeViewedit.SelectedValue.ToString();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    TreeNode no = new TreeNode();
                    no.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    no.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    no.PopulateOnDemand = true;
                    no.SelectAction = TreeNodeSelectAction.SelectExpand;
                    no.ChildNodes.Add(no);
                    this.TreeViewedit.Nodes.Add(no);

                }

            }
            else
            {

            }
        }
        else
        {

        }
    }
    protected void treeView2_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {


        if (e.Node.ChildNodes.Count == 0)
        {

            getchild2(e.Node);

        }
    }
    protected void trch2(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Label49.Text = TreeViewedit.SelectedNode.Text;
        panel5.Visible = false;
        panel8.Visible = false;
        panel9.Visible = false;
        labeleditcom.Text = "";
        Paneledithogh.Visible = false;
        Paneledithagh.Visible = false;

    }
    private void getchild2(TreeNode node)
    {

        panel5.Visible = false;
        panel8.Visible = false;
        Paneledithogh.Visible = false;
        Paneledithagh.Visible = false;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";


        if (node.Value == "")
        {


        }


        else if (node != null)
        {

            ds = db.find_grcod(node.Value.ToString(), out er);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TreeNode NewNode = new TreeNode();
                    NewNode.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                    NewNode.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                    NewNode.PopulateOnDemand = true;
                    node.ChildNodes.Add(NewNode);
                    //NewNode.SelectAction = TreeNodeSelectAction.SelectExpand;

                }

            }
            else
            {

            }


        }


    }
    protected void clkviewgr(object sender, EventArgs e)
    {
       
        MultiView1.ActiveViewIndex = 3;
        panel5.Visible = true;
        Paneledithagh.Visible = false;
        panel8.Visible = true;
        Paneledithogh.Visible = false;
        findgs(this, e);
    }

    protected void findgs(object sender, EventArgs e)
    {
        group_introduction db = new group_introduction();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string er = "";

        string grcod = "";
        string stat = "";
        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList1.SelectedItem.Value;
            ds = db.findgrrshead(grcod, out er);
            stat = ds.Tables[0].Rows[0]["stat"].ToString();
        }

        else
        {
            grcod = TreeViewedit.SelectedValue;
            ds = db.findgrrssubhead(grcod, out er);
            stat = ds.Tables[0].Rows[0]["stat"].ToString();
        }



        if (stat == "0")
        {
            ds1 = db.findgrrs1(grcod, out er);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                TextBox3.Text = ds1.Tables[0].Rows[0]["gr_name"].ToString();
                TextBox4.Text = ds1.Tables[0].Rows[0]["gr_family"].ToString();
                TextBox2.Text = ds1.Tables[0].Rows[0]["cust_id"].ToString();
                TextBox5.Text = ds1.Tables[0].Rows[0]["gr_bc"].ToString();
                TextBox6.Text = ds1.Tables[0].Rows[0]["gr_father"].ToString();
                TextBox7.Text = ds1.Tables[0].Rows[0]["gr_plc"].ToString();
                TextBox8.Text = ds1.Tables[0].Rows[0]["gr_nationalcod"].ToString();
                panel5.Visible = true;
                Paneledithagh.Visible = true;
                Panel2.Visible = false;
                panel8.Visible = false;



            }

        }
        else if (stat == "1")
        {
            ds2 = db.findgrrs2(grcod, out er);

            if (ds2 != null && ds2.Tables[0].Rows.Count > 0)
            {
                TextBox9.Text = ds2.Tables[0].Rows[0]["name"].ToString();
                TextBox37.Text = ds2.Tables[0].Rows[0]["cust_id"].ToString();
                TextBox10.Text = ds2.Tables[0].Rows[0]["sabt"].ToString();
                TextBox32.Text = ds2.Tables[0].Rows[0]["dat"].ToString();
                TextBox33.Text = ds2.Tables[0].Rows[0]["plc"].ToString();
                TextBox34.Text = ds2.Tables[0].Rows[0]["kind"].ToString();
                TextBox35.Text = ds2.Tables[0].Rows[0]["center"].ToString();
                TextBox36.Text = ds2.Tables[0].Rows[0]["cod"].ToString();
                panel8.Visible = true;
                Paneledithogh.Visible = true;
                Panel2.Visible = false;
                panel5.Visible = false;



            }



        }





    }

    protected void clk5save(object sender, EventArgs e)
    {
        panel9.Visible = false;
        labeleditcom.Text = "";
        int status;
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er = "";
        string grcod = "";
        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList1.SelectedItem.Value;

        }

        else
        {
            grcod = TreeViewedit.SelectedValue;

        }

        string cust_id = TextBox2.Text;
        string name = TextBox3.Text;
        string family = TextBox4.Text;
        string bc = TextBox5.Text;
        string father = TextBox6.Text;
        string plc = TextBox7.Text;
        string nationalcode = TextBox8.Text;

        if (cust_id == "")
        {
            cust_id = "0";
        }


        res = db.uphagh(grcod, cust_id, name, family, bc, father, plc, nationalcode, out er, out status);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {

                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this,e);
              
               
            }
            else if (status == 1)
            {
                //  Labelerr.Text = "error";
                // Labelerr.Text = er;

                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this, e);
               
               
            }
        }

    }

    protected void clearviraiesh(object sender, EventArgs e)
    {

        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        TextBox8.Text = "";
        TextBox9.Text = "";
        TextBox10.Text = "";
        TextBox32.Text = "";
        TextBox33.Text = "";
        TextBox34.Text = "";
        TextBox35.Text = "";
        TextBox36.Text = "";
        TextBox37.Text = "";
       
    }

    protected void clk6save(object sender, EventArgs e)
    {

        panel9.Visible = false;
        labeleditcom.Text = "";
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
        string er = "";
        int status;
        string grcod = "";
        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList1.SelectedItem.Value;

        }

        else
        {
            grcod = TreeViewedit.SelectedValue;

        }


        string name = TextBox9.Text;
        string cust_id = TextBox37.Text;
        string sabt = TextBox10.Text;
        string dat = TextBox32.Text;
        string plc = TextBox33.Text;
        string kind = TextBox34.Text;
        string center = TextBox35.Text;
        string cod = TextBox36.Text;

        if (cust_id == "")
        {
            cust_id = "0";
        }

        res = db.uphogh(grcod, cust_id, name, sabt, dat, plc, kind, center, cod, out er, out status);
        if (res != null && res.Tables[0].Rows.Count > 0)
        {
            if (status == 0)
            {


                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this, e);
               
               

            }
            else if (status == 1)
            {
                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this, e);
               

            }

        }
    }

    protected void sub_balehview(object sender, EventArgs e)
    {

        MultiView1.ActiveViewIndex = 3;

        panel5.Visible = true;
        panel9.Visible = false;
        labeleditcom.Text = "";


    }






    //delete

    protected void clkdel(object sender, EventArgs e)
    {
        panel9.Visible = false;
        labeleditcom.Text = "";
        int status;
        DataSet res1 = new DataSet();
        DataSet res2= new DataSet();
 

        group_introduction db = new group_introduction();
        string er = "";
        string grcod = "";
        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList1.SelectedItem.Value;
            res1 = db.delete_gr(grcod, out er, out status);
          

            if (status == 0 )
            {
                labeleditcom.Text ="error";
                panel9.Visible = true;
                viraiesh(this, e);
                clearviraiesh(this, e);

              TreeViewedit.Nodes.Clear();
              Bind2();

            }
            else if (status == 1 && res2 == null && res2.Tables[0].Rows.Count <= 0)
            {
                labeleditcom.Text ="error";
                panel9.Visible = true;
                clearviraiesh(this, e);

            }
               

           
        }

        else
        {
            grcod = TreeViewedit.SelectedValue;
            res1 = db.delete_subgr(grcod, out er, out status);
            

                if (status == 0)
                {
                    labeleditcom.Text = "error";
                    panel9.Visible = true;
                    TreeViewedit.Nodes.Clear();
                    Bind2();
                    clearviraiesh(this, e);

                }
                else if (status == 1)
                {
                    labeleditcom.Text = "error";
                    panel9.Visible = true;
                    clearviraiesh(this, e);

                }


        }


    }

    protected void clkdel2(object sender, EventArgs e)
    {
        panel9.Visible = false;
        labeleditcom.Text = "";
        DataSet res = new DataSet();
        group_introduction db = new group_introduction();
         DataSet res1 = new DataSet();
         DataSet res2 = new DataSet();
        int status;
       string er = "";
       
        string grcod = "";
        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList1.SelectedItem.Value;
            res1 = db.delete_gr(grcod, out er, out status);
           

            if (status == 0 )
            {
                labeleditcom.Text = "error";
                panel9.Visible = true;
                viraiesh(this, e);
                TreeViewedit.Nodes.Clear();
                Bind2();
                clearviraiesh(this, e);

            }
            else if (status == 1 && res2 == null && res2.Tables[0].Rows.Count <= 0)
            {
                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this, e);
            }



        }

        else
        {
            grcod = TreeViewedit.SelectedValue;

            res1 = db.delete_subgr(grcod, out er, out status);


            if (status == 0)
            {
                labeleditcom.Text = "error";
                panel9.Visible = true;
                TreeViewedit.Nodes.Clear();
                Bind2();
                clearviraiesh(this, e);

            }
            else if (status == 1)
            {
                labeleditcom.Text = "error";
                panel9.Visible = true;
                clearviraiesh(this, e);
            }


        }



    }





    //gozaresh tashilati

    protected void jad1(object sender, EventArgs e)
    {

      //  Response.Redirect("jadone.aspx");

        Session["mode"] = 4;
        confsub_gr.Visible = false;
        panelsubgr.Visible = false;
        panelsubgr1.Visible = false;
        subgrcomplete.Visible = false;
        relationpanel.Visible = false;
        confsabtid.Visible = false;
        mortabetrelation.Visible = false;
        Panelmortabetcof.Visible = false;


        newsubgrhagh(this, e);
        newsubgrhogh(this, e);
        panelreport.Visible = true;

        
        DataSet res = new DataSet();
        DataSet res_mortabet = new DataSet();
        group_introduction db = new group_introduction();
        string er;

        res = db.fill_combo_gr(out er);
        DropDownList3.DataSource = res.Tables[0];
        DropDownList3.DataTextField = "group_name";
        DropDownList3.DataValueField = "group_cod";
        DropDownList3.DataBind();
        if (res.Tables[0].Rows.Count > 0)
        {

            Bind();
            MultiView1.ActiveViewIndex = 2;
            Label115.Text = DropDownList3.SelectedItem.ToString();


        }

        else
        {
            return;
        }


    }


    protected void rep_jad1(object sender, EventArgs e)
    {

        group_introduction db = new group_introduction();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        string er = "";

        string grcod = "";
        string stat = "";

        if (TreeViewedit.SelectedValue == "")
        {
            grcod = DropDownList3.SelectedItem.Value;
            ds = db.findgrrshead(grcod, out er);
            stat = ds.Tables[0].Rows[0]["stat"].ToString();
        }

        else
        {
            grcod = TreeViewedit.SelectedValue;
            ds = db.findgrrssubhead(grcod, out er);
            stat = ds.Tables[0].Rows[0]["stat"].ToString();
        }

        if (stat=="0")
        {
           ds1 = db.findcusthagh(grcod, out er);
           if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
           {
               Session["cust_id"] = ds1.Tables[0].Rows[0]["cust_id"].ToString();


           }

        }
        else if (stat=="1")
        {
            ds1 = db.findcusthagh(grcod, out er);
            if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
            {
                Session["cust_id"] = ds1.Tables[0].Rows[0]["cust_id"].ToString();


            }
        }



          Response.Redirect("jadone.aspx");

    }


}