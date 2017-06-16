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
    public DataSet retRows(string sql, out string errormessage)
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

    public DataSet jads_one( string dt)
    {
        string err = "";
        DataSet ds = new DataSet();
        // string sql = "select * from tas where  cfcifno=" + cif + "";
        //string sql = "select * from tas where cfcifno=" + cif + "";
        string sql = "select  to_char(dat,'yyyymmdd','NLS_CALENDAR=persian') dt,ac,shop, tedad,  mandeh  from pec_acc4 t where mandeh!=-1 and to_char(dat,'yyyy/mm/dd','NLS_CALENDAR=persian')='" + dt + "'   order by  tedad desc,ac";
        ds = retRows(sql, out err);
        return ds;
    }


   


}