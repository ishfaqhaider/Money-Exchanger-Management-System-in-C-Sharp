using System;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;
using Mone_Exchange_Owner_Side;

namespace Money_Exchanger_Server_Side
{
    public class DBHandling
    {
        public OracleConnection oracleconnection;
        public OracleCommand oraclecommand;
        public OracleDataReader oracledatareader;
        public string servicename = "ORCL";
        public string username = "money";
        public string password = "exchanger";
        public int port = 1521;
        static uint Rate_ID = 0;
        static uint Collections_ID = 0;
        static uint Customer_ID = 0;
        static uint Exchange_ID = 0;


        public DBHandling()
        {/*
            oracleconnection = new OracleConnection();
            oraclecommand = new OracleCommand();
            oracleconnection.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=" + servicename + ")));User Id=" + username + ";Password=" + password;         
            // oracledatareader -- no need to assign new var
            // just do when need --> oracledatareader = oraclecommand.ExecuteReader();
            oraclecommand.Connection = oracleconnection;
          */ 
        }

        public DBHandling(string ser = "ORCL", int por = 1521, string un = "money", string pas = "exchanger")
        {
            if (ser != "") servicename = ser;
            if (un != "") username = un;
            if (pas != "") password = pas;
            if (por > 0) port = por;

            oracleconnection = new OracleConnection();
            oraclecommand = new OracleCommand();
            // oracledatareader -- no need to assign new var
            // just do when need --> oracledatareader = oraclecommand.ExecuteReader();
            oraclecommand.Connection = oracleconnection;
        }

        public bool DatabaseOn()
        {
            oracleconnection = new OracleConnection();
            oraclecommand = new OracleCommand();
            oracleconnection.ConnectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
            "(HOST=localhost)(PORT=" + port + ")))(CONNECT_DATA=(SERVER=DEDICATED)" +
            "(SERVICE_NAME=" + servicename + ")));User Id=" + username + ";Password=" + password;
            oraclecommand.Connection = oracleconnection;

            System.Console.WriteLine("2");
            System.Console.WriteLine("source: " + oracleconnection.DataSource); //--

            try
            {
                oracleconnection.Open();
                oraclecommand.Connection = oracleconnection;
                System.Console.WriteLine("Db operation finish"); //--
                Execute_Query("alter session set nls_date_format = 'dd/mm/yyyy hh24:mi:ss'");//-- set date fromat
                Set_Vars();
                return true;
            }
            catch (InvalidOperationException ex)
            {
                System.Console.WriteLine("InvalidOperationException:" + ex.Message);
                oracleconnection.Close();
                oracleconnection.Dispose();
                return false;
            }
            catch (OracleException ex)
            {
                System.Console.WriteLine("OracleException:" + ex.Message);
                oracleconnection.Close();
                oracleconnection.Dispose();
                return false;
            }
            catch (SystemException ex)
            {
                System.Console.WriteLine("Exception:" + ex.Message);
                oracleconnection.Close();
                oracleconnection.Dispose();
                return false;
            }
        } //   public bool DatabaseOn()

        public bool DatabaseOff()
        {
            bool ret = false;
            try
            {
                oracledatareader.Close();
                oracledatareader.Dispose();
                oraclecommand.Dispose();
                //oracleconnection.
                oracleconnection.Close();
                oracleconnection.Dispose();
                ret = true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception:" + ex.Message);
                ret = false;
            }
            return ret;
        } // eof public bool DatabaseOff()

        private OracleDataReader Execute_Query(string st)
        {
            OracleDataReader odr = null;
            OracleCommand ocmd = new OracleCommand(st, this.oracleconnection);
            System.Console.WriteLine("Executing:" + st);
            try
            {
                odr = ocmd.ExecuteReader();
            }
            catch (OracleException ex)
            {
                odr.Close();
                odr = null;
            }
            return odr;
        } // Execute_Query(string st)

        private void Set_Vars() { // set Ids of database
            Set_Rate_ID();
            Set_Collections_ID();
            Set_Customer_ID();
            Set_Exchange_ID();
        }
        private void Set_Rate_ID() {
            String st = "select rates_id from rates order by rates_id desc";
            OracleDataReader odr = Execute_Query(st);
            if (odr.Read())
            {   st=odr.GetOracleValue(0).ToString();
                Rate_ID=uint.Parse(st);
            }
            else Rate_ID = 0;
        }

        public uint GetNewCollectionID() 
        {
            uint temp=++Collections_ID;
            Execute_Insert("insert into collections(collect_id,collect_time) values ("+
                temp+",to_date('"+
                MyDateTimeFormatter.Convert_To_OracleDate(DateTime.Now)+"','dd/mm/yyyy hh24:mi:ss') )");
            return temp;
        }

