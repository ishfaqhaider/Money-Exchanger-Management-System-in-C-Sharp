namespace Money_Exchanger_Client_Side
{
    partial class ExchangeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxBuyCell = new System.Windows.Forms.GroupBox();
            this.radioButtonBuy = new System.Windows.Forms.RadioButton();
            this.radioButtonSell = new System.Windows.Forms.RadioButton();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelRateOfSelected = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCNIC = new System.Windows.Forms.TextBox();
            this.textBoxCell = new System.Windows.Forms.TextBox();
            this.textBoxCName = new System.Windows.Forms.TextBox();
            this.labelCNIC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxBuyCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBox1);
            this.panelMain.Location = new System.Drawing.Point(2, 1);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(600, 560);
            this.panelMain.TabIndex = 0;
            this.panelMain.Tag = "Exchange Currency";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxBuyCell);
            this.groupBox1.Controls.Add(this.labelTotal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonCancle);
            this.groupBox1.Controls.Add(this.buttonDone);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelRateOfSelected);
            this.groupBox1.Controls.Add(this.textBoxAmount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxCurrency);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCNIC);
            this.groupBox1.Controls.Add(this.textBoxCell);
            this.groupBox1.Controls.Add(this.textBoxCName);
            this.groupBox1.Controls.Add(this.labelCNIC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelName);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 536);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exchange";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBoxBuyCell
            // 
            this.groupBoxBuyCell.Controls.Add(this.radioButtonBuy);
            this.groupBoxBuyCell.Controls.Add(this.radioButtonSell);
            this.groupBoxBuyCell.Location = new System.Drawing.Point(207, 123);
            this.groupBoxBuyCell.Name = "groupBoxBuyCell";
            this.groupBoxBuyCell.Size = new System.Drawing.Size(212, 38);
            this.groupBoxBuyCell.TabIndex = 4;
            this.groupBoxBuyCell.TabStop = false;
            // 
            // radioButtonBuy
            // 
            this.radioButtonBuy.AutoSize = true;
            this.radioButtonBuy.Checked = true;
            this.radioButtonBuy.Location = new System.Drawing.Point(45, 15);
            this.radioButtonBuy.Name = "radioButtonBuy";
            this.radioButtonBuy.Size = new System.Drawing.Size(43, 17);
            this.radioButtonBuy.TabIndex = 4;
            this.radioButtonBuy.TabStop = true;
            this.radioButtonBuy.Text = "Buy";
            this.radioButtonBuy.UseVisualStyleBackColor = true;
            this.radioButtonBuy.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonSell
            // 
            this.radioButtonSell.AutoSize = true;
            this.radioButtonSell.Location = new System.Drawing.Point(142, 15);
            this.radioButtonSell.Name = "radioButtonSell";
            this.radioButtonSell.Size = new System.Drawing.Size(42, 17);
            this.radioButtonSell.TabIndex = 4;
            this.radioButtonSell.Text = "Sell";
            this.radioButtonSell.UseVisualStyleBackColor = true;
            this.radioButtonSell.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(204, 286);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(0, 13);
            this.labelTotal.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Total";
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(207, 327);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(88, 27);
            this.buttonCancle.TabIndex = 8;
            this.buttonCancle.Text = "Cancel";
            this.buttonCancle.UseVisualStyleBackColor = true;
            // 
            // buttonDone
            // 
            this.buttonDone.Location = new System.Drawing.Point(331, 327);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(88, 27);
            this.buttonDone.TabIndex = 7;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rate (PKR)";
            // 
            // labelRateOfSelected
            // 
            this.labelRateOfSelected.AutoSize = true;
            this.labelRateOfSelected.Location = new System.Drawing.Point(204, 213);
            this.labelRateOfSelected.Name = "labelRateOfSelected";
            this.labelRateOfSelected.Size = new System.Drawing.Size(0, 13);
            this.labelRateOfSelected.TabIndex = 14;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(207, 244);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(212, 20);
            this.textBoxAmount.TabIndex = 6;
            this.textBoxAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Currency";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "Afghan Afghani (AFN)",
            "Australian Dollar (A$)",
            "Bangladeshi Taka (BDT)",
            "British Pound Sterling (£)",
            "Canadian Dollar (CA$)",
            "Chinese Yuan (CN¥)",
            "Egyptian Pound (EGP)",
            "Euro (€)",
            "Hong Kong Dollar (HK$)",
            "Indian Rupee (Rs.)",
            "Indonesian Rupiah (IDR)",
            "Iranian Rial (IRR)",
            "Iraqi Dinar (IQD)",
            "Israeli New Sheqel",
            "Japanese Yen (¥)",
            "Kenyan Shilling (KES)",
            "Kuwaiti Dinar (KWD)",
            "Liberian Dollar (LRD)",
            "Libyan Dinar (LYD)",
            "Malaysian Ringgit (MYR)",
            "Moroccan Dirham (MAD)",
            "Nepalese Rupee (NPR)",
            "New Zealand Dollar (NZ$)",
            "Nigerian Naira (NGN)",
            "North Korean Won (KPW)",
            "Norwegian Krone (NOK)",
            "Omani Rial (OMR)",
            "Philippine Peso (Php)",
            "Qatari Rial (QAR)",
            "Russian Ruble (RUB)",
            "Saudi Riyal (SAR)",
            "Singapore Dollar (SGD)",
            "South African Rand (ZAR)",
            "South Korean Won ",
            "Sri Lankan Rupee (LKR)",
            "Sudanese Pound (SDG)",
            "Swedish Krona (SEK)",
            "Swiss Franc (CHF)",
            "Turkish Lira (TRY)",
            "US Dollar ($)",
            "Ukrainian Hryvnia (UAH)",
            "United Arab Emirates Dirham (AED)",
            "Yemeni Rial (YER)",
            "Zimbabwean Dollar (2009) (ZWL)"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(207, 170);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(212, 21);
            this.comboBoxCurrency.TabIndex = 5;
            this.comboBoxCurrency.Text = "Select Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Exchange Type";
            // 
            // textBoxCNIC
            // 
            this.textBoxCNIC.AccessibleDescription = "CNIC";
            this.textBoxCNIC.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxCNIC.Location = new System.Drawing.Point(207, 64);
            this.textBoxCNIC.Name = "textBoxCNIC";
            this.textBoxCNIC.Size = new System.Drawing.Size(212, 20);
            this.textBoxCNIC.TabIndex = 2;
            this.textBoxCNIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCNIC_KeyPress);
            // 
            // textBoxCell
            // 
            this.textBoxCell.Location = new System.Drawing.Point(207, 97);
            this.textBoxCell.Name = "textBoxCell";
            this.textBoxCell.Size = new System.Drawing.Size(212, 20);
            this.textBoxCell.TabIndex = 3;
            this.textBoxCell.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBoxCell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCell_KeyPress);
            // 
            // textBoxCName
            // 
            this.textBoxCName.Location = new System.Drawing.Point(207, 33);
            this.textBoxCName.Name = "textBoxCName";
            this.textBoxCName.Size = new System.Drawing.Size(212, 20);
            this.textBoxCName.TabIndex = 1;
            this.textBoxCName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCName_KeyPress);
            // 
            // labelCNIC
            // 
            this.labelCNIC.AutoSize = true;
            this.labelCNIC.Location = new System.Drawing.Point(53, 64);
            this.labelCNIC.Name = "labelCNIC";
            this.labelCNIC.Size = new System.Drawing.Size(85, 13);
            this.labelCNIC.TabIndex = 2;
            this.labelCNIC.Text = "Coustomer CNIC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coustomer Cell #";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(53, 34);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(88, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Coustomer Name";
            // 
            // ExchangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 622);
            this.Controls.Add(this.panelMain);
            this.Name = "ExchangeForm";
            this.Text = "ExchangeForm";
            this.Load += new System.EventHandler(this.ExchangeForm_Load);
            this.panelMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxBuyCell.ResumeLayout(false);
            this.groupBoxBuyCell.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelCNIC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox comboBoxCurrency;
        public System.Windows.Forms.TextBox textBoxAmount;
        public System.Windows.Forms.Label labelRateOfSelected;
        public System.Windows.Forms.Button buttonCancle;
        public System.Windows.Forms.Button buttonDone;
        public System.Windows.Forms.TextBox textBoxCNIC;
        public System.Windows.Forms.TextBox textBoxCell;
        public System.Windows.Forms.TextBox textBoxCName;
        public System.Windows.Forms.RadioButton radioButtonSell;
        public System.Windows.Forms.RadioButton radioButtonBuy;
        public System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.GroupBox groupBoxBuyCell;
        public System.Windows.Forms.GroupBox groupBox1;

    }
}