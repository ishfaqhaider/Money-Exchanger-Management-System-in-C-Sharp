namespace Mone_Exchange_Owner_Side
{
    partial class CalanderReports
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCur = new System.Windows.Forms.ComboBox();
            this.buttonView = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(700, 600);
            this.panelMain.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonView);
            this.panel1.Controls.Add(this.comboBoxCur);
            this.panel1.Controls.Add(this.dateTimePickerTo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePickerFrom);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(699, 82);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(45, 8);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(199, 20);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "--";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(269, 7);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(199, 20);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // comboBoxCur
            // 
            this.comboBoxCur.FormattingEnabled = true;
            this.comboBoxCur.Items.AddRange(new object[] {
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
            this.comboBoxCur.Location = new System.Drawing.Point(477, 6);
            this.comboBoxCur.Name = "comboBoxCur";
            this.comboBoxCur.Size = new System.Drawing.Size(211, 21);
            this.comboBoxCur.TabIndex = 4;
            this.comboBoxCur.Text = "Select Currency";
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(544, 47);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(144, 23);
            this.buttonView.TabIndex = 5;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(699, 517);
            this.dataGridView1.TabIndex = 1;
            // 
            // CalanderReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 650);
            this.Controls.Add(this.panelMain);
            this.Name = "CalanderReports";
            this.Text = "CalanderReports";
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        public System.Windows.Forms.DateTimePicker dateTimePickerTo;
        public System.Windows.Forms.ComboBox comboBoxCur;
        public System.Windows.Forms.Button buttonView;
        public System.Windows.Forms.DataGridView dataGridView1;

    }
}