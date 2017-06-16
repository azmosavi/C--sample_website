using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;


/// <summary>
/// Summary description for group_introduction
/// </summary>
public class group_introduction
{
    
    public group_introduction()
    {
        //
        // TODO: Add constructor logic here
        //
    }


   
    private DataSet group_haghighi(string grname, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("group_haghighi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grname", OracleType.VarChar, 50).Value = grname;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("family", OracleType.VarChar, 50).Value = family;
        com.Parameters.Add("bc", OracleType.VarChar, 50).Value = bc;
        com.Parameters.Add("father", OracleType.VarChar, 50).Value = father;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("nationalcode", OracleType.Number, 50).Value = nationalcode;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            //errormessage = ex.Message;
            if (ex.Message == "unique constraint (PBEAT_D.GRO_NAM) violated")
            //"unique constraint (PBEAT_D.GRO_NAM) violated ORA-06512: at " + "PBEAT_D.GROUP_HAGHIGHI" + ", line 14 ORA-06512: at line 1")
            {

                errormessage = "error";

            }
            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet custid_haghighi(string grcod, string cust_id, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("custid_haghighi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            //errormessage = ex.Message;
            if (ex.Message == "unique constraint (PBEAT_D.GRO_NAM) violated")
            //"unique constraint (PBEAT_D.GRO_NAM) violated ORA-06512: at " + "PBEAT_D.GROUP_HAGHIGHI" + ", line 14 ORA-06512: at line 1")
            {

                errormessage = "error";

            }
            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet custid_hoghoghi(string grcod, string cust_id, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("custid_hoghoghi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            //errormessage = ex.Message;
            if (ex.Message == "unique constraint (PBEAT_D.GRO_NAM) violated")
            //"unique constraint (PBEAT_D.GRO_NAM) violated ORA-06512: at " + "PBEAT_D.GROUP_HAGHIGHI" + ", line 14 ORA-06512: at line 1")
            {

                errormessage = "error";

            }
            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet updatehaghgrs(string grcod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("updatehaghgrs", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.VarChar, 50).Value = grcod;
        com.Parameters.Add("id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("family", OracleType.VarChar, 50).Value = family;
        com.Parameters.Add("bc", OracleType.VarChar, 50).Value = bc;
        com.Parameters.Add("father", OracleType.VarChar, 50).Value = father;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("nationalcode", OracleType.Number, 50).Value = nationalcode;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet updatehoghgrs(string grcod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("updatehoghgrs", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.VarChar, 50).Value = grcod;
        com.Parameters.Add("id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("n", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("s", OracleType.VarChar, 50).Value = sabt;
        com.Parameters.Add("d", OracleType.VarChar, 50).Value = dat;
        com.Parameters.Add("p", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("k", OracleType.VarChar, 50).Value = kind;
        com.Parameters.Add("cen", OracleType.VarChar, 50).Value = center;
        com.Parameters.Add("c", OracleType.Number, 50).Value = cod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet sub_group_haghighi(string grcod, string relation_cod, string subrelation_cod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, string level, out string errormessage, out int status)
    {

        //bool res = true;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("sub_group_haghighi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("relation_cod", OracleType.Number, 50).Value = relation_cod;
        com.Parameters.Add("subrelation_cod", OracleType.Number, 50).Value = subrelation_cod;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("family", OracleType.VarChar, 50).Value = family;
        com.Parameters.Add("bc", OracleType.VarChar, 50).Value = bc;
        com.Parameters.Add("father", OracleType.VarChar, 50).Value = father;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("nationalcode", OracleType.Number, 50).Value = nationalcode;
        com.Parameters.Add("level", OracleType.Number, 50).Value = level;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            //com.ExecuteNonQuery();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 0;
        }

        return res;

    }
    private DataSet sub_group_hoghoghi(string grcod, string relation_cod, string subrelation_cod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string codegh, string level, out string errormessage, out int status)
    {

        // bool res = true;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("sub_group_hoghoghi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("relation_cod", OracleType.Number, 50).Value = relation_cod;
        com.Parameters.Add("subrelation_cod", OracleType.Number, 50).Value = subrelation_cod;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("sabt", OracleType.Number).Value = sabt;
        com.Parameters.Add("dat", OracleType.VarChar, 50).Value = dat;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("kind", OracleType.VarChar, 50).Value = kind;
        com.Parameters.Add("center", OracleType.VarChar, 50).Value = center;
        com.Parameters.Add("codegh", OracleType.Number, 50).Value = codegh;
        com.Parameters.Add("level", OracleType.Number, 50).Value = level;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);


        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 0;
        }

        return res;

    }
    private DataSet mortabet_haghighi(string grcod, string relation_cod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, string sahmprc, out string errormessage, out int status)
    {
        //bool res = true;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("mortabet_haghighi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("gr_cod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("relate_cod", OracleType.Number, 50).Value = relation_cod;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("family", OracleType.VarChar, 50).Value = family;
        com.Parameters.Add("bc", OracleType.VarChar, 50).Value = bc;
        com.Parameters.Add("father", OracleType.VarChar, 50).Value = father;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("nationalcode", OracleType.Number, 50).Value = nationalcode;
        com.Parameters.Add("sahmprc", OracleType.VarChar, 50).Value = sahmprc;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 1;
        }

        return res;

    }
    private DataSet mortabet_hoghoghi(string gr_cod, string relate_cod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string sahmprc, string cod, out string errormessage, out int status)
    {
        //bool res = true;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("mortabet_hoghoghi", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("gr_cod", OracleType.Number, 50).Value = gr_cod;
        com.Parameters.Add("relate_cod", OracleType.Number, 50).Value = relate_cod;
        com.Parameters.Add("cust_id", OracleType.Number, 50).Value = cust_id;
        com.Parameters.Add("name", OracleType.VarChar, 50).Value = name;
        com.Parameters.Add("sabt", OracleType.Number, 50).Value = sabt;
        com.Parameters.Add("dat", OracleType.VarChar, 50).Value = dat;
        com.Parameters.Add("plc", OracleType.VarChar, 50).Value = plc;
        com.Parameters.Add("kind", OracleType.VarChar, 50).Value = kind;
        com.Parameters.Add("center", OracleType.Number, 50).Value = center;
        com.Parameters.Add("sahmprc", OracleType.VarChar, 50).Value = sahmprc;
        com.Parameters.Add("cod", OracleType.Number, 50).Value = cod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 1;
        }

        return res;

    }
    private DataSet group_hoghoghi(string grname, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string errormessage, out int status)
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
        com.Parameters.Add("codegh", OracleType.Number, 50).Value = cod;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {

            conn.Open();
            // com.ExecuteNonQuery();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 0;
        }

        return res;

    }
    private DataSet del(string grcod, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("del", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;


            res = null;
            status = 0;
        }

        return res;
    }
    private DataSet del_head(string grcod, out string errormessage, out int status)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("del_head", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("grcod", OracleType.Number, 50).Value = grcod;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
            conn.Dispose();

        }
        catch (Exception ex)
        {
            errormessage = ex.Message;


            res = null;
            status = 0;
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



    public DataSet delete_subgr(string grcod, out string er, out int status)
    {

        string err = "";
        DataSet res = del(grcod, out er, out status);
        return res;
    }
    public DataSet delete_gr(string grcod, out string er, out int status)
    {

        string err = "";
        DataSet res = del_head(grcod, out er, out status);
        return res;
    }

    public DataSet group_hagh(string grname, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, out string er, out int status)
    {
        //bool res=true;
        string err = "";
        DataSet res = group_haghighi(grname, cust_id, name, family, bc, father, plc, nationalcode, out er, out status);
        return res;
    }
    public DataSet group_hogh(string grname, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string er, out int status)
    {
        // bool res = true;
        string err = "";
        DataSet res = group_hoghoghi(grname, cust_id, name, sabt, dat, plc, kind, center, cod, out er, out status);
        return res;
    }
    public DataSet sub_group_hagh(string grcod, string relation_cod, string subrelation_cod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, string level, out string er, out int status)
    {
        //bool res = true;
        DataSet res = new DataSet();
        string err = "";
        res = sub_group_haghighi(grcod, relation_cod, subrelation_cod, cust_id, name, family, bc, father, plc, nationalcode, level, out er, out status);
        return res;
    }
    public DataSet sub_group_hogh(string grcod, string relation_cod, string subrelation_cod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, string level, out string er, out int status)
    {
        // bool res = true;
        DataSet res = new DataSet();
        string err = "";
        res = sub_group_hoghoghi(grcod, relation_cod, subrelation_cod, cust_id, name, sabt, dat, plc, kind, center, cod, level, out er, out status);
        return res;
    }



    public DataSet fill_combo_gr(out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select group_name,group_cod from groups order by group_name";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_relhagh(out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from pers_relation where stat=0";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_relhogh(out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from pers_relation where stat=1";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_subgr(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select t1.subgroup_cod, gr_name from (select subgroup_cod from relation where group_cod=" + s + ")t1 left outer join (select * from( (select subgroup_cod, gr_name from subgroup_id_hagh) union (select subgroup_cod, gr_name from subgroup_id_hogh))t)t2 on t1.subgroup_cod=t2.subgroup_cod";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_relation(out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select relation_cod, re_desc from relation_desc";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_sub_relation(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from subrelation_desc where rel_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet fill_combo_mortabet(out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select pers_cod, pers_desc from pers_relation";
        ds = retRows(sql, out err);
        return ds;
    }


    public DataSet find_grcod(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from groups where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet find_subgrnamehagh(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select t1.subgroup_cod scod, gr_name from (select subgroup_cod,stat from relation where group_cod=" + s + ")t1 join (select * from subgroup_id_hagh)t2 on t1.subgroup_cod=t2.subgroup_cod";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet find_subgrnamehogh(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select t1.subgroup_cod scod, gr_name from (select subgroup_cod,stat from relation where group_cod=" + s + ")t1 join (select * from subgroup_id_hogh)t2 on t1.subgroup_cod=t2.subgroup_cod";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet find_level(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select levels, stat from relation  where subgroup_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet find_stat(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select stat from groups where group_cod=" + s + " union select stat from relation where subgroup_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findgrrshead(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select stat from groups where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findgrrssubhead(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select stat from relation where subgroup_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findgrrs1(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from group_id_hagh where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findgrrs2(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from group_id_hogh where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findcusthagh(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from grouphagh_custid where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findcusthogh(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from grouphogh_custid where group_cod=" + s + "";
        ds = retRows(sql, out err);
        return ds;
    }
    public DataSet findgr_relat(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select t2.group_name, t2.group_cod from (select * from relation t START WITH t.subgroup_cod in (" + s + ") CONNECT BY PRIOR t.group_cod= t.subgroup_cod order by t.group_cod, t.subgroup_cod)t1 join  (select * from groups)t2 on t1.group_cod=t2.group_cod";
        ds = retRows(sql, out err);
        return ds;
    }



    public DataSet uphagh(string grcod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, out string er, out int status)
    {
        //bool res=true;
        string err = "";
        DataSet res = updatehaghgrs(grcod, cust_id, name, family, bc, father, plc, nationalcode, out er, out status);
        return res;
    }
    public DataSet uphogh(string grcod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string cod, out string er, out int status)
    {
        //bool res=true;
        string err = "";
        DataSet res = updatehoghgrs(grcod, cust_id, name, sabt, dat, plc, kind, center, cod, out er, out status);
        return res;
    }
    public DataSet sabtidhagh(string grcod, string cust_id, out string err, out int status)
    {


        DataSet res = custid_haghighi(grcod, cust_id, out err, out status);
        return res;
    }
    public DataSet sabtidhogh(string grcod, string cust_id, out string err, out int status)
    {

        DataSet res = custid_hoghoghi(grcod, cust_id, out err, out status);
        return res;
    }
    public DataSet sabtmortabet(string grcod, string relation_cod, string cust_id, string name, string family, string bc, string father, string plc, string nationalcode, string sahmprc, out string errormessage, out int status)
    {
        DataSet res = mortabet_haghighi(grcod, relation_cod, cust_id, name, family, bc, father, plc, nationalcode, sahmprc, out errormessage, out status);
        return res;
    }
    private DataSet sabtmortabet_hogh(string gr_cod, string relate_cod, string cust_id, string name, string sabt, string dat, string plc, string kind, string center, string sahmprc, string cod, out string errormessage, out int status)
    {
        DataSet res = mortabet_hoghoghi(gr_cod, relate_cod, cust_id, name, sabt, dat, plc, kind, center, sahmprc, cod, out errormessage, out status);
        return res;
    }



    public DataSet jads_one(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from tas where  cfcifno=1859";
        ds = retRows(sql, out err);
        return ds;
    }


}