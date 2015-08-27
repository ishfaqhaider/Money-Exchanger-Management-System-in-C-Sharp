using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Money_Exchanger_Server_Side;
namespace Mone_Exchange_Owner_Side
{
    public partial class MainForm : Form
    {
        Login loginform;
        ViewRates viewrates;
        CalanderReports calanderreports;
        SalesManReports salesmanreports;
        DataSet data_set_cur_rates;
        DataSet data_set_CalanderReports;
        DataSet data_set_salesman_list;
        DataSet data_set_salesman_report;
        CurrencyList curlist;
        CurrencyList mycurrencylist;
        const string username = "admin";
        string password = "";
        ServerImplementation simpl;

        public MainForm()
        {
            data_set_CalanderReports = new DataSet();
            data_set_salesman_list = new DataSet();
            data_set_salesman_report = new DataSet();
            mycurrencylist = new CurrencyList();
            loginform = new Login();
            viewrates = new ViewRates();
            calanderreports = new CalanderReports();
            salesmanreports = new SalesManReports();
            simpl = new ServerImplementation();
            curlist = new CurrencyList();
            simpl.Start_Server_Manually();

            RefreshSalesManList();

            InitializeComponent();
            this.menuStrip1.Visible = false;
            this.toolStrip1.Visible = false;
            LoadLoginForm();
            Add_All_Action_Listners();


            // for bypass login window in devlopment mode
            loginform.textBoxUsername.Text = "admin";//--
            loginform.textBoxPass.Text = "admin";//--
            LoginForm_Button_Login();//--
        }


        void Add_All_Action_Listners()
        {
            loginform.buttonLogin.Click+= delegate(object o, EventArgs eg)
            {
                LoginForm_Button_Login();
            };
            viewrates.buttonRefresh.Click += delegate(object o, EventArgs eg)
            {
                UpdateRatesDataset();
            };
            calanderreports.buttonView.Click += delegate(object o, EventArgs eg)
            {
                ViewCalenderReports_BT_View();
            };
            salesmanreports.buttonView.Click += delegate(object o, EventArgs eg)
            {
                ViewSalesManReports_BT_View();
            };
        }
        void ViewSalesManReports_BT_View()
        {
            DateTime f = salesmanreports.dateTimePickerFrom.Value;
            DateTime t = salesmanreports.dateTimePickerTo.Value;
            DateTime frm = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
            DateTime to = new DateTime(t.Year, t.Month, t.Day, 23, 59, 59);
            String salesman_name = salesmanreports.comboBoxSales.Text;
            int i = 0;
            i = frm.CompareTo(to);
            if (i <= 0 && salesman_name != "")
            {
                // from to logic

                //MessageBox.Show(cur+"\n"+MyDateTimeFormatter.Convert_To_OracleDate(frm)+ "\n" + MyDateTimeFormatter.Convert_To_OracleDate(to) );//--
                data_set_salesman_report = simpl.GetSalesmanReport(salesman_name, frm, to);
                try
                {
                    salesmanreports.dataGridView1.DataSource = data_set_salesman_report.Tables[0];
                    salesmanreports.panelMain.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ViewSalesManReports_BT_View():Exception\n" + ex.Message);
                }
            }
            else if (i == 1)
            {
                MessageBox.Show("Please make a correct selection ");
            }
        }
        void RefreshSalesManList()
        {
            salesmanreports.comboBoxSales.Items.Clear();
            data_set_salesman_list = simpl.GetSalesManList();
            string salesman = "";
            try
            {
                DataTable dt = data_set_salesman_list.Tables[0];
                foreach (DataRow drRow in dt.Rows)
                {
                    salesman = (string)drRow[1];
                    if (salesman != "admin")
                        salesmanreports.comboBoxSales.Items.Add(salesman);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RefreshSalesManList():Exception\n" + ex.Message);
            }
        }
        void ViewCalenderReports_BT_View()
        {
            DateTime f = calanderreports.dateTimePickerFrom.Value;
            DateTime t = calanderreports.dateTimePickerTo.Value;
            DateTime frm = new DateTime(f.Year, f.Month, f.Day, 0, 0, 0);
            DateTime to = new DateTime(t.Year, t.Month, t.Day, 23, 59, 59);
            string cur = "";
            cur=curlist.Get_Cur_ID(calanderreports.comboBoxCur.Text);
            int i = 0;
            i=frm.CompareTo(to);
            if (i <= 0 && cur!="")
            {
                // from to logic

                //MessageBox.Show(cur+"\n"+MyDateTimeFormatter.Convert_To_OracleDate(frm)+ "\n" + MyDateTimeFormatter.Convert_To_OracleDate(to) );//--

                data_set_CalanderReports=simpl.GetCurrencySaleReport(cur, frm, to);
                try
                {
                    calanderreports.dataGridView1.DataSource = data_set_CalanderReports.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ViewCalenderReports_BT_View : Exception\n" + ex.Message);
                }
            }
            else if (i == 1)
            {
                MessageBox.Show("Please make a correct selection ");
            }
        }
        void ViewCalenderReports()
        {
            calanderreports.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(calanderreports.panelMain);
        }
        void ViewSalesmanReports()
        {
            salesmanreports.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(salesmanreports.panelMain);
        }
        void LoginForm_Button_Login()
        {
            if (loginform.textBoxUsername.Text == username)
            {
                password = loginform.textBoxPass.Text;
                if (simpl.SalesMan_Login(username, password))
                {
                    // view logined window
                    //MessageBox.Show("Login..."); //--
                    UpdateRatesDataset();
                    this.Size = new System.Drawing.Size(717, 688);
                    this.panelMain.Size = new System.Drawing.Size(700, 600);
                    this.menuStrip1.Visible = true;
                    this.toolStrip1.Visible = true;
                    ShowViewRates();
                }
                else
                {
                    password = "";
                    MessageBox.Show("Invalid Credentials");
                }
            }
            else
                MessageBox.Show("This module is only allowed for administrator");
        }

        void UpdateRatesDataset()
        {
            data_set_cur_rates = simpl.GetLatestRatesFromServer();
            string curid = ""; float by = 0, sel = 0;
            try
            {
                viewrates.dataGridView1.DataSource = data_set_cur_rates.Tables[0];
                viewrates.panelMain.Refresh();
                DataTable dt = data_set_cur_rates.Tables[0];
                //MessageBox.Show("Total Rows:" + dt.Rows.Count); //--
                foreach (DataRow drRow in dt.Rows)
                {   //foreach (DataColumn col in dt.Columns)
                    //  Console.WriteLine(row[col]);
                    by = 0; sel = 0;
                    //MessageBox.Show("Data:" + drRow[1] + drRow[2] + drRow[3]);//--
                    curid = (string)drRow[1];
                    by = float.Parse(drRow[2].ToString());
                    sel = float.Parse(drRow[3].ToString());
                    mycurrencylist.Set_Cur_Buy(curid, by);
                    mycurrencylist.Set_Cur_Sell(curid, sel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UpdateRatesFromServer:Exception\n" + ex.Message);
            }
        }
     
        bool ShowViewRates()
        {
            bool ret = false;
            viewrates.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(viewrates.panelMain);
            return ret;
        }

        void LoadLoginForm()
        {
            loginform.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.Size = new Size((548 + 17), (191 + 88));
            this.panelMain.Size = new Size((548), (191+25));
            this.panelMain.Controls.Add(loginform.panelMain);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ViewCalenderReports();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ViewSalesmanReports();
        }
    }
}
