using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

/// <summary>
/// Summary description for jozcard
/// </summary>
public class jozcard
{

	public jozcard()
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

    private DataSet crd_srvlimit(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("crd_srvlimit", conn);
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


    public DataSet jozcard1(string s)
    {

        string er = "";
        DataSet ds = crd_srvlimit(s, out er);
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