using System;
using System.Windows.Forms;
using System.Threading;
using System.Net;

namespace Money_Exchanger_Server_Side
{
    public partial class Form1 : Form
    {
        private Form2 f2;
        private ServerImplementation sim;
        private ProxySettingsForm psf;

        public Form1()
        {
            sim = new ServerImplementation();
            f2 = new Form2();
            psf = new ProxySettingsForm();
            InitializeComponent();
            OnClickMainView();
            psf.textBoxIP.Text = sim.rates_ip;
            psf.textBoxPort.Text = sim.rates_port;
            f2.buttonStop.Enabled = false;
            f2.buttonRefresh.Enabled = false;
            AddAllActionListener();
            f2.buttonStart.Click += delegate(object o, EventArgs eg)
            {
                /*new Thread(() =>
                {*/
                    f2.buttonStart.Enabled = false;
                    f2.buttonStop.Enabled = false;
                    f2.buttonRefresh.Enabled = false;
                if (sim.Start_Server_Manually(2222))
                {
                    f2.buttonStop.Enabled = true;
                    f2.buttonRefresh.Enabled = true;
                }
                else {
                     f2.buttonStart.Enabled = true;
                }
                //}).Start();
                //MessageBox.Show("Server..Run");//--
            };
            f2.buttonStop.Click += delegate(object o, EventArgs eg)
            {
                /*new Thread(() =>
                {*/
                    f2.buttonStop.Enabled = false;
                    f2.buttonRefresh.Enabled = false;
                    f2.buttonStart.Enabled = false;
                    if (sim.Stop_Server_Manually())
                    {
                        f2.buttonStart.Enabled = true;
                    }
                    else
                    {
                        //f2.buttonStop.Enabled = true;
                        //f2.buttonRefresh.Enabled = true;
                    }
                //}).Start();
                //MessageBox.Show("Server..Stop");//--
            };
            f2.buttonRefresh.Click += delegate(object o, EventArgs eg)
            {
                //Thread t1=
                /*new Thread(() =>
                {*/
                    f2.buttonRefresh.Enabled = false;
                    f2.buttonStop.Enabled = false;
                    f2.buttonStart.Enabled = false;
                    f2.Label_Left.Text = "Please wait";
                    if (sim.Update_PKR_Rates())
                    {
                        f2.Label_Left.Text = ServerImplementation.Update_Rates_Base_State + " currencies rates updated";
                    }
                    else {
                        f2.Label_Left.Text = "Cant Update Fully";
                    }
                    f2.buttonStop.Enabled = true;
                    f2.buttonRefresh.Enabled = true;
                //}).Start();
               /* new Thread(
                    () =>
                    {
                        int i = 0;
                        f2.progressBar1.Value = 0;
                        f2.progressBar1.Maximum = ServerImplementation.Total_Currencies;
                        
                        //f2.progressBar1.Visible = true;
                        f2.progressBar1.Show();
                            //ServerImplementation.Update_Rates_Base_State;
                        int change=i;
                        while (i < ServerImplementation.Total_Currencies) {
                            while (true) {
                                change = ServerImplementation.Update_Rates_Base_State;
                                if (change == i)
                                {
                                    continue;
                                }
                                else {
                                    i = change;
                                    f2.progressBar1.Value = i;
                                    f2.progressBar1.Refresh();
                                    break;
                                }
                                
                                //Thread.CurrentThread.
                            }
                        
                        }
                    }).Start();
                 */ 
                //MessageBox.Show("Server..Run");//--
            };
        }
        void AddAllActionListener()
        {
            psf.buttonOK.Click += delegate(object o, EventArgs eg)
            {
                ProxySettingsForm_OK();
            };
            psf.buttonCancel.Click += delegate(object o, EventArgs eg)
            {
                ProxySettingsForm_Cancel();
            };

        }
        void ProxySettingsForm_OK()
        {
            if (psf.textBoxIP.Text != "" && psf.textBoxPort.Text != "")
            {
                IPAddress ip;
                bool i = false, p = false;
                uint ui = 0;
                i = IPAddress.TryParse(psf.textBoxIP.Text, out ip);
                p = uint.TryParse(psf.textBoxPort.Text, out ui);
                if (i && p && ui > 0 && ui <= 65535)
                {
                    sim.rates_ip = psf.textBoxIP.Text;
                    sim.rates_port = psf.textBoxPort.Text;
                    //MessageBox.Show("IP and Port saved");//--
                    OnClickMainView();
                }
                else
                {
                    psf.textBoxIP.Text = sim.rates_ip;
                    psf.textBoxPort.Text = sim.rates_port;
                    MessageBox.Show("Please provide a valid ip and port");
                }
            }
            else
            {
                sim.rates_ip = "";
                sim.rates_port = "";
                OnClickMainView();
                //MessageBox.Show("Default IP and Port");//--
            }
        }
        void ProxySettingsForm_Cancel()
        {
            psf.textBoxIP.Text = sim.rates_ip;
            psf.textBoxPort.Text = sim.rates_port;
            OnClickMainView();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void mainViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OnClickMainView();
        }

        public void OnClickMainView()
        {
            f2.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(f2.panel1);
        }

        private void proxySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            psf.TopLevel = false;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(psf.panelMain);
        }
    }
}