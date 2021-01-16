using System;
using System.IO;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class ObslugaKoszykowka : Form
    {

        string newLine = Environment.NewLine;
        FormKoszykowka ownerForm = null;
        public ObslugaKoszykowka(FormKoszykowka ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }
        
        //Setter fauli gospodarzy
        public void QFaulsHSet(string s)
        {
            textBox3.Text = s;
        }

        //Setter fauli gosci
        public void QFaulsGSet(string s)
        {
            textBox4.Text = s;
        }

        //Suma fauli
        private int sumFaulsH = 0, sumFaulsG = 0;

        //Faule gospodarzy
        private void QFaulsHost_Click(object sender, EventArgs e)
        {
            int fauls = Convert.ToInt32(textBox3.Text);
            fauls++;
            sumFaulsH = Settings.Default.AllFaulsH;
            sumFaulsH += 1;
            Settings.Default.AllFaulsH = sumFaulsH;
            textBox3.Text = fauls.ToString();
            textBox1.Text = sumFaulsH.ToString();
            Settings.Default.QFaulsH = Convert.ToInt32(textBox3.Text);
            Settings.Default.AllFaulsH = Convert.ToInt32(textBox1.Text);
            this.ownerForm.set_QFaulsH(textBox3.Text);
            this.ownerForm.set_AllFaulsH(textBox1.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "Faul gracza drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        //Faule gosci
        private void QFaulsGuest_Click(object sender, EventArgs e)
        {
            int fauls = Convert.ToInt32(textBox4.Text);
            fauls++;
            sumFaulsG = Settings.Default.AllFaulsG;
            sumFaulsG += 1;
            Settings.Default.AllFaulsG = sumFaulsG;
            textBox4.Text = fauls.ToString();
            textBox2.Text = sumFaulsG.ToString();
            Settings.Default.QFaulsG = Convert.ToInt32(textBox4.Text);
            Settings.Default.AllFaulsG = Convert.ToInt32(textBox2.Text);
            this.ownerForm.set_QFaulsG(textBox4.Text);
            this.ownerForm.set_AllFaulsG(textBox2.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "Faul gracza drużyny " + Settings.Default.NazwaGosc + newLine;
        }
        private int IsMatchStarted = 0;
        //Przycisk do startowanie zegaru
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.Start = true;
            bool war = Settings.Default.Start;
            this.ownerForm.StartStopClock(true);
            if(IsMatchStarted == 0)
            {
                relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "Rozpoczynamy mecz pomiędzy " + Settings.Default.NazwaGosp + ", a " + Settings.Default.NazwaGosc + newLine;
                IsMatchStarted = 1;
            }
            
        }

        //Punkty dla gospodarzy
        //1
        private void PointHost_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox5.Text);
            goals++;
            textBox5.Text = goals.ToString();
            Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            this.ownerForm.HomeScore(textBox5.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "1 punkt dla drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        //2
        private void Points_2_Host_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox5.Text);
            goals +=2;
            textBox5.Text = goals.ToString();
            Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            this.ownerForm.HomeScore(textBox5.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "2 punkty dla drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        //3
        private void Points_3_Host_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox5.Text);
            goals += 3;
            textBox5.Text = goals.ToString();
            Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            this.ownerForm.HomeScore(textBox5.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "3 punkty dla drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        //Punkty dla gosci
        //1
        private void PointGuest_Click_1(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox6.Text);
            goals++;
            textBox6.Text = goals.ToString();
            Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            this.ownerForm.GuestScore(textBox6.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "1 punkt dla drużyny " + Settings.Default.NazwaGosc + newLine;
        }


        //2
        private void Points_2_Guest_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox6.Text);
            goals += 2;
            textBox6.Text = goals.ToString();
            Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            this.ownerForm.GuestScore(textBox6.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "2 punkty dla drużyny " + Settings.Default.NazwaGosc + newLine;
        }

        //3
        private void Points_3_Guest_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox6.Text);
            goals += 3;
            textBox6.Text = goals.ToString();
            Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            this.ownerForm.GuestScore(textBox6.Text);
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + "3 punkty dla drużyny " + Settings.Default.NazwaGosc + newLine;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ownerForm.SetRelation(relacjaBox.Text);
            try
            {
                using (StreamWriter streamW = new StreamWriter((Settings.Default.SciezkaZRelacja + "\\Relacja_Koszykówka.txt"), false))
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

        //Do relacji
        private void button7_Click(object sender, EventArgs e)
        {
            relacjaBox.Text += "Q" + this.ownerForm.whichQuart() + ". " + this.ownerForm.getMins().ToString() + " min. - " + newLine;
        }

        //24sekundy
        private void button9_Click(object sender, EventArgs e)
        {
            if(this.ownerForm.getSecs() < 24)
            {
                this.ownerForm.action("00", "00");
                this.ownerForm.StartStopClock24(false);
            }
            else
            {
                this.ownerForm.action("24", "00");
            }
            
        }
        
        //14sekund
        private void button10_Click(object sender, EventArgs e)
        {
            this.ownerForm.action("14", "00");
        }

        //Zmiana kwarty
        private void button8_Click(object sender, EventArgs e)
        {
            ZmianaKwarty ustawPolowe = new ZmianaKwarty(ownerForm);
            ustawPolowe.ShowDialog();
            if (this.ownerForm.whichQuart() == "2")
            {
                this.button1.Enabled = true;
            }
            else if (this.ownerForm.whichQuart() == "3")
            {
                this.button1.Enabled = true;
            }
            else if (this.ownerForm.whichQuart() == "4")
            {
                this.button1.Enabled = true;
            }
            textBox3.Text = "0";
            Settings.Default.QFaulsH = 0;
            textBox4.Text = "0";
            Settings.Default.QFaulsG = 0;
            this.ownerForm.set_QFaulsG("0");
            this.ownerForm.set_QFaulsH("0");
        }

        //Zatrzymanie zegaru
        private void button2_Click(object sender, EventArgs e)
        {
            this.ownerForm.StartStopClock(false);
            Settings.Default.Start = false;
        }

        //Ustawienie czasu
        private void button5_Click(object sender, EventArgs e)
        {
            ZmienCzasKoszykowka zmienczas = new ZmienCzasKoszykowka(ownerForm);
            zmienczas.ShowDialog();
        }

        //Faule ogółem gospodarze
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            if (textBox1.Text.Length > 0)
            {
                this.ownerForm.set_AllFaulsH(textBox1.Text);
                Settings.Default.AllFaulsH = Convert.ToInt32(textBox1.Text);
            }
        }

        //Faule w kwarcie gospodarzy
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
            if (textBox3.Text.Length > 0)
            {
                this.ownerForm.set_QFaulsH(textBox3.Text);
                Settings.Default.QFaulsH = Convert.ToInt32(textBox3.Text);
            }
        }

        //Punkty gospodarzy
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

        //Faule ogółem goście
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
            if (textBox2.Text.Length > 0)
            {
                this.ownerForm.set_AllFaulsG(textBox2.Text);
                Settings.Default.AllFaulsG = Convert.ToInt32(textBox2.Text);
            }
        }

        //Faule w kwarcie gości
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
            if (textBox4.Text.Length > 0)
            {
                this.ownerForm.set_QFaulsG(textBox4.Text);
                Settings.Default.QFaulsG = Convert.ToInt32(textBox4.Text);
            }
        }

        //Punkty gości
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox6.Text = textBox1.Text.Remove(textBox6.Text.Length - 1);
            }
            if (textBox6.Text.Length > 0)
            {
                this.ownerForm.GuestScore(textBox6.Text);
                Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            }
        }


        private void ObslugaKoszykowka_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.AllFaulsH.ToString();
            textBox2.Text = Settings.Default.AllFaulsG.ToString();
            textBox3.Text = Settings.Default.QFaulsH.ToString();
            textBox4.Text = Settings.Default.QFaulsG.ToString();
            textBox5.Text = Settings.Default.GoleGosp.ToString();
            textBox6.Text = Settings.Default.GoleGosc.ToString();

        }
    }
}
