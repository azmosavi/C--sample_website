using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;
using Microsoft.Reporting.WebForms;
using System.Configuration;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void clk1(object sender, EventArgs e)
    {

        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
      //  group_introduction db= new group_introduction();
        Class_reps db = new Class_reps();
        
        string err="";
        Class_reps.cif = "16184212";
        ds = db.jads_one();
        ds1 = db.jads_one_b();
      
    }


}