using System;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class FormSport : Form
    {
        public FormSport()
        {
            InitializeComponent();
        }
        private void ZapiszKonfig()
        {
            Settings.Default.WysokoscOkna = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            Settings.Default.SzerokoscOkna = Convert.ToInt32(Math.Round(numericUpDown2.Value, 0));
            Settings.Default.CzasGry = Convert.ToInt32(Math.Round(numericUpDown3.Value, 0));
            Settings.Default.Typ = TypBox.Text;
            Settings.Default.Sport = SportBox.Text;
            Settings.Default.DoliczonyCzas = 0;

            Settings.Default.Save();
            Settings.Default.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                ZapiszKonfig();
                this.Hide();
                FormKonfig2 formSport = new FormKonfig2();
                formSport.ShowDialog();
                this.Close();
        }

        private void FormSport_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = Settings.Default.WysokoscOkna;
            numericUpDown2.Value = Settings.Default.SzerokoscOkna;
            numericUpDown3.Value = Settings.Default.CzasGry;
            TypBox.Text = Settings.Default.Typ;
            SportBox.Text = Settings.Default.Sport;

        }

        private void SportBox_TextChanged(object sender, EventArgs e)
        {
            if (SportBox.Text == "Siatkówka")
            {
                numericUpDown3.Visible = false;
                TypBox.Visible = false;
                label6.Visible = true;
                label7.Visible = true;
            }
            else
            {
                numericUpDown3.Visible = true;
                TypBox.Visible = true;
                label6.Visible = false;
                label7.Visible = false;
            }
        }
    }
}
