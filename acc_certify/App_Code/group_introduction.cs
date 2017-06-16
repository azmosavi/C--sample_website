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





    public int reg_sep(string ch_typ, string ch_from_ceri, string ch_to_ceri, string ch_brcod, string ch_usrcod, out string errormessage)
    {
        int status;
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("reg_sep", conn);
        com.CommandType = CommandType.StoredProcedure;
        com.Parameters.Add("ch_typ", OracleType.Char, 10).Value = ch_typ;
        com.Parameters.Add("ch_from_ceri", OracleType.Number, 50).Value = ch_from_ceri;
        com.Parameters.Add("ch_to_ceri", OracleType.Number, 50).Value = ch_to_ceri;
        com.Parameters.Add("ch_brcod", OracleType.Number, 50).Value = ch_brcod;
        com.Parameters.Add("ch_usrcod", OracleType.Char, 50).Value = ch_usrcod;
        com.Parameters.Add("status", OracleType.Number).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            com.ExecuteNonQuery();
            conn.Close();
            decimal status1 = (decimal)com.Parameters["status"].Value;
            status = (int)status1;
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 1;
            conn.Close();
        }
        return status;
    }

    public DataSet findcustid_hesab(string s, out string errormessage)
    {

        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustid_hesab", conn);
        com.CommandType = CommandType.StoredProcedure;

        com.Parameters.Add("s", OracleType.VarChar,50).Value = s;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);
        try
        {
            conn.Open();
            da.Fill(res);
            conn.Close();
        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            conn.Close();
        }

        return res;
    }
    
    public DataSet link_per_ch(string ch_id_per_chequ, string ch_acnt_number, string ch_nam,out string errormessage, out int status)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("link_per_ch", conn);
        com.CommandType = CommandType.StoredProcedure;

        com.Parameters.Add("ch_id_per_chequ", OracleType.Number, 10).Value = ch_id_per_chequ;
        com.Parameters.Add("ch_acnt_number", OracleType.VarChar, 30).Value = ch_acnt_number;
        com.Parameters.Add("ch_nam", OracleType.VarChar,100).Value = ch_nam;
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


        }
        catch (Exception ex)
        {
            errormessage = ex.Message;
            res = null;
            status = 1;
            conn.Close();
        }

        return res;
    }

    public DataSet fill_combo_ser(string s1, string s2, string s3, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select distinct num_ser from sep_info where assigned_brcod=" + s1 + " and typ=" + s2 +" and num_ser=" + s3 +"";
        ds = retRows(sql, out err);
        return ds;
    }

    public DataSet fill_combo_ser1(string s1, out string err)
    {

        DataSet ds = new DataSet();
        //string sql = "select distinct num_ser from ch_info where assigned_brcod=" + s2 + " and siz=" + s1 + "  order by num_ser";
        string sql = "select distinct typ, num_ser from sep_info where assigned_brcod=" + s1 + "";
        
        ds = retRows(sql, out err);
        return ds;
    }

    public DataSet fill_combo_typ(string s1, string s2, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select distinct acnt_typ from ch_info where assigned_brcod=" + s2 + " and siz=" + s1 + " order by acnt_typ";
        ds = retRows(sql, out err);
        return ds;
    }

    public DataSet fill_gridview(string s1, string s2,  out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from sep_info where  assigned_brcod=" + s1 + " and typ=" + s2 + " ";
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

    public bool del_row(string s)
    {
        string err;
        bool res;
        string sql = "delete sep_info where id=" + s + " ";
        res = execQuery(sql, out err);
         sql = "commit";
        res = execQuery(sql, out err);
        return res;
    }

    public bool del_row_allocated(string s)
    {
        string err;
        bool res;
        string sql = "delete allocate_sep where id_per_chequ=" + s + " ";
        res = execQuery(sql, out err);
        sql = "update ext_serials set allocate=0 where id_per_chequ=" + s + " ";
        res = execQuery(sql, out err);
        return res;
    }

    public DataSet ext_cheq(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select * from ext_serials where id=" + s + " order by id_per_chequ ";
        ds = retRows(sql, out err);
        return ds;
    }

    public DataSet show_allocatd(string s, out string err)
    {

        DataSet ds = new DataSet();
        string sql = "select t1.num_ser,t1.from_seri, t1.id_per_chequ, t2.acnt_number,t2.nam, t3.typ  from (select * from sep_info  where assigned_brcod=" + s + ")t3 join   (select * from ext_serials where allocate = 1) t1 on t3.id=t1.id join (select * from allocate_sep) t2 on t1.id_per_chequ = t2.id_per_chequ";
        ds = retRows(sql, out err);
        return ds;
    }


    public void LoginInfo(
         out short user_id,
         out string user_name,
         out short branch_code,
         out string branch_name,
         out short user_post)
    {
      //  ParsianDataProtection.DataProtection pd = new ParsianDataProtection.DataProtection();

        user_id = -1;
        user_name = "";
        branch_code = -1;
        branch_name = "";
        user_post = 0;

        string ipAddress = GetMachineIP();

        //OracleConnection con = new OracleConnection(pd.Decrypt(ConfigurationManager.ConnectionStrings["connect"].ConnectionString));
        OracleConnection con = new OracleConnection(oradb);
        con.Open();

        OracleCommand Orlcmd = new OracleCommand("ipinfo", con);
        Orlcmd.CommandType = CommandType.StoredProcedure;
        Orlcmd.Parameters.Add("ip", OracleType.VarChar, 15).Direction = ParameterDirection.Input;
        Orlcmd.Parameters["ip"].Value = ipAddress;

        Orlcmd.Parameters.Add("v_abrnchcod", OracleType.Number).Direction = ParameterDirection.Output;
        Orlcmd.Parameters.Add("v_brnch_name", OracleType.VarChar, 100).Direction = ParameterDirection.Output;
        Orlcmd.Parameters.Add("v_usercode", OracleType.Number).Direction = ParameterDirection.Output;
        Orlcmd.Parameters.Add("v_username", OracleType.VarChar, 100).Direction = ParameterDirection.Output;
        Orlcmd.Parameters.Add("v_userpost", OracleType.Number).Direction = ParameterDirection.Output;

        try
        {
            Orlcmd.ExecuteNonQuery();
            user_id = Convert.ToInt16(Orlcmd.Parameters["v_usercode"].Value);
            user_name = Orlcmd.Parameters["v_username"].Value.ToString();
            branch_code = Convert.ToInt16(Orlcmd.Parameters["v_abrnchcod"].Value);
            branch_name = Orlcmd.Parameters["v_brnch_name"].Value.ToString();
            user_post = Convert.ToInt16(Orlcmd.Parameters["v_userpost"].Value);
        }
        catch (Exception)
        {
            user_id = -2;
            user_name = "";
            branch_code = -2;
            branch_name = "";
            user_post = 0;

        
        }
        finally
        {
            con.Close();
        }
    }

    //--------------------------------------------------
    private static string GetMachineIP()
    {
        string ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (ipAddress == null)
            ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        else
        {
            string[] tempip = ipAddress.Split(new char[] { ',' });
            ipAddress = tempip[0];
        }
        //fortest
        if (ipAddress == "127.0.0.1") ipAddress = "192.168.214.25";
        return ipAddress;
    }



}