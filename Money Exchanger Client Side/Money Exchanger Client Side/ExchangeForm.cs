    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    namespace Money_Exchanger_Client_Side
    {
    public partial class ExchangeForm : Form
    {
        public string cname = "", cnic = "", cell = "", cur_symbol = "";
        public bool buy = false;
        public float rate = 0, amount = 0;
        public int id = -1;
    public ExchangeForm()
    {
        InitializeComponent();
        
    }

    private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e){

    }

    private void ExchangeForm_Load(object sender, EventArgs e)
    {

    }

    private void groupBox1_Enter(object sender, EventArgs e)
    {

    }

    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void radioButton2_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void textBoxCName_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar.ToString()==" ") && textBoxCName.Text.Length < 20)
                                || 
                       e.KeyChar.Equals('\b')                   )
            e.Handled = false; 
        else e.Handled = true;
    }

    private void textBoxCNIC_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) && textBoxCNIC.Text.Length < 13)
                        ||
               e.KeyChar.Equals('\b'))
            e.Handled = false; // it means this will be handled after key up, its not yet handled
        else e.Handled = true; // it means, key has handled
    }

    private void textBoxCell_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) && textBoxCell.Text.Length < 20)
                        ||
               e.KeyChar.Equals('\b'))
            e.Handled = false; // it means this will be handled after key up, its not yet handled
        else e.Handled = true; // it means, key has handled
    }

    private void textBoxAmount_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (((char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)) && textBoxAmount.Text.Length < 8)
                ||
       e.KeyChar.Equals('\b'))
            e.Handled = false; // it means this will be handled after key up, its not yet handled
        else e.Handled = true; // it means, key has handled
    }


    }
    }
