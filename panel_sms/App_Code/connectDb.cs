using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

/// <summary>
/// Summary description for connectDb
/// </summary>
public class connectDb
{

   
    public connectDb()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string connFun(string s)
    {

        string s_mob = "";
        DataSet ds = new DataSet();
        string sql = "select cfimobil from cfcifindiv@report where cfcifno=" + s + "";
        string er;
        ds = retRows(sql, out er);
        s_mob = ds.Tables[0].Rows[0][0].ToString();
        return s_mob;

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

    private DataSet findcustid_hesab( string s,out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustid_hesab", conn);
        com.CommandType = CommandType.StoredProcedure;
        //com.Parameters.Add("s1", OracleType.VarChar, 50).Value = s2;
        com.Parameters.Add("s", OracleType.VarChar, 50).Value = s;
        com.Parameters.Add("cur", OracleType.Cursor).Direction = ParameterDirection.Output;
        OracleDataAdapter da = new OracleDataAdapter(com);

        try
        {
           
            conn.Open();
            da.Fill(res);
          //  int x = res.Tables[0].Rows.Count;
           // da.Dispose();
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

    private DataSet findcustid_card(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustid_card", conn);
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

    private DataSet findcustid_melli(string s, out string errormessage)
    {
        DataSet res = new DataSet();
        errormessage = "No error";
        OracleConnection conn = new OracleConnection(oradb);
        OracleCommand com = new OracleCommand("findcustid_melli", conn);
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
    

    public string retName(string s)
    {

        string sql = "select Name||'  '||Family from(select SUBSTR(c.cffulnam,INSTR(c.cffulnam,'*',1,1)+1,INSTR(c.cffulnam,'*',1,2)-INSTR(c.cffulnam,'*',1,1)-1)as Name,SUBSTR(c.cffulnam,1,INSTR(c.cffulnam,'*')-1) as Family from parsian01.cbcif@report c where c.cfcifno=" + s + ")t1";
        string er;
        DataSet ds = retRows(sql, out er);
        return ds.Tables[0].Rows[0][0].ToString();

    }

    public DataSet basic_b(string s)
    {
        DataSet ds = null;
        string sql = "select no,bc_id, bc_plc, bc_cod,bc_dat, bc_nam,bc_family, bc_pedar, cast(case when bc_sex=0 then 'مرد'  else 'زن' end as varchar2(6)) bc_sex,bc_srl,bc_codmelli, phone, email, mobil,adrs, zip , fax ,job from ( select cfcifno no, cfbookid bc_id,cfisuloc bc_plc, abrnchcod bc_cod, to_char (cfbrthdt,'YYYY/MM/DD','NLS_CALENDAR=PERSIAN') bc_dat, SUBSTR(cffulnam,INSTR(cffulnam,'*',1,1)+1,INSTR(cffulnam,'*',1,2)-INSTR(cffulnam,'*',1,1)-1)as bc_nam  ,SUBSTR(cffulnam,1,INSTR(cffulnam,'*')-1) as bc_family,SUBSTR(cffulnam,INSTR(cffulnam,'*',1,2)+1) AS bc_pedar from cbcif@report  )t1 join (select  cfcifno,cfimobil mobil, cfisexcod bc_sex,cfbooksrl bc_srl, cfissn bc_codmelli from cfcifindiv@report) t2 on t1.no=t2.cfcifno  join (select cfcifno,max(cadrzip) zip, max(concat(concat(cadrdsc1,cadrdsc2),cadrdsc3)) adrs,max(cadrphon) phone,max(cadrfax) fax,max(cadrtlx) tel,max(cadremail) email from cfcifadrs@report  group by cfcifno)t3 on  t1.no=t3.cfcifno left outer join (select cfjobdesc job, t6.cfcifno from (select * from cfjobgrp@report) t5 left outer join (select * from cfcifjob@report) t6  on t5.cfjobcode = t6.cfjobcode) t7 on t1.no = t7.cfcifno where t1.no=" + s + "";
        string er;
        ds = retRows(sql, out er);
        // return ds.Tables[0].Rows[0][0].ToString();
        return ds;

    }

    public DataSet basic_b1(string s)
    {
        string er = "";
        DataSet ds = findcustid_melli(s, out er);
        return ds;

    }

    public DataSet basic_b2(string s)
    {


        string er = "";
        // string sql1 = "exec findcustid_hesab '" + s + "'";
        //        execQuery(sql1, out er);         

        DataSet ds = findcustid_hesab(s, out er);
        // return ds.Tables[0].Rows[0][0].ToString();
        return ds;

    }



    public DataSet basic_b3(string s)
    {
       

        string er = "";
        DataSet ds = findcustid_card(s, out er);
        return ds;


    }
    public bool writelog (string s3,string s1, string s2)
    {
        
        string er = "";
        string sql = "insert into log_ccs values('"+s3+"','"+s1+"',sysdate,'"+s2+"')";
        bool res =execQuery(sql,out er);
        sql = "commit";
        res = execQuery(sql, out er);
        return res;

    }

    public DataSet log(string s)
    {
        DataSet ds = null;
        string sql = "select usercod from login where usercod="+s+"";
        string er;
        ds = retRows(sql, out er);
        // return ds.Tables[0].Rows[0][0].ToString();
        return ds;

    }
  


   


}