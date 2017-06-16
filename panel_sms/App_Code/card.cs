using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

/// <summary>
/// Summary description for card
/// </summary>
public class card
{
   
	public card()
	{
		//
		// TODO: Add constructor logic here
		//
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

    private DataSet findcustcard_melli(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustcard_melli", conn);
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

    private DataSet findcustcard_hesab(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustcard_hesab", conn);
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
    private DataSet findcustcard_card(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustcard_card", conn);
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
    public DataSet card1(string s)
    {

        string sql = "select card,stat,hesab,hesabha,cast(case when ramz2_stat='O' then 'OK' when ramz2_stat='I' then 'INACTIVE' when ramz2_stat='H' then 'HOT' when ramz2_stat is null then 'Not-active' end as varchar2(10)) stat_ramz2 from (select cfcifno, cast(case when cdsts='O' then 'OK' when cdsts='i' then 'INACTIVE' when cdsts='W' then 'WARM' when cdsts='H' then 'HOT' when cdsts='C' then 'CAPTURE' when cdsts='B' then 'BLOCK' when cdsts='E' then 'EXPIRE' end as varchar2(6)) STAT, cdcardno card,mobacccnvrt(substr(cdprmacnt,5)) hesab from kccards@report )t1 join (select cdcardno,mobacccnvrt(substr(accardacnt,5)) hesabha from kccrdacnts@report)t2 on t2.cdcardno=t1.card left join (select  epsts ramz2_stat,cdcardno from kcepay@report)t3 on t3.cdcardno=t1.card where t1.cfcifno="+s+"";
        string er;
        DataSet ds = retRows(sql, out er);
        return ds;
    }


    public DataSet card2(string s)
    {

        string er = "";
        DataSet ds = findcustcard_melli(s, out er);
        return ds;

    }


    public DataSet card3(string s)
    {

        string er = "";
        DataSet ds = findcustcard_hesab(s, out er);
        return ds;

    }

    public DataSet card4(string s)
    {

        string er = "";
        DataSet ds = findcustcard_card(s, out er);
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