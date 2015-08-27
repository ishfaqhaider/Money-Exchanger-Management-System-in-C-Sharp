using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text.RegularExpressions; // must
using System.Net; // must
using System.IO;
using System.Globalization; // must
using System.Windows.Forms;
using System.Data; 


// Money_Exchanger_Server_Side.ServerImplementation

namespace Money_Exchanger_Server_Side
{
    public class ServerImplementation : MarshalByRefObject, ServerInterface
    {
        public string rates_ip = "";
        public string rates_port = "";
        private static int port = 2222;
        private static TcpChannel tcpchannel;
        private static bool server_is_running = false;
        private static DBHandling dbh = new DBHandling();
        public static int Total_Currencies;
        private static CurrencyList clist;
        public ServerImplementation()
        {
            port = 2222;
        }

        public ServerImplementation(int por = 2222)
        {
            port = por;
        }

        public bool Start_Server_Manually(int por)
        {
            clist = new CurrencyList();
            Total_Currencies = clist.Cur_List.Count;
            return StartServer(por);
        }
        public DataSet GetLatestRatesFromServer() 
        {
            return dbh.GetCurrRates("PKR");
        }
        public bool Stop_Server_Manually()
        {
            return StopServer();
        }

        private static bool StopServer()
        {
            if (server_is_running)
            {
                ChannelServices.UnregisterChannel(tcpchannel);
                //RemotingConfiguration.
                dbh.DatabaseOff();
                server_is_running = false;
            }
            return (!server_is_running);
        }

        private static bool StartServer(int por = 2222)
        {
            if (!server_is_running)
            {
                port = por;
                tcpchannel = new TcpChannel(port);
                ChannelServices.RegisterChannel(tcpchannel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerImplementation),
                "RemoteObject", WellKnownObjectMode.Singleton);
                server_is_running = true;
                dbh.DatabaseOn();
            }
            return server_is_running;
        }

        public bool SalesMan_Login(string uname, string password)
        {
            bool ret = false;
            System.Console.WriteLine("Before Query for : " + uname);

            if (dbh.Valid_SalesMan(uname, password)) ret = true;

            System.Console.WriteLine("After Query for : " + uname);

            return ret;
        }

        public static int Update_Rates_Base_State = 0;

        public int GetState()
        {
            return Update_Rates_Base_State;
        }
        public bool Update_PKR_Rates() {
            try
            {
                Update_Rates_Base("PKR");
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }

        private void Update_Rates_Base(String curency_id)
        {       
                Update_Rates_Base_State = 0;
                float rate;
                String temp="";
                uint collectid = dbh.GetNewCollectionID();
                foreach (Currency cur in clist.Cur_List)
                {
                    if (!curency_id.Equals(cur.Get_ID()))
                    {
                        rate = -1;
                        rate = Get_Online_Rate(cur.Get_ID(), curency_id);
                        if (rate != -1)
                        {
                            // dbh.Add_Rates_ToDB(cur.Get_ID(), curency_id, rate); // undefine 
                            //temp += "\n" + cur.Get_ID() + " to " + curency_id + "=" + rate;//--
                            rate = (float)Math.Round(rate, 4);
                            if (dbh.Add_Rates_ToDB(cur.Get_ID(), curency_id, rate, collectid))
                                {
                                temp += "\n" + cur.Get_ID() + " to " + curency_id + "=" + rate;//--
                                Update_Rates_Base_State++;
                                }
                        }
                        rate = -1;
                        rate = Get_Online_Rate(curency_id, cur.Get_ID());
                        if (rate != -1)
                        {
                            rate = (float)Math.Round( ( (1 / rate) * 1.01), 4); // profit 1 % 
                            if (dbh.Add_Rates_ToDB(curency_id, cur.Get_ID(), rate, collectid))
                                {
                                temp += "\n" + curency_id + " to " + cur.Get_ID() + "=" + rate;//--
                                Update_Rates_Base_State++;
                                }
                        }
                    }
                } // eof foreach
                MessageBox.Show("Updated: " + temp);//-- to show all hpdated in a messege box
        } // Update_Rates_Base
        private float Get_Online_Rate(String from, String to)
        {
            if (from.Equals(to))
                return 1;

            float flt = 0;
            String st = CurrencyConvertWithProxy(1, from, to, rates_ip, rates_port);
            if (float.TryParse(st, out flt))
                flt = float.Parse(st, CultureInfo.InvariantCulture.NumberFormat);
            else
                flt = -1;
            return flt;
        }
        private static string CurrencyConvertWithProxy(decimal amount, string fromCurrency, string toCurrency, string ip = "", string port = "")
        {

            //Grab your values and build your Web Request to the API
            string apiURL = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", amount, fromCurrency, toCurrency, Guid.NewGuid().ToString());

            //Make your Web Request and grab the results
            var request = WebRequest.Create(apiURL);
            if (ip != "" && port != "")
            {
                request.Proxy = new WebProxy("http://" + ip + ":" + port);
                /*
                System.Console.WriteLine("AbsoluteUri: " + uri.AbsoluteUri);
                System.Console.WriteLine("AbsolutePath: " + uri.AbsolutePath);
                System.Console.WriteLine("Host: " + uri.Host);
                System.Console.WriteLine("Port: " + uri.Port);
                System.Console.WriteLine("ToString: " + uri.ToString());
                System.Console.WriteLine("UserInfo: " + uri.UserInfo);
                 */
                //MessageBox.Show("IP: {0}\nPort: {1}"+request.Proxy.GetProxy().Host+request.Proxy.GetProxy().Port);
            }
            String re = "";
            //Get the Response
            try
            {
                var streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);
                //Grab your converted value (ie 2.45 USD)

                var result = Regex.Matches(streamReader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;
                re = result;
                re = re.Substring(0, re.IndexOf(' '));
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                re = "-1";
            }
            catch (WebException wex)
            {
                System.Console.WriteLine(wex.Message);
                re = "-1";
            }
            //Get the Result
            return re;
        }


        public int Transaction(string operat, string cname, string cnic, string cell,
            bool by, string cur_symbol, float rate, float amount)
        {
            int ret = -1;
            int rateid=dbh.RateID(cur_symbol, by, rate);
            int custid = dbh.Add_Customer(cname, cnic, cell);
            //MessageBox.Show("RateID:" + rateid + " ;CustID:" + custid); //--
            if(rateid>0 && custid>0)
                ret = dbh.Exchange(operat,custid, rateid, amount);
            //MessageBox.Show("Returning:" + ret); //--
            return ret;
        }
        public bool ChanegeUserPasswod(string un, string oldpass, string newpass)
        {
            bool ret = false;
            ret = dbh.ChanegeUserPasswod_DBH(un, oldpass, newpass);
            return ret;
        }
    } // ServerImplementation
}