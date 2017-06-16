using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

/// <summary>
/// Summary description for tashilat
/// </summary>
public class tashilat
{
  
	public tashilat()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    private DataSet jad_one(string cust_id, string kind, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("jad_one", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("kind", OracleType.Number, 50).Value = kind;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
           
        }

        return res;
    }

    private DataSet jad_one_bel(string cust_id, string stat, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("jad_one_bel", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("loansta", OracleType.Char, 50).Value = stat;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;

        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;

        }

        return res;
    }

    public DataSet mosharekat(string cust_id, string kind, out string er)
    {
       
        DataSet res = new DataSet();
        string err = "";
        res = jad_one(cust_id, kind, out er);
        return res;
    }

    public DataSet moavagh(string cust_id, string stat, out string er)
    {

        DataSet res = new DataSet();
        string err = "";
        res = jad_one_bel(cust_id, stat, out er);
        return res;
    }


    public DataSet lt(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select stat from relation where subgroup_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }

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
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            ds = null;
        }
        return ds;

    }




}