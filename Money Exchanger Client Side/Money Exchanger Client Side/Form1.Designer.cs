namespace Money_Exchanger_Client_Side
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelMain = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.setingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRates = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonExchange = new System.Windows.Forms.ToolStripButton();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printLastBillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.viewMySalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonViewMySales = new System.Windows.Forms.ToolStripButton();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain.Location = new System.Drawing.Point(2, 61);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(400, 400);
            this.panelMain.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.setingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(404, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // setingsToolStripMenuItem
            // 
            this.setingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem});
            this.setingsToolStripMenuItem.Name = "setingsToolStripMenuItem";
            this.setingsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.setingsToolStripMenuItem.Text = "Setings";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRates,
            this.toolStripButtonExchange,
            this.toolStripButtonPrint,
            this.toolStripButtonViewMySales});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(404, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRates
            // 
            this.toolStripButtonRates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRates.Image")));
            this.toolStripButtonRates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRates.Name = "toolStripButtonRates";
            this.toolStripButtonRates.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRates.Text = "View Rate List";
            this.toolStripButtonRates.Click += new System.EventHandler(this.toolStripButtonRates_Click);
            // 
            // toolStripButtonExchange
            // 
            this.toolStripButtonExchange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonExchange.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonExchange.Image")));
            this.toolStripButtonExchange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonExchange.Name = "toolStripButtonExchange";
            this.toolStripButtonExchange.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonExchange.Text = "Exchange";
            this.toolStripButtonExchange.Click += new System.EventHandler(this.toolStripButtonExchange_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printLastBillToolStripMenuItem,
            this.viewMySalesToolStripMenuItem});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // printLastBillToolStripMenuItem
            // 
            this.printLastBillToolStripMenuItem.Name = "printLastBillToolStripMenuItem";
            this.printLastBillToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.printLastBillToolStripMenuItem.Text = "Print Last Bill";
            this.printLastBillToolStripMenuItem.Click += new System.EventHandler(this.printLastBillToolStripMenuItem_Click);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPrint.Image")));
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPrint.Text = "toolStripButton1";
            this.toolStripButtonPrint.ToolTipText = "Print Last Bill";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // viewMySalesToolStripMenuItem
            // 
            this.viewMySalesToolStripMenuItem.Name = "viewMySalesToolStripMenuItem";
            this.viewMySalesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewMySalesToolStripMenuItem.Text = "View My Sales";
            this.viewMySalesToolStripMenuItem.Click += new System.EventHandler(this.viewMySalesToolStripMenuItem_Click);
            // 
            // toolStripButtonViewMySales
            // 
            this.toolStripButtonViewMySales.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonViewMySales.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonViewMySales.Image")));
            this.toolStripButtonViewMySales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonViewMySales.Name = "toolStripButtonViewMySales";
            this.toolStripButtonViewMySales.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonViewMySales.Text = "View My Sales";
            this.toolStripButtonViewMySales.Click += new System.EventHandler(this.toolStripButtonViewMySales_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Money_Exchanger_Client_Side.Properties.Resources._280651_Money_1319430588_273_640x480__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(404, 463);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.panelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Salesman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem setingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonRates;
        public System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonExchange;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printLastBillToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.ToolStripMenuItem viewMySalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonViewMySales;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}

