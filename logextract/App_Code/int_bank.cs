using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;



//using System.Text.ASCIIEncoding;
//using System.Text.UnicodeEncoding;
//using System.Text.UTF7Encoding;
//using System.Text.UTF8Encoding;

/// <summary>
/// Summary description for int_bank
/// </summary>
public class int_bank
{
 
	
	public int_bank()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet biger_archive(string s, string dat1, string dat2)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select clientip as ip, t3.srvnamef as service, time(t2.logintime) as logint,DATE_FORMAT(t2.logindate,'%y/%m/%d') as logind , time(t2.logouttime) as logoutt,DATE_FORMAT(t2.logoutdate,'%y/%m/%d') as logoutd,cast(concat(facctype,'-',facccif,'-',faccsrl)as char) mabda,cast(concat(sacctype,'-',sacccif,'-',saccsrl)as char) maghsad from (SELECT * FROM USERTRKS U where Userid=" + s + " )t1 join (SELECT * FROM SESSIONS S where (LoginDate>=" + dat1 + "  and logindate<=" + dat2 + " )and usrid=" + s + ")t2 on t1.Sessid=t2.Sessid join (SELECT * FROM SRVDESCS S)t3 on t1.SrvDescid=t3.Srvdescid order by logind, logoutd;", MySqlConnection);
            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

            string errormessage = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }

    public DataSet smaller_archive(string s, string dat1, string dat2)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select clientip as ip, t3.srvnamef as service, time(t2.logintime) as logint,DATE_FORMAT(t2.logindate,'%y/%m/%d') as logind , time(t2.logouttime) as logoutt,DATE_FORMAT(t2.logoutdate,'%y/%m/%d') as logoutd,cast(concat(facctype,'-',facccif,'-',faccsrl)as char) mabda,cast(concat(sacctype,'-',sacccif,'-',saccsrl)as char) maghsad  from (SELECT * FROM USERTRKS_archive_900511 U where Userid=" + s + " )t1 join (SELECT * FROM SESSIONS_archive_900511 S where (LoginDate>=" + dat1 + " and logindate<=" + dat2 + " )and usrid=" + s + " )t2 on t1.Sessid=t2.Sessid join (SELECT * FROM SRVDESCS S)t3 on t1.SrvDescid=t3.Srvdescid order by logind, logoutd;", MySqlConnection);
            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

            string errormessage = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }
    public DataSet smallest_archive(string s, string dat1, string dat2)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
              ("select clientip as ip, t3.srvnamef as service, time(t2.logintime) as logint,DATE_FORMAT(t2.logindate,'%y/%m/%d') as logind , time(t2.logouttime) as logoutt,DATE_FORMAT(t2.logoutdate,'%y/%m/%d') as logoutd,cast(concat(facctype,'-',facccif,'-',faccsrl)as char) mabda,cast(concat(sacctype,'-',sacccif,'-',saccsrl)as char) maghsad  from (SELECT * FROM USERTRKS_archive_890512 U where Userid=" + s + "  union all select * from USERTRKS_archive_910830 where Userid= " + s + ")t1 join (SELECT * FROM SESSIONS_archive_900511 S where (LoginDate>=" + dat1 + " and logindate<=" + dat2 + " )and usrid=" + s + " union select * from SESSIONS_archive_910830 where  (LoginDate>=" + dat1 + " and logindate<=" + dat2 + " )and usrid=" + s + " )t2 on t1.Sessid=t2.Sessid join (SELECT * FROM SRVDESCS S)t3 on t1.SrvDescid=t3.Srvdescid order by logind, logoutd;", MySqlConnection);

            //MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
            //    ("select clientip as ip,t3.srvnamef as service,time(t2.logintime) as logint,DATE_FORMAT(t2.logindate, '%y/%m/%d') as logind,logindate, time(t2.logouttime) as logoutt, DATE_FORMAT(t2.logoutdate, '%y/%m/%d') as logoutd, cast(concat(facctype, '-', facccif, '-', faccsrl) as char) mabda,  cast(concat(sacctype, '-', sacccif, '-', saccsrl) as char) maghsad  from (SELECT * FROM USERTRKS U where Userid =" + s + " union SELECT * FROM USERTRKS_archive_900511  where Userid = 12165742 union SELECT * FROM USERTRKS_archive_910218   where Userid = 12165742 union SELECT * FROM USERTRKS_archive_890512  where Userid = 12165742) t1  join (SELECT *   FROM SESSIONS S where  usrid = 12165742 and (LoginDate >=13910231  and logindate <=13910630) union SELECT *  FROM SESSIONS_archive_900511 where  usrid = 12165742 and (LoginDate >=13910231  and logindate <=13910630) union SELECT * FROM SESSIONS_archive_900511 where  usrid = 12165742 and (LoginDate >=13910231  and logindate <=13910630)) t2 on t1.Sessid = t2.Sessid join (SELECT * FROM SRVDESCS S) t3 on t1.SrvDescid = t3.Srvdescid order by logind, logoutd;", MySqlConnection);

            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

            string errormessage = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }

    public DataSet main_archive(string s, string dat1, string dat2)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
           
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
              ("select clientip as ip,t3.srvnamef as service,time(t2.logintime) as logint,DATE_FORMAT(t2.logindate, '%y/%m/%d') as logind,logindate, time(t2.logouttime) as logoutt, DATE_FORMAT(t2.logoutdate, '%y/%m/%d') as logoutd, cast(concat(facctype, '-', facccif, '-', faccsrl) as char) mabda,  cast(concat(sacctype, '-', sacccif, '-', saccsrl) as char) maghsad  from (SELECT * FROM USERTRKS U where Userid =" + s + " union all SELECT * FROM USERTRKS_archive_900511  where Userid = 12165742 union all SELECT * FROM USERTRKS_archive_910218   where Userid = 12165742 union all SELECT * FROM USERTRKS_archive_890512  where Userid = 12165742 union all select * from USERTRKS_archive_910830 where Userid=12165742) t1  join (SELECT *   FROM SESSIONS S where  usrid = 12165742 and (LoginDate >=13910231  and logindate <=13910630) union all SELECT *  FROM SESSIONS_archive_900511 where  usrid = 12165742 and (LoginDate >=13910231  and logindate <=13910630) union all SESSIONS_archive_910830)) t2 on t1.Sessid = t2.Sessid join (SELECT * FROM SRVDESCS S) t3 on t1.SrvDescid = t3.Srvdescid order by logind, logoutd;", MySqlConnection);

            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

            string errormessage = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }





}