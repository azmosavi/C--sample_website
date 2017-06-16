using System;
using System.Globalization;


public class dat
{

    private static PersianCalendar pc = new PersianCalendar();




public enum DateFormat
 	{
 	YY_MM_DDBHH_MM,
 	YY_MM_DD
 	} 

public static DateTime PersianToGregorian(string Date, DateFormat format)
 {
 	switch (format)
 	{
	case DateFormat.YY_MM_DD:
	{
	try
	{
	if (Date.Length != 8)
	throw new Exception("");
	int yy = int.Parse(Date.Substring(0, 2));
	int mm = int.Parse(Date.Substring(3, 2));
	int dd = int.Parse(Date.Substring(6, 2));
 	return pc.ToDateTime(yy + 1300, mm, dd, 0, 0, 0, 0);
 	}
 	catch
 	{
 	throw new Exception("");
 	}
 	}
 	case DateFormat.YY_MM_DDBHH_MM:
 	{
 	try
 	{
        if (Date.Length != 14)
            throw new Exception("");
 	int yy = int.Parse(Date.Substring(0, 2));
 	int mm = int.Parse(Date.Substring(3, 2));
 	int dd = int.Parse(Date.Substring(6, 2));
 	int hh = int.Parse(Date.Substring(9, 2));
 	int MM = int.Parse(Date.Substring(12, 2));
 	
 	return pc.ToDateTime(yy + 1300, mm, dd, hh, MM, 0, 0);
 	}
 	catch
 	{
        throw new Exception("");
 	}
 	}
 	default:
    throw new Exception("");
 	}
 	
 	
 	}
}