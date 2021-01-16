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
    public partial class ZmianaKwarty : Form
    {
        FormKoszykowka ownerForm = null;

        public ZmianaKwarty(FormKoszykowka ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        //Ustaw
        private void button2_Click(object sender, EventArgs e)
        {
            this.ownerForm.Quart(numericUpDown1.Value.ToString());
            this.Hide();
            this.Close();
        }


        //Anuluj
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
