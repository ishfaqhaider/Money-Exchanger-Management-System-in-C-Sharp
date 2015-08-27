namespace Money_Exchanger_Server_Side
{
    partial class Form2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Label_Right = new System.Windows.Forms.Label();
            this.Label_Left = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.Label_Right);
            this.panel1.Controls.Add(this.Label_Left);
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 207);
            this.panel1.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(263, 24);
            this.progressBar1.Step = 100;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // Label_Right
            // 
            this.Label_Right.AutoSize = true;
            this.Label_Right.Location = new System.Drawing.Point(9, 37);
            this.Label_Right.Name = "Label_Right";
            this.Label_Right.Size = new System.Drawing.Size(0, 13);
            this.Label_Right.TabIndex = 4;
            // 
            // Label_Left
            // 
            this.Label_Left.AutoSize = true;
            this.Label_Left.Location = new System.Drawing.Point(9, 11);
            this.Label_Left.Name = "Label_Left";
            this.Label_Left.Size = new System.Drawing.Size(0, 13);
            this.Label_Left.TabIndex = 3;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(78, 121);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(116, 33);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(156, 160);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(116, 33);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop Server";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(9, 160);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(116, 33);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start Server";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button buttonRefresh;
        public System.Windows.Forms.Button buttonStop;
        public System.Windows.Forms.Button buttonStart;
        public System.Windows.Forms.ProgressBar progressBar1;
        public System.Windows.Forms.Label Label_Right;
        public System.Windows.Forms.Label Label_Left;

    }
}