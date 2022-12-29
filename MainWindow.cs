using System.Drawing.Printing;

namespace MainInterface
{   
    public partial class MainWindow : Form
    {
        public Presenter _presenter;

        public MainWindow(Presenter presenter)
        {
            _presenter = presenter;
            InitializeComponent();
        }
        public event EventHandler myEvent;     

        private void button1_Click(object sender, EventArgs e)
        {
            Auto_screen auto_Screen = new Auto_screen(_presenter);
            auto_Screen.FormClosed += formClosed;
            _presenter = auto_Screen._presenter;
            auto_Screen.Show();
            this.Hide();     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Horses_Wagon_screen horses_Wagon_Screen = new Horses_Wagon_screen(_presenter);
            horses_Wagon_Screen.FormClosed += formClosed;
            _presenter = horses_Wagon_Screen._presenter;
            horses_Wagon_Screen.Show();
            this.Hide();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            this._presenter = _presenter;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<string> list = new List<string>();
            list = _presenter._result();
            foreach (string item in list)
            {
                listBox1.Items.Add(item);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}