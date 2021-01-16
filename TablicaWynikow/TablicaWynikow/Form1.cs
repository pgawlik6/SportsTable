using System;
using System.Windows.Forms;

namespace TablicaWynikow
{
    public partial class ZmienCzas : Form
    {
        Form2 ownerForm = null;

        public ZmienCzas(Form2 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ownerForm.SetTime(numericUpDown1.Value.ToString("00"), numericUpDown2.Value.ToString("00"));
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
