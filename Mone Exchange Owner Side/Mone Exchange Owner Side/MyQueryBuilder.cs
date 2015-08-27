using System;
namespace Money_Exchanger_Server_Side
{
    internal class MyQueryBuilder
    {
        public static string Insert_Salesman(string un, string pas)
        {
            string st;
            st = "insert into users(u_username,u_password) values ('" +
            un + "','" + pas + "')";
            return st;
        }

        public static string Select_Salesman_Pass(string un, string pas)
        {
            string st;
            st = "select u_username from users where u_username='" +
            un + "' and u_password='" + pas + "'";
            return st;
        }

        public static string Select_Salesman_Only(string un)
        {
            string st;
            st = "select u_username from users where u_username='" +
            un + "'";
            return st;
        }

        public static string Select_NonZero_Currency()
        {
            return "select * from currency where currency_amount!=0";
        }
        public static string Insert_Rate(uint id,string frm,string to,uint cid,float rate)
        {
        return  "insert into rates(rates_id,rates_from ,rates_to ,collect_id,rate) values("+
        id+",'"+frm+"','"+to+"',"+cid+" ,"+rate+")";
        }

        public static string Query_Currency_Buy_Sell(String cur, uint collectionid)
        {
            String ret = "";

            /*
            ret = "select cr.currency_name as Currency,  r1.rates_from as Symbol , " +
            "r1.rate as Buy , r2.rate as Sell from rates r1, rates r2 , currency cr " +
            "where " +
            "r1.rates_from=r2.rates_to and " +
            "r1.rates_to=r2.rates_from and " +
            "r1.rates_from=cr.currency_id and " +
            "r1.rates_from!='PKR' and " +
            "r1.collect_id=1 and " +
            "r2.collect_id=1";
             */
            // in PKR and round to 2 (NEW)
             ret = "select cr.currency_name as \"Currency\",  r1.rates_from as \"Symbol\" , " +
            "r1.rate as \"Buy\" , r2.rate as "+
            "\"Sell\" from rates r1, rates r2 , currency cr " +
            "where " +
            "r1.rates_from=r2.rates_to and " +
            "r1.rates_to=r2.rates_from and " +
            "r1.rates_from=cr.currency_id and " +
            "r1.rates_from!='" + cur + "' and " +
            "r1.collect_id=" + collectionid + " and " +
            "r2.collect_id=" + collectionid;
            


            // in PKR and round to 2 (OLD)
            /* ret = "select cr.currency_name as \"Currency\",  r1.rates_from as \"Symbol\" , " +
            "round(r1.rate,2) as \"Buy\" , round(((1/r2.rate)*1.01),2) as "+
            "\"Sell\" from rates r1, rates r2 , currency cr " +
            "where " +
            "r1.rates_from=r2.rates_to and " +
            "r1.rates_to=r2.rates_from and " +
            "r1.rates_from=cr.currency_id and " +
            "r1.rates_from!='" + cur + "' and " +
            "r1.collect_id=" + collectionid + " and " +
            "r2.collect_id=" + collectionid;
            */

/*          Orignal SQL Query  
select cr.currency_name as "Currency",  r1.rates_from as "Symbol" , r1.rate as "Buy" , r2.rate as "Sell" from rates r1, rates r2 , currency cr
where 
r1.rates_from=r2.rates_to and
r1.rates_to=r2.rates_from and
r1.rates_from=cr.currency_id and
r1.rates_from!='PKR' and
r1.collect_id=1 and
r2.collect_id=1;            */
return ret;
         } // Query_Currency_Buy_Sell

        public static string Query_RateID(string cur_symbol, bool by, float rate)
        {
            string temp="";
            if (by)
                temp = "select rates_id from rates where rate=" + rate + "  and rates_from='" + cur_symbol +
                    "' and rates_to='PKR' order by rates_id desc"; // -- by
            else
                temp = "select rates_id from rates where rate=" + rate + "  and rates_to='" + cur_symbol +
                    "' and rates_from='PKR' order by rates_id desc"; // -- sell
            return temp;
        }


