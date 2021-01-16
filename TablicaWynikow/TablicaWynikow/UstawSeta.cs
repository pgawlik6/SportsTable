using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class UstawSeta : Form
    {
        FormSiatkowka ownerForm = null;
        public UstawSeta(FormSiatkowka ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ownerForm.Set(numericUpDown1.Value.ToString());
            Settings.Default.GoleGosp = 0;
            Settings.Default.GoleGosc = 0;
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
