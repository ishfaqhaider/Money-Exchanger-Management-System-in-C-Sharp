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
            string temp = "update users set u_password='"+ne+"' where u_username='"+un+"' and u_password='"+ol+"'";
            return temp;
        }

        public static string Dummy(String abc, uint efg)
        {
            string temp = "";
            return temp;
        }
    }
}