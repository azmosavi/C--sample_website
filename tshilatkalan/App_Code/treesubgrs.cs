using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;


/// <summary>
/// Summary description for treesubgrs
/// </summary>
public class treesubgrs
{

    public treesubgrs()
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

    private DataSet group_hoghoghi(string grname, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string errormessage)
    {

        // bool res = true;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("group_hoghoghi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grname", OracleType.VarChar, 50).Value = grname;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("sabt", OracleType.Number, 50).Value = sabt;
        com.Parameters.Add("dat", OracleType.VarChar, 50).Value = dat;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("kind", OracleType.VarChar, 50).Value = kind;
        com.Parameters.Add("center", OracleType.VarChar, 50).Value = center;
        com.Parameters.Add("cod", OracleType.Number, 50).Value = cod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {

            conn.Open();
            // com.ExecuteNonQuery();
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

    public DataSet group_hogh(string grname, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string er)
    {
        // bool res = true;
        string err = "";
        DataSet res = group_hoghoghi(grname, cust_id, name, sabt, dat, plc, kind, center, cod, out er);
        return res;
    }


    public DataSet find_grcod(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select gr_name,subgroup_cod from (select subgroup_cod from relation where group_cod=" + s + ")t1 join (select group_cod,concat(concat(gr_name, ' * '),gr_family) gr_name from group_id_hagh union  select group_cod,name from group_id_hogh )t2 on  t1.subgroup_cod=t2.group_cod";
        ds = retRows(sql, out err);
        return ds;
    }

}