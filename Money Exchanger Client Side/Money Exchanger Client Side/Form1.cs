using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Money_Exchanger_Server_Side;
using System.Drawing.Printing;

namespace Money_Exchanger_Client_Side
{
    public partial class Form1 : Form
    {
      static string user_name="", user_password="";
        LoginForm loginform;
        ViewRates viewrates;
        static String ServerIP = "127.0.0.1";
        static int ServerPort = 2222;
        static String ServerServiceName = "RemoteObject";
        ServerInterface remoteObject;
        DataSet rates_dataset;
        ExchangeForm exchangeform;
        CurrencyList mycurrencylist = new CurrencyList();
        BillForm billform;
        ChangePassword changepassword;
        public Form1()
        {   
            loginform = new LoginForm();
            viewrates = new ViewRates();
            exchangeform = new ExchangeForm();
            changepassword = new ChangePassword();
            billform = new BillForm();
            InitializeComponent();
            ConnectToServer();
            this.menuStrip.Visible = false;
            this.toolStrip1.Visible = false;
            // ShowLoginPanel(); // uncomment it

            loginform.textBoxUserName.Text = "ali"; //--
            loginform.textBoxPassword.Text = "ali"; //--
            LoginForm_ButtonLogin(); //--

            Add_All_Event_Handlers();
        }
        void Add_All_Event_Handlers()
        {
            exchangeform.buttonDone.Click += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ButtonDone();
            };
            exchangeform.buttonCancle.Click += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ButtonCancel();
            };
            loginform.buttonLogin.Click += delegate(object o, EventArgs eg)
            {
                LoginForm_ButtonLogin();
            };
            viewrates.buttonRefresh.Click += delegate(object o, EventArgs eg)
            {
                UpdateRatesFromServer();
            };
            exchangeform.comboBoxCurrency.SelectedValueChanged += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ChangeListener();
            };
            exchangeform.radioButtonBuy.Click += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ChangeListener();
            };
            exchangeform.radioButtonSell.Click += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ChangeListener();
            };
            billform.printDocument1.PrintPage += delegate(object sender, System.Drawing.Printing.PrintPageEventArgs e)
            {
                BillForm_PrintDocument(sender,e);
            };
            billform.buttonPrintBill.Click += delegate(object o, EventArgs eg)
            {
                BillForm_ButtonPrint();
            };
            exchangeform.textBoxAmount.TextChanged += delegate(object o, EventArgs eg)
            {
                ExchangeForm_ChangeListener();
            };
            changepassword.buttonChange.Click += delegate(object o, EventArgs eg)
            {
                ChangePassword_ButtonChange();
            };
        }
        void ChangePassword_ButtonChange()
        {
            changepassword.labelMessege.Text="";
            String error = "",curp="",newp="";
            bool er = false;
            curp=changepassword.textBoxPass.Text;
            if (!user_password.Equals(curp))
            {
                error = "Incorrect Current Password\n";
                er = true;
            }
            if (changepassword.textBoxNewPass.Text != changepassword.textBoxRePass.Text)
            {
                error = "New and Re-Entr New Passord Not Match\n";
                er = true;
            }
            else newp = changepassword.textBoxNewPass.Text;
            if (er)
                changepassword.labelMessege.Text = error;
            else
            {
                try
                {
                    if (remoteObject.ChanegeUserPasswod(user_name, user_password, newp))
                    {
                        user_password = newp;
                        changepassword.labelMessege.Text = "Password Changed Successfully";
                        changepassword.textBoxPass.Text = "";
                        changepassword.textBoxNewPass.Text = "";
                        changepassword.textBoxRePass.Text = "";
                    }
                    else
                        changepassword.labelMessege.Text = "Password Cannot Changed";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Form1.ChangePassword_ButtonChange()" + ex.Message);
                }
            }
        } // eof ChangePassword_ButtonChange()
        void ExchangeForm_ButtonCancel()
        {
            exchangeform.textBoxCName.Text = "";
            exchangeform.textBoxCNIC.Text = "";
            exchangeform.textBoxCell.Text = "";
            exchangeform.textBoxAmount.Text = "";
        }
        void ViewMySalesThisLogin()
        {
            MessageBox.Show("Implement-ViewMySalesThisLogin");
        }
        void BillForm_PrintDocument(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(billform.panelBill.Width, billform.panelBill.Height, billform.panelBill.CreateGraphics());
            billform.panelBill.DrawToBitmap(bmp, new Rectangle(0, 0, billform.panelBill.Width, billform.panelBill.Height));
            RectangleF bounds = e.PageSettings.PrintableArea;
            float factor = ((float)bmp.Height / (float)bmp.Width);
            e.Graphics.DrawImage(bmp, bounds.Left, bounds.Top, bounds.Width, factor * bounds.Width);
        }
        void BillForm_ButtonPrint()
        {   /*
            System.Drawing.Printing.PrintDocument doc = new System.Drawing.Printing.PrintDocument();
            doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(BillForm_PrintDocument);
            doc.Print();
            */

            // billform.printDocument1
             // Method 1
            billform.printDocument1 = new System.Drawing.Printing.PrintDocument();
            billform.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(BillForm_PrintDocument);
            billform.printDocument1.Print();
            


            // Method2
            /*
            PrintDialog myPrintDialog = new PrintDialog();
            PrintPreviewDialog printPreviewDialog1=new PrintPreviewDialog();
            PrinterSettings values;
            values = myPrintDialog.PrinterSettings;
            myPrintDialog.Document = billform.printDocument1;
            billform.printDocument1.PrintController = new StandardPrintController();
            billform.printDocument1.PrintPage +=
            new System.Drawing.Printing.PrintPageEventHandler(BillForm_PrintDocument);
            printPreviewDialog1.Document = billform.printDocument1;
            printPreviewDialog1.ShowDialog();
             */ 
        }
        void ExchangeForm_ChangeListener()
        {
            string st = mycurrencylist.Get_Cur_ID(exchangeform.comboBoxCurrency.Text);

            bool by = exchangeform.radioButtonBuy.Checked;
            float rate = 0,amount=0;
            //MessageBox.Show(st);
            if (by)
                rate= mycurrencylist.Get_Cur_Buy(st);
            else
                rate = mycurrencylist.Get_Cur_Sell(st);
            exchangeform.labelRateOfSelected.Text = ""+rate;
            if (exchangeform.textBoxAmount.Text != "")
                amount = float.Parse(exchangeform.textBoxAmount.Text);
             exchangeform.labelTotal.Text = ""+Math.Round(rate*amount,2);
        }
        void ExchangeForm_ButtonDone()
        {
            exchangeform.cname = ""; exchangeform.cnic = ""; exchangeform.cell = ""; exchangeform.cur_symbol = "";
            exchangeform.buy=false;
            exchangeform.rate = 0;
            exchangeform.amount = 0;
            exchangeform.id = -1;

            exchangeform.cname = exchangeform.textBoxCName.Text;
            exchangeform.cnic = exchangeform.textBoxCNIC.Text;
            exchangeform.cell = exchangeform.textBoxCell.Text;
            exchangeform.buy = exchangeform.radioButtonBuy.Checked;
            exchangeform.amount = float.Parse("" + exchangeform.textBoxAmount.Text);
            exchangeform.rate = float.Parse("" + exchangeform.labelRateOfSelected.Text);
            exchangeform.cur_symbol = mycurrencylist.Get_Cur_ID(exchangeform.comboBoxCurrency.Text);

            /*MessageBox.Show("Request For\n" + exchangeform.cname + "\n" + exchangeform.cnic + "\n" + exchangeform.cell + "\n" +
                exchangeform.buy + "\n" + exchangeform.comboBoxCurrency.Text + "\n" + exchangeform.cur_symbol + 
                "\n" + exchangeform.rate + "\n" + exchangeform.amount);*/ //--
            try
            {
                exchangeform.id = remoteObject.Transaction(user_name,exchangeform.cname, exchangeform.cnic, exchangeform.cell, 
                    exchangeform.buy, exchangeform.cur_symbol, exchangeform.rate, exchangeform.amount);
                if (exchangeform.id > 0)
                {
                    //MessageBox.Show("Transaction Successfull ID=" + exchangeform.id);//--
                    ViewCustomerBill();
                }
                else MessageBox.Show("Transaction Cannot proceed");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Form1-ExchangeForm_ButtonDone()-exchangeform.buttonDone\n" + ex.Message);
            }
        }
        void ViewCustomerBill()
        {
            // exchangeform
            billform.labelCName.Text = exchangeform.cname;
            billform.labelCNIC.Text = exchangeform.cnic;
            billform.labelCell.Text = exchangeform.cell;
            billform.labelDate.Text = DateTime.Now.ToString("HH:mm:ss tt dd-MM-yyyy");

            if(exchangeform.buy) billform.labelBuyOrCell.Text = "Sell"; // we are buying customer is selling
            else billform.labelBuyOrCell.Text = "Buy"; // we are selling customer is buying
            
            billform.labelCurrencyForiegn.Text = exchangeform.cur_symbol;
            billform.labelRate.Text = ""+exchangeform.rate;
            billform.labelAmount.Text = ""+exchangeform.amount;
            billform.labelTotal.Text = "" + (Math.Round((exchangeform.rate * exchangeform.amount), 2));

            if (exchangeform.buy) billform.labelCustReceived.Text = billform.labelTotal.Text+" PKR"; // we are buying customer is selling
            else billform.labelCustReceived.Text = exchangeform.amount + " " + exchangeform.cur_symbol; // we are selling customer is buying
            
            billform.labelSalesman.Text = user_name.ToUpper();

            billform.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(billform.panelMain);
        }
        void UpdateRatesFromServer() 
        {
            rates_dataset = remoteObject.GetLatestRatesFromServer();
            string curid = ""; float by=0, sel=0;
            try
            {
                viewrates.dataGridView1.DataSource = rates_dataset.Tables[0];
            DataTable dt = rates_dataset.Tables[0];
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
            catch (Exception ex) {
                MessageBox.Show("UpdateRatesFromServer:Exception\n" + ex.Message);
            }
        }
        void LoginForm_ButtonLogin() 
        {
            loginform.buttonLogin.Enabled = false;
            user_name = loginform.textBoxUserName.Text;
            user_password = loginform.textBoxPassword.Text;
            try
            {
                if (remoteObject.SalesMan_Login(user_name, user_password))
                {
                    this.Height = 651;
                    this.Width= 620;
                    this.toolStrip1.Visible = true;
                    this.menuStrip.Visible = true;
                    this.Refresh();
                    UpdateRatesFromServer();
                    ShowViewRates();
                    //MessageBox(
                    //this.panelUpper
                }
                else MessageBox.Show("Invalid Username Or Passowrd");
            }
            catch (System.Net.Sockets.SocketException sock)
            {
                MessageBox.Show("Server Not Reponding");
            }
            loginform.buttonLogin.Enabled = true;
        }
        bool ShowViewRates() {
            bool ret = false;
            viewrates.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(viewrates.panelMain);
            return ret;
        }
        bool ConnectToServer() 
        {
            bool success = false;
            try
            {
                remoteObject = (ServerInterface)Activator.GetObject(typeof(ServerInterface),
                "tcp://" + ServerIP + ":" + ServerPort + "/" + ServerServiceName);
                success = true;
            }
            catch (System.Net.Sockets.SocketException sock)
            {
                MessageBox.Show("SocketException: Server Is not Running");
            }
            catch (System.Reflection.TargetInvocationException tg)
            {
                MessageBox.Show("TargetInvocationException");
            }
            return success;
        } 
        private void ShowLoginPanel() {
            loginform.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(loginform.panelMain);
        }
        private void ShowExchangePanel() {
            loginform.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(exchangeform.panelMain);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonExchange_Click(object sender, EventArgs e)
        {
            ShowExchangePanel();
        }

        private void toolStripButtonRates_Click(object sender, EventArgs e)
        {
                ShowViewRates();
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            ViewCustomerBill();
        }

        private void printLastBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCustomerBill();
        }

        private void toolStripButtonViewMySales_Click(object sender, EventArgs e)
        {
            ViewMySalesThisLogin();
        }

        private void viewMySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMySalesThisLogin();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepassword.textBoxPass.Text = "";
            changepassword.textBoxNewPass.Text = "";
            changepassword.textBoxRePass.Text = "";
            changepassword.labelMessege.Text = "";
            changepassword.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(changepassword.panelMain);
        }

    }
}