        public static string Select_CustomerID_Only(string cnic)
        {
            return "select customers_id from customers where customers_cnic='" + cnic + "'";
        }
        public static string Insert_Customer(int id, string name, string cnic, string cell)
        {
            return "insert into customers(customers_id,customers_name,customers_cnic,customers_cell) "+
                "values ("+id+",'"+name+"','"+cnic+"','"+cell+"')";
        }
        public static string Insert_Exchange(int id, int cust_id, int rates_id, string operat,float exchanges_amount, string time)
        {
            string temp = "";
            temp = "insert into exchanges(exchanges_id, customer_fk, rates_fk ,users_fk , exchanges_amount , exchanges_time ) " +
            "values ( " + id + ", " + cust_id + "," + rates_id + " , '"+operat+"' , "+ exchanges_amount +
            ", to_date('"+time+"', 'dd/mm/yyyy hh24:mi:ss'))";
            return temp;
        }

        public static string ChangePassword(String un, String ol, String ne)
        {
            string temp = "update users set u_password='" + ne + "' where u_username='" + un + "' and u_password='" + ol + "'";
            return temp;
        }

        public static string CurrSaleReport(String cur, String date_from, String date_to)
        {
            string temp = "";
            temp = "select NVL(substr(to_date(time_to),1,10),substr(to_date(time_fm),1,10)) as \"Date\", NVL(amount_fm,0) Buy , NVL(amount_to,0) Sell" +
            " from " +
            "(" +
            "select to_date(timefm) time_fm, sum(amountfm) as amount_fm from" +
            " (select trunc(ex.exchanges_time) as timefm , ex.exchanges_amount as amountfm from exchanges ex, rates rt " +
            "where ex.rates_fk=rt.rates_id and rt.rates_from='"+cur+"'  and rt.rates_to='PKR'  " +
            "and " +
            "( trunc(ex.exchanges_time) between to_date('" + date_from + "', 'dd/mm/yyyy hh24:mi:ss')  and to_date('" + date_to + "', 'dd/mm/yyyy hh24:mi:ss') )" +
            ") " +
            "group by timefm" +
            ") FULL OUTER JOIN" +
            "(" +
            "select to_date(timeto) time_to, sum(amountto) as amount_to from" +
            " (select trunc(ex.exchanges_time) as timeto , ex.exchanges_amount as amountto from exchanges ex, rates rt " +
            "where ex.rates_fk=rt.rates_id and rt.rates_from='PKR'  and rt.rates_to='" + cur + "' " +
            "and " +
            "( trunc(ex.exchanges_time) between to_date('" + date_from + "', 'dd/mm/yyyy hh24:mi:ss')  and to_date('" + date_to + "', 'dd/mm/yyyy hh24:mi:ss') )" +
            ") " +
            "group by timeto " +
            ")" +
            "on " +
            "time_fm=time_to order by \"Date\"";
            return temp;
        }
        public static string SalesManReport(String sales_man, String date_from, String date_to)
        {
            string temp = "";
temp=
"select NVL(exida,exidb) \"Transaction ID\", NVL(extima,extimb) \"Date\", NVL(cura,curb) as \"Currency\", NVL(to_char(amounta),' ') as \"Buy\", NVL(to_char(amountb),' ') as \"Sell\" from " +
"("+
"select ex.exchanges_id exida, ex.exchanges_time as extima, rt.rates_from cura ,ex.exchanges_amount amounta from exchanges ex,rates rt "+
"where ex.rates_fk=rt.rates_id "+
"and rt.rates_to='PKR' "+
"and "+
"(     ex.exchanges_time between to_date('" + date_from + "', 'dd/mm/yyyy hh24:mi:ss')  " +
" and to_date('" + date_to + "', 'dd/mm/yyyy hh24:mi:ss')) " +
" and ex.users_fk='" + sales_man + "'" +
" ) FULL OUTER JOIN"+
" ("+
" select ex.exchanges_id exidb, ex.exchanges_time as extimb, rt.rates_to curb ,ex.exchanges_amount amountb from exchanges ex,rates rt "+
" where ex.rates_fk=rt.rates_id "+
" and rt.rates_from='PKR' "+
" and "+
"   (     ex.exchanges_time between to_date('" + date_from + "', 'dd/mm/yyyy hh24:mi:ss')  " +
" and to_date('" + date_to + "', 'dd/mm/yyyy hh24:mi:ss')) " +
" and ex.users_fk='" + sales_man + "' " +
" )"+
" on exida=exidb order by \"Date\" desc"
     ;       
            return temp;
        }

        public static string Dummy(String abc, uint efg)
        {
            string temp = "";
            return temp;
        }

    }
}