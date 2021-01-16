using System;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class DoliczonyCzas : Form
    {
        Form2 ownerForm = null;

        public DoliczonyCzas(Form2 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Settings.Default.DoliczonyCzas = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            Settings.Default.CalkowityCzas += Settings.Default.DoliczonyCzas;
            Console.WriteLine(Settings.Default.CalkowityCzas);
            this.ownerForm.AddedTime(numericUpDown1.Value.ToString());
            this.Hide();
            this.Close();
            
        }

    }
}
