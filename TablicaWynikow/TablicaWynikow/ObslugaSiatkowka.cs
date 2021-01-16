using System;
using System.IO;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class ObslugaSiatkowka : Form
    {
        FormSiatkowka ownerForm = null;

        string newLine = Environment.NewLine;

        public ObslugaSiatkowka(FormSiatkowka ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        //Rozpocznij seta
        private void button1_Click(object sender, EventArgs e)
        {
            if(this.ownerForm.whichSet() == "1")
            {
                relacjaBox.Text += "Sędzia rozpoczął spotkanie pomiędzy " + Settings.Default.NazwaGosp + ", a " + Settings.Default.NazwaGosc + newLine + "Set " + this.ownerForm.whichSet().ToString() + newLine;
            }
            else
            {
                relacjaBox.Text += "Set " + this.ownerForm.whichSet().ToString() + newLine;
            }
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            this.button8.Enabled = false;
        }

        //Zakończ seta
        private void button2_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
            this.button2.Enabled = false;
            this.button8.Enabled = true;
            relacjaBox.Text += "Koniec seta "+ this.ownerForm.whichSet() +newLine;
            if (this.ownerForm.whichSet() == "1")
            {
                this.ownerForm.przebieg();
                this.ownerForm.setScore_1(textBox5.Text, textBox6.Text);
            }
            if (this.ownerForm.whichSet() == "2")
            {
                this.ownerForm.setScore_2(textBox5.Text, textBox6.Text);
            }
            if (this.ownerForm.whichSet() == "3")
            {
                this.ownerForm.setScore_3(textBox5.Text, textBox6.Text);
            }
            if (this.ownerForm.whichSet() == "4")
            {
                this.ownerForm.setScore_4(textBox5.Text, textBox6.Text);
            }
            if (this.ownerForm.whichSet() == "5")
            {
                this.ownerForm.setScore_5(textBox5.Text, textBox6.Text);
            }
        }

        //Ustaw Seta
        private void button8_Click(object sender, EventArgs e)
        {
            UstawSeta ustawSeta = new UstawSeta(ownerForm);
            ustawSeta.ShowDialog();
            textBox5.Text = "0";
            textBox6.Text = "0";
        }

        //Do relacji
        private void button7_Click(object sender, EventArgs e)
        {
            relacjaBox.Text += textBox5.Text + ":" + textBox6.Text + " - ";
        }

        //Punkty gospodarzy
        private void PointsHome_Click(object sender, EventArgs e)
        {
            int point = Convert.ToInt32(textBox5.Text);
            point++;
            textBox5.Text = point.ToString();
            Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            this.ownerForm.HomeScore(textBox5.Text);
            relacjaBox.Text += textBox5.Text +":"+ textBox6.Text + " - Punkt zdobyła drużyna " + Settings.Default.NazwaGosp + newLine;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox5.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox5.Text = textBox5.Text.Remove(textBox5.Text.Length - 1);
            }
            if (textBox5.Text.Length > 0)
            {
                this.ownerForm.HomeScore(textBox5.Text);
                Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            }
        }

        //Punkty gości
        private void PointsGuest_Click(object sender, EventArgs e)
        {
            int point = Convert.ToInt32(textBox6.Text);
            point++;
            textBox6.Text = point.ToString();
            Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            this.ownerForm.GuestScore(textBox6.Text);
            relacjaBox.Text += textBox5.Text + ":" + textBox6.Text + " - Punkt zdobyła drużyna " + Settings.Default.NazwaGosc + newLine;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox6.Text = textBox6.Text.Remove(textBox6.Text.Length - 1);
            }
            if (textBox6.Text.Length > 0)
            {
                this.ownerForm.GuestScore(textBox6.Text);
                Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ownerForm.SetRelation(relacjaBox.Text);
            try
            {
                using (StreamWriter streamW = new StreamWriter((Settings.Default.SciezkaZRelacja + "\\Relacja_Siatkówka.txt"), false))
                {
                    streamW.WriteLine("Relacja z meczu pomiędzy " + Settings.Default.NazwaGosp + ", a " + Settings.Default.NazwaGosc + ".\n");
                    streamW.WriteLine(relacjaBox.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dane nie zapisały się w pliku :(");
            }
        }

        private void ObslugaSiatkowka_Load(object sender, EventArgs e)
        {
            textBox5.Text = Settings.Default.GoleGosp.ToString();
            textBox6.Text = Settings.Default.GoleGosc.ToString();
            GoscBox.Text = Settings.Default.NazwaGosc;
            GospBox.Text = Settings.Default.NazwaGosp;
            relacjaBox.Text = Settings.Default.relacja;
        }

    }
}
