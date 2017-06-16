using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

/// <summary>
/// Summary description for iscust
/// </summary>
public class iscust
{

   
	public iscust()
	{
		//
		// TODO: Add constructor logic here
		//
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
    private bool execQuery(string sql, out string errormessage)
    {
        bool res = true;
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand(sql, conn);
        com.CommandType = CommandType.Text;

        try
        {
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = false;
        }
        return res;

    }


    private DataSet findcustinf_haghighi(string cust_id,out string errormessage)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustinf_haghighi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
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
    public DataSet findcust_hagh(string cust_id)
    {
    
        DataSet res = new DataSet();
        string er = "";
        res = findcustinf_haghighi(cust_id, out er);
        return res;
    }
    private DataSet findcustinf_hoghoghi(string cust_id, out string errormessage)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustinf_hoghoghi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
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
    public DataSet findcust_hogh(string cust_id)
    {

        DataSet res = new DataSet();
        string er = "";
        res = findcustinf_hoghoghi(cust_id, out er);
        return res;
    }

    public DataSet control_cust(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select SUBSTR(cffulnam, INSTR(cffulnam, '*', 1, 1) + 1, INSTR(cffulnam, '*', 1, 2) - INSTR(cffulnam, '*', 1, 1) - 1) as nam,SUBSTR(cffulnam, 1, INSTR(cffulnam, '*') - 1) as family from cbcif@report  where cfcifno=" + s + "  union select  cffulnam nam, '' family from cbcif@report  where cfcifno=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
}