using System;

public class MyDateTimeFormatter {
    
    public static DateTime Convert_To_DateTime(String oracle_date){
        //oracle_date = "04/11/2014 20:03:44"; // sample oracle format
        DateTime dt;
        dt = new DateTime(
            Convert.ToInt32(oracle_date.Substring(6, 4)),
            Convert.ToInt32(oracle_date.Substring(3, 2)),
            Convert.ToInt32(oracle_date.Substring(0, 2)),
            Convert.ToInt32(oracle_date.Substring(11, 2)),
            Convert.ToInt32(oracle_date.Substring(14, 2)),
            Convert.ToInt32(oracle_date.Substring(17, 2)));
        return dt;
    }
    public static String Convert_To_OracleDate(DateTime cs_datetime) {
        //oracle_date = "04/11/2014 20:03:44"; // sample oracle format
        String oracledateformat="";
        oracledateformat = cs_datetime.ToString("dd/MM/yyyy HH:mm:ss");
        return oracledateformat;
    }
    
}

/*
in C# you need to cast your date using this format same as you required
 
 Collapse | Copy Code
DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")
 

and while using oracle you need to cast it back to your Date, you can use this format in oracle
 
 Collapse | Copy Code
SELECT TO_CHAR(sysdate,'MM/dd/yyyy hh:mi:ss AM') from dual
*/