using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;


public partial class Default1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = treeView1.SelectedValue.ToString();

        //InitializeTreeView();
        //TreeView1.Nodes
        if (!IsPostBack)
        {
           
            Bind1();
        }
    }

    public void Bind1()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
        string s = "721";
        ds = db.find_grcod(s,out er);
        Label1.Text = treeView1.SelectedValue.ToString();
        if (ds.Tables[0].Rows.Count>0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
               
                TreeNode no = new TreeNode();
                no.Text=ds.Tables[0].Rows[i]["gr_name"].ToString();
                no.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                no.PopulateOnDemand = true;
                no.SelectAction = TreeNodeSelectAction.SelectExpand;
                no.ChildNodes.Add(no);
                this.treeView1.Nodes.Add(no);
               
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

    protected void trch(object sender, EventArgs e)
    {

        Label1.Text = treeView1.SelectedValue.ToString();
        

    }

    private void getchild(TreeNode node)
    {
       
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        treesubgrs db = new treesubgrs();
        string er = "";
        ds = db.find_grcod(treeView1.SelectedValue.ToString(), out er);
        //Label1.Text = treeView1.SelectedNode.Text;
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                TreeNode NewNode = new TreeNode();
                NewNode.Text = ds.Tables[0].Rows[i]["gr_name"].ToString();
                NewNode.Value = ds.Tables[0].Rows[i]["subgroup_cod"].ToString();
                NewNode.PopulateOnDemand = true;
                NewNode.SelectAction = TreeNodeSelectAction.SelectExpand;
                node.ChildNodes.Add(NewNode);
            }

        }
        else
        {

        }

    }


  
}