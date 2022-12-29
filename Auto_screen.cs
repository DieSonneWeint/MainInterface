using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainInterface
{
    public partial class Auto_screen : Form
    {
        public Presenter _presenter;

        private bool nonNumberEntered = false;
        public Auto_screen(Presenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_auto_screen form = new Add_auto_screen(_presenter);
            _presenter = form._presenter;
            form.FormClosed += formClosed;
            form.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                _presenter._remove_auto(listBox1.SelectedItem.ToString());
                listBox1.Items.Clear();
                List<string> list = new List<string>();
                list = _presenter.print_auto();
                foreach (string item in list)
                {
                    listBox1.Items.Add(item);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            listBox1.Items.Clear();
            List<string> list = new List<string>();
            list = _presenter.print_auto();
            foreach (string item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> list = new List<string>();
            list = _presenter.print_auto();
            foreach (string item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength= 7;
            int weight = _presenter.soft_convert(textBox1.Text);
            listBox1.Items.Clear();
            List<string> list = new List<string>();
            list = _presenter.search_auto(weight);
            foreach (string item in list)
            {
                listBox1.Items.Add(item);
            }
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
    }
}
