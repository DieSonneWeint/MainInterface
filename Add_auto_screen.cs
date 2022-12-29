using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface
{
    public partial class Add_auto_screen : Form
    {
        public Presenter _presenter;
        private bool nonNumberEntered = false; 
        string fuel_type = null;
        int weight=0;
        int value=0;    
        public Add_auto_screen(Presenter presenter)
        {
            _presenter= presenter;
            InitializeComponent();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fuel_type = radioButton1.Text;
            button1.Enabled = _presenter.all_enter_auto_check(weight, value, fuel_type);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            fuel_type = radioButton2.Text;
            button1.Enabled = _presenter.all_enter_auto_check(weight, value, fuel_type);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            fuel_type = radioButton3.Text;
            button1.Enabled = _presenter.all_enter_auto_check(weight, value, fuel_type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _presenter._add_auto(weight, value, fuel_type);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = _presenter.only_number_check(e, nonNumberEntered);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {         
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = _presenter.only_number_check(e, nonNumberEntered);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {    
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 7;
            button1.Enabled = _presenter.all_enter_auto_check(weight, value, fuel_type);
            weight = _presenter.soft_convert(textBox1.Text);           
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            textBox2.MaxLength = 7;
            button1.Enabled = _presenter.all_enter_auto_check(weight, value, fuel_type);
            value = _presenter.soft_convert(textBox2.Text);          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
