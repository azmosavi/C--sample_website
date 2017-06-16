using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;


/// <summary>
/// Summary description for paia
/// </summary>
public class paia
{
   
	public paia()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    private DataSet retRows(string sql, out string errormessage)
    {

        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        DataSet ds = null;
        try
        {
            conn.Open();
            ds = new DataSet();
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


    public DataSet log(string s)
    {
        DataSet ds = null;
        string sql = "select usercod from login where usercod=" + s + "";
        string er;
        ds = retRows(sql, out er);
        // return ds.Tables[0].Rows[0][0].ToString();
        return ds;

    }

    public DataSet finddat(string s)
    {
        DataSet ds = null;
        string sql = "select to_char(to_date("+s+",'yyyymmdd','nls_calendar=persian')+30,'yyyymmdd','nls_calendar=persian') dat from dual";
        string er;
        ds = retRows(sql, out er);
        return ds;

    }



    private DataSet ekh_retail(string s, string dat1, string dat2, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("ekh_retail", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("v_acc", OracleType.VarChar, 50).Value = s;
        com.Parameters.Add("param1", OracleType.VarChar, 50).Value = dat1;
        com.Parameters.Add("param2", OracleType.VarChar, 50).Value = dat2;
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


    private DataSet findlog_paia_id(string s, string dat1, string dat2,out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findlog_paia_id", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("s", OracleType.VarChar, 50).Value = s;
        com.Parameters.Add("dat1", OracleType.VarChar, 50).Value = dat1;
        com.Parameters.Add("dat2", OracleType.VarChar, 50).Value = dat2;
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

    private DataSet findlog_paia_card(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findlog_paia_card", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("s", OracleType.VarChar, 50).Value = s;
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


    private DataSet findlog_paia_hesab(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findlog_paia_hesab", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("s", OracleType.VarChar, 50).Value = s;
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



    public DataSet khadamat(string s,string dat1, string dat2)
    {


        string er = "";
        DataSet ds = findlog_paia_id(s,dat1,dat2, out er);
        return ds;

    }

    public DataSet khadamat1(string s)
    {


        string er = "";
        DataSet ds = findlog_paia_card(s, out er);
        return ds;

    }


    public DataSet khadamat2(string s)
    {


        string er = "";
        DataSet ds = findlog_paia_hesab(s, out er);
        return ds;

    }

    public DataSet findcardno(string s)
    {
        DataSet ds = null;
        string sql = "select cdcardno from kccards@parsian where cbc_cfcifno=" + s + "";
        string er;
        ds = retRows(sql, out er);
        return ds;

    }


    public DataSet cardhesab(string s)
    {
        DataSet ds = null;
        string sql = "select substr(cdprmacnt,5) hesab from kccards@parsian where cdcardno=" + s + "";
        string er;
        ds = retRows(sql, out er);
        return ds;

    }


    public DataSet fsorathesab(string s,string dat1, string dat2)
    {
        string er = "";
        DataSet ds = ekh_retail(s, dat1, dat2, out er);
        return ds;
    }
  
}