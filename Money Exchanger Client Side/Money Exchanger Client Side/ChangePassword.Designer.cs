namespace Money_Exchanger_Client_Side
{
    partial class ChangePassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.textBoxRePass = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelMessege = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelMessege);
            this.panelMain.Controls.Add(this.buttonChange);
            this.panelMain.Controls.Add(this.textBoxRePass);
            this.panelMain.Controls.Add(this.textBoxNewPass);
            this.panelMain.Controls.Add(this.textBoxPass);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Location = new System.Drawing.Point(2, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(600, 560);
            this.panelMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Current Password   :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter New Password       : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Re-Enter New Password : ";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(276, 127);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(216, 20);
            this.textBoxPass.TabIndex = 3;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.Location = new System.Drawing.Point(276, 166);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.PasswordChar = '*';
            this.textBoxNewPass.Size = new System.Drawing.Size(216, 20);
            this.textBoxNewPass.TabIndex = 4;
            // 
            // textBoxRePass
            // 
            this.textBoxRePass.Location = new System.Drawing.Point(276, 199);
            this.textBoxRePass.Name = "textBoxRePass";
            this.textBoxRePass.PasswordChar = '*';
            this.textBoxRePass.Size = new System.Drawing.Size(216, 20);
            this.textBoxRePass.TabIndex = 5;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(365, 240);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(127, 23);
            this.buttonChange.TabIndex = 1;
            this.buttonChange.Text = "Change Password";
            this.buttonChange.UseVisualStyleBackColor = true;
            // 
            // labelMessege
            // 
            this.labelMessege.AutoSize = true;
            this.labelMessege.Location = new System.Drawing.Point(118, 285);
            this.labelMessege.Name = "labelMessege";
            this.labelMessege.Size = new System.Drawing.Size(0, 13);
            this.labelMessege.TabIndex = 6;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 622);
            this.Controls.Add(this.panelMain);
            this.Name = "ChangePassword";
            this.Text = "ChangePassword";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonChange;
        public System.Windows.Forms.TextBox textBoxRePass;
        public System.Windows.Forms.TextBox textBoxNewPass;
        public System.Windows.Forms.TextBox textBoxPass;
        public System.Windows.Forms.Panel panelMain;
        public System.Windows.Forms.Label labelMessege;
    }
}