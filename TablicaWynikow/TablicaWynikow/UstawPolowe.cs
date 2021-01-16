using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TablicaWynikow
{
    public partial class UstawPolowe : Form
    {
        Form2 ownerForm = null;

        public UstawPolowe(Form2 ownerForm)
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
            this.ownerForm.Half(numericUpDown1.Value.ToString());
            this.Hide();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
