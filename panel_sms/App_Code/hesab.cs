using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

/// <summary>
/// Summary description for hesab_card
/// </summary>
public class hesab
{

	public hesab()
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

    private DataSet findcusthesab_melli(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcusthesab_melli", conn);
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

    private DataSet findcusthesab_hesab(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcusthesab_hesab", conn);
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

    private DataSet findcusthesab_card(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcusthesab_card", conn);
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
    

    public DataSet hesab1(string s)
    {

        string sql = "select  t1.abrnchcod cod,mobacccnvrt( mobacccnvrt2(concat(concat(concat(concat(t1.tbdptype,'-'),t1.cfcifno),'-'),t1.tdserial))) hesab,acurrcode arz, tdtitle titl, tdcondtn cond from(select * from tcdeposit@report ) t1 join (select * from tcif2dpst@report )t2 on t2.TBDPTYPE = t1.TBDPTYPE and t2.tcd_cfcifno = t1.CFCIFNO and t2.TDSERIAL = t1.TDSERIAL  where  t2.cfcifno ="+s+"";

        string er;
        DataSet ds = retRows(sql, out er);
        return ds;
    }


    public DataSet hesab2(string s)
    {

        string er = "";
        DataSet ds = findcusthesab_melli(s, out er);
        return ds;

    }
    public DataSet hesab3(string s)
    {

        string er = "";
        DataSet ds = findcusthesab_hesab(s, out er);
        return ds;

    }

    public DataSet hesab4(string s)
    {

        string er = "";
        DataSet ds = findcusthesab_card(s, out er);
        return ds;

    }

    public bool writelog(string s3, string s1, string s2)
    {

        string er = "";
        string sql = "insert into log_ccs values('" + s3 + "','" + s1 + "',sysdate,'" + s2 + "')";
        bool res = execQuery(sql, out er);
        sql = "commit";
        res = execQuery(sql, out er);
        return res;

    }

}