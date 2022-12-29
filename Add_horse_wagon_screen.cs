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
    public partial class Add_horse_wagon_screen : Form
    {
        public Presenter _presenter;
        int weight = 0;
        float one_force = 0;
        List<float> force = new List<float>();   
        bool NonNum = false;
        public Add_horse_wagon_screen(Presenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            _presenter._add_horse_wagon(weight, force);
            listBox1.Items.Clear();
            force.Clear();         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 7;
            button2.Enabled = _presenter.all_enter_hourse_wagon_check(weight, force);           
            weight = _presenter.soft_convert(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 1;
            listBox1.Items.Clear();               
            force.Add(one_force);
            foreach (int item in force)
            {
                listBox1.Items.Add($"Номер {i++}  {item} р/вын   100 вын");
            }
               button2.Enabled = _presenter.all_enter_hourse_wagon_check(weight, force);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 3;
            button2.Enabled = _presenter.all_enter_hourse_wagon_check(weight, force);            
            one_force = _presenter.soft_convert(textBox2.Text);
            button1.Enabled = _presenter.force_check(one_force);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            NonNum = _presenter.only_number_check(e, NonNum);   
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (NonNum == true )
            {            
                    e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            NonNum = _presenter.only_number_check(e, NonNum);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (NonNum == true)
            {
                e.Handled = true;
            }
        }

        private void Add_horse_wagon_screen_Load(object sender, EventArgs e)
        {

        }
    }
}
