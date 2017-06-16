using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
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
    public DataSet extract(string s, string dat11_main, string dat21_main, out string err)
    {
        err = "";
        DataSet DataSet = new DataSet();
        MySqlConnection MySqlConnection = new MySqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            MySql.Data.MySqlClient.MySqlDataAdapter DataAdapter = new MySqlDataAdapter
                ("select ip, pan,miladitoshamsi(strdat,1) strdat,strtim,miladitoshamsi(enddat,1) enddat,endtim from(select sessionip as ip, pan,DATE_FORMAT(date(S.SessionstrtDat),'%y/%m/%d') strdat,time(S.SessionstrtDat) strtim,DATE_FORMAT(date(S.SessionEndDat),'%y/%m/%d') enddat, time(S.SessionEndDat) endtim FROM `Session` S where date(SessionStrtDat)>=" + dat11_main + " and date(SessionStrtDat)<=" + dat21_main + " and pan=" + s + " order by date(SessionStrtDat))t;", MySqlConnection);
            DataAdapter.Fill(DataSet);
            DataAdapter.Dispose();

        }
        catch (Exception ex)
        {

             err = ex.Message;
            DataSet = null;

        }
        finally
        {
            MySqlConnection.Close();
        }

        return DataSet;
    }
}