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
    public partial class ZmienCzasKoszykowka : Form
    {
        FormKoszykowka ownerForm = null;

        public ZmienCzasKoszykowka(FormKoszykowka ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ownerForm.SetTime(numericUpDown1.Value.ToString("00"), numericUpDown2.Value.ToString("00"), numericUpDown3.Value.ToString("00"));
            this.ownerForm.action(numericUpDown5.Value.ToString("00"), numericUpDown4.Value.ToString("00"));
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
