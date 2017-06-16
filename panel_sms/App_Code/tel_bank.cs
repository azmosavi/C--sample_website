using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
/// <summary>
/// Summary description for tel_bank
/// </summary>
public class tel_bank
{
	
	public tel_bank()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet telbank_stat(string s, out string errormessage)
    {

    errormessage="";
    DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
       
         
            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

             errormessage = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }

    public DataSet telbank_vorood(string s)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select DATE_FORMAT(lastlog,'%y/%m/%d') as lastlog from (SELECT Usrid,max(LoginDate) lastlog FROM SESSIONS  where usrid="+s+" group by Usrid)t", MySqlConnection);
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

    public DataSet saghf(string s)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select concat(srvnamef, consnamef) des, UserSrvConsNumVal saghf from (SELECT * FROM USERSRVCONS U where userid=422)t3 join (select * from SYSSRVCONS where (srvdescid=210) or (srvdescid=211) )t4 on t3.syssrvconsid=t4.syssrvconsid join (SELECT * FROM SRVDESCS )t2 on t2.srvdescid=t4.srvdescid;", MySqlConnection);
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