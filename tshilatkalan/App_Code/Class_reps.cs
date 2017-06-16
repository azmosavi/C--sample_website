using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

/// <summary>
/// Summary description for Class_reps
/// </summary>
public class Class_reps
{
	public Class_reps()
	{
		//
		// TODO: Add constructor logic here
		//

    }


    public static string cif;
    private DataSet retRows(string sql, out string errormessage)
    {
         
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        DataSet ds = new DataSet();

        try
        {
            conn.Open();
            OracleDataAdapter da = new OracleDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
           
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            conn.Close();

        }
        return ds;

    }

    public DataSet jads_one()
    {
        string err = "";
        DataSet ds = new DataSet();
        string sql = "select * from tas where cfcifno=16814212";
        ds = retRows(sql, out err);
        return ds;
    }


    public DataSet jads_one_b()
    {
        string err = "";
        DataSet ds = new DataSet();
        string sql = "select * from  (select * from tasgh_des)tb   left outer join (select * from tas_gh where cfcifno=16814212)tl on tl.crdtsta=tb.cod order by nm";
        ds = retRows(sql, out err);
        return ds;
    }


}