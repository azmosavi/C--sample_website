using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;


/// <summary>
/// Summary description for sms_email
/// </summary>
public class sms_email
{

   
	public sms_email()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet sms_stat(string s, out string errormessage)
    {

        errormessage = "No error";
        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter

          
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



    public DataSet email_stat(string s, out string errormessage)
    {

        errormessage = "No error";
        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter

          
     
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


    public DataSet email_hesabha(string s)
    {

        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter

     
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