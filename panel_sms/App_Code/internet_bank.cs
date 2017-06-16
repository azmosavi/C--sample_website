using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for internet_bank
/// </summary>
public class internet_bank
{

  
	public internet_bank()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet isuser(string s, out string errormessage)
    {

        errormessage = "";
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


    public DataSet saghf(string s)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select concat(srvnamef, consnamef) as des, UserSrvConsNumVal as saghf from (SELECT * FROM USERSRVCONS U where userid="+s+")t3 join (select * from SYSSRVCONS where (srvdescid=4) or (srvdescid=30) or (srvdescid=34))t4 on t3.syssrvconsid=t4.syssrvconsid join (SELECT * FROM SRVDESCS )t2 on t2.srvdescid=t4.srvdescid;", MySqlConnection);
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