        private void Set_Collections_ID()
        {
            String st = "select collect_id from collections order by collect_id desc";
            OracleDataReader odr = Execute_Query(st);
            if (odr.Read())
            {
                st = odr.GetOracleValue(0).ToString();
                Collections_ID = uint.Parse(st);
            }
            else Collections_ID = 0;
        }
        private void Set_Customer_ID()
        {
            String st = "select customers_id from customers order by customers_id desc";
            OracleDataReader odr = Execute_Query(st);
            if (odr.Read())
            {
                st = odr.GetOracleValue(0).ToString();
                Customer_ID = uint.Parse(st);
            }
            else Customer_ID = 0;
        }
        private void Set_Exchange_ID()
        {
            String st = "select exchanges_id from exchanges order by exchanges_id desc";
            OracleDataReader odr = Execute_Query(st);
            if (odr.Read())
            {
                st = odr.GetOracleValue(0).ToString();
                Exchange_ID = uint.Parse(st);
            }
            else Exchange_ID = 0;
        }

        private bool Execute_Insert(string st)
        {
            bool ret = false;
            OracleCommand ocmd = new OracleCommand(st);
            ocmd.Connection = this.oracleconnection;
            try
            {
                ocmd.ExecuteReader();
                //ocmd.CommandText = "commit";
                //ocmd.ExecuteReader();
                ret = true;
            }
            catch (OracleException ex)
            {
                MessageBox.Show("DBHandling-Execute_Insert-OracleException: " + ex.Message);
                ret = false;
            }
            finally
            {
                ocmd.Dispose();
            }
            return ret;
        } // Execute_Insert(string st)

        public bool Valid_SalesMan(string un, string pas)
        {
            bool ret = false;
            OracleDataReader odr;
            odr = Execute_Query(MyQueryBuilder.Select_Salesman_Pass(un, pas));
            if (odr.Read() && odr.GetOracleValue(0).ToString().Equals(un))
                ret = true;
            return ret;
        } // Valid_SalesMan(string un, string pas)

        public bool SalesMan_Exist(string un)
        {
            bool ret = false;
            OracleDataReader odr;
            odr = Execute_Query(MyQueryBuilder.Select_Salesman_Only(un));
            if (odr.Read() && odr.GetOracleValue(0).ToString().Equals(un))
                ret = true;
            return ret;
        } // SalesMan_Exist(string un)

        public bool Add_SalesMan(string un, string pas)
        {
            OracleDataReader odr;
            bool ret = false;
            try
            {
                if (!SalesMan_Exist(un))
                    Add_SalesMan_Force(un, pas);
                odr = Execute_Query("" + MyQueryBuilder.Select_Salesman_Pass(un, pas));
                if (odr.Read() && odr.GetOracleValue(0).ToString().Equals(un))
                    ret = true;
            }
            catch (OracleException ex)
            {
                return ret;
            }
            return ret;
        } // Add_SalesMan(string un, string pas)

        private bool Add_SalesMan_Force(string un, string pas)
        {
            bool ret = false;
            if (Execute_Insert(MyQueryBuilder.Insert_Salesman(un, pas)))
                ret = true;
            return ret;
        } // Add_SalesMan_Force(string un, string pas)

        public bool Add_Rates_ToDB(String frm,String to,float rate, uint collectid){
            String st = MyQueryBuilder.Insert_Rate(++Rate_ID, frm, to,
            collectid, rate);
            //MessageBox.Show("Insert :" + st); //--
            return Execute_Insert(st);
        }
        public DataSet GetCurrRates(String cur)
        {
            OracleCommand ocmd;
            OracleDataAdapter adp;
            DataSet ds = new DataSet();
            try
            {
                ocmd = oracleconnection.CreateCommand();
                ocmd.CommandText = "" + MyQueryBuilder.Query_Currency_Buy_Sell(cur, Collections_ID);
                adp = new OracleDataAdapter(ocmd);
                adp.Fill(ds);
            }
            catch (InvalidOperationException ex)
            { 
            MessageBox.Show("InvalidOperationException in " +
                "\nMoney_Exchanger_Server_Side-DBHandling-GetCurrRates("+cur+")\n"+
                ex.Message);
            ds.Clear();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("OracleException in " +
            "\nMoney_Exchanger_Server_Side-DBHandling-GetCurrRates(" + cur + ")\n" +
                ex.Message);
            ds.Clear();
            }

            catch (SystemException ex)
            {
            MessageBox.Show("Exception in "
                +"\nMoney_Exchanger_Server_Side-DBHandling-GetCurrRates("+cur+")\n"+
                 ex.Message);
            ds.Clear();
            }                
            return ds;
        } // eof public DataSet GetCurrRates
        public int RateID(string cur, bool by, float rate)
        {
            int id = -1;
            OracleDataReader odr;
            try
            {
                odr = this.Execute_Query(MyQueryBuilder.Query_RateID(cur, by, rate));
                if (odr.Read())
                    id = int.Parse(odr.GetOracleValue(0).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBHandling.RateID():" + ex.Message);
                id = -1;
            }
            return id;
        }
        public int Add_Customer(string name, string cnic, string cell)
        {   int id = -1;
        id = Customer_Exist(cnic);
        if (id <= 0)
            Add_Customer_Force(name, cnic, cell);
        id = Customer_Exist(cnic);
        return id;         
        }
        private bool Add_Customer_Force(string name, string cnic, string cell)
        {
            bool ret = false;
            int id = int.Parse((++Customer_ID)+"");
            if (  Execute_Insert( MyQueryBuilder.Insert_Customer(id,name, cnic, cell) )  )
                ret = true;
            return ret;
        } // Add_Customer_Force(string name, string cnic, string cell)
        public int Customer_Exist(string cnic)
        {
            int ret = -1;
            OracleDataReader odr;
            try
            {
                odr = Execute_Query(MyQueryBuilder.Select_CustomerID_Only(cnic));
                if (odr.Read())
                    ret = int.Parse(odr.GetOracleValue(0).ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBHandling.Customer_Exist():" + ex.Message);
                ret = -1;
            }
            return ret;
        } // SalesMan_Exist(string un)
        public int Exchange(string operat, int cust_id, int rates_id, float exchanges_amount)
        {   int id =-1;
            string query = "";
            try
            {
                id = int.Parse((++Exchange_ID) + "");
                query = MyQueryBuilder.Insert_Exchange(id, cust_id, rates_id,operat,
                    exchanges_amount, MyDateTimeFormatter.Convert_To_OracleDate(DateTime.Now));
                if(!this.Execute_Insert(query))
                    id = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DBHandling.Exchange():" + ex.Message);
                id = -1;
            }
            return id;
        }
        public bool ChanegeUserPasswod_DBH(string un, string oldpass, string newpass)
        {
            bool ret = false;
            ret=this.Execute_Insert(MyQueryBuilder.ChangePassword(un, oldpass, newpass));
            return ret;
        }
        public DataSet GetCurrSaleReports(String cur, DateTime fm, DateTime to)
        {
            OracleCommand ocmd;
            OracleDataAdapter adp;
            DataSet ds = new DataSet();
            String temp = "";
            try
            {
                ocmd = oracleconnection.CreateCommand();
                temp=MyQueryBuilder.CurrSaleReport(cur, 
                MyDateTimeFormatter.Convert_To_OracleDate(fm), MyDateTimeFormatter.Convert_To_OracleDate(to));
                
                /*  //----//
                TextBoxForm tbf = new TextBoxForm();
                tbf.textBox1.Text = temp;
                tbf.Show();
                MessageBox.Show("Temp:\n" + temp);
                // */

                ocmd.CommandText =temp;
                adp = new OracleDataAdapter(ocmd);
                adp.Fill(ds);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("InvalidOperationException in " +
                    "\nMoney_Exchanger_Owner_Side-DBHandling-GetCurrSaleReports(" + cur + ")\n" +
                    ex.Message);
                ds.Clear();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("OracleException in " +
            "\nMoney_Exchanger_Owner_Side-DBHandling-GetCurrSaleReports(" + cur + ")\n" +
                ex.Message);
                ds.Clear();
            }

            catch (SystemException ex)
            {
                MessageBox.Show("Exception in "
                    + "\nMoney_Exchanger_Owner_Side-DBHandling-GetCurrSaleReports(" + cur + ")\n" +
                     ex.Message);
                ds.Clear();
            }
            return ds;
        }
        ////
        public DataSet GetSalesManList()
        {
            OracleCommand ocmd;
            OracleDataAdapter adp;
            DataSet ds = new DataSet();
            String temp = "";
            try
            {
                ocmd = oracleconnection.CreateCommand();
                temp = "select * from users";
                ocmd.CommandText = temp;
                adp = new OracleDataAdapter(ocmd);
                adp.Fill(ds);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("InvalidOperationException in " +
                    "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManList\n" +
                    ex.Message);
                ds.Clear();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("OracleException in " +
            "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManList\n" +
                ex.Message);
                ds.Clear();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Exception in "
                    + "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManList\n" +
                     ex.Message);
                ds.Clear();
            }
            return ds;
        }

        public DataSet GetSalesManReportDBH(String salesman,DateTime fm, DateTime to)
        {
            OracleCommand ocmd;
            OracleDataAdapter adp;
            DataSet ds = new DataSet();
            String temp = "";
            try
            {
                ocmd = oracleconnection.CreateCommand();
                temp = MyQueryBuilder.SalesManReport(salesman,
                MyDateTimeFormatter.Convert_To_OracleDate(fm), MyDateTimeFormatter.Convert_To_OracleDate(to));
                ocmd.CommandText = temp;
                adp = new OracleDataAdapter(ocmd);
                adp.Fill(ds);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("InvalidOperationException in " +
                    "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManReportDBH\n" +
                    ex.Message);
                ds.Clear();
            }
            catch (OracleException ex)
            {
                MessageBox.Show("OracleException in " +
            "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManReportDBH\n" +
                ex.Message);
                ds.Clear();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Exception in "
                    + "\nMoney_Exchanger_Owner_Side-DBHandling-GetSalesManReportDBH\n" +
                     ex.Message);
                ds.Clear();
            }
            return ds;
        }
    } // DBHandling
}