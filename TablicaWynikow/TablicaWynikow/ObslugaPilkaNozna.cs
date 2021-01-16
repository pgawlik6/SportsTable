using System;
using System.Windows.Forms;
using TablicaWynikow.Properties;
using System.IO;


namespace TablicaWynikow
{
    public partial class ObslugaPilkaNozna : Form
    {
        Form2 ownerForm = null;

        string newLine = Environment.NewLine;

        public ObslugaPilkaNozna(Form2 ownerForm)
        {
            InitializeComponent();
            this.ownerForm = ownerForm;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.ownerForm.whichHalf() == "2" && this.ownerForm.getMins() == Settings.Default.CalkowityCzas)
            {
                this.ownerForm.SetTime(Settings.Default.CzasGry.ToString("00"), "00");
                Settings.Default.CalkowityCzas = 2 * Settings.Default.CzasGry;
                this.ownerForm.AddedTime("0");
            }

            Settings.Default.Start = true;
            bool war = Settings.Default.Start;
            this.ownerForm.StartStopClock(war);
            this.button1.Enabled = false;
            //relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "Sędzia gwizdnął, a więc rozpoczynamy mecz pomiędzy " + Settings.Default.NazwaGosp + ", a " + Settings.Default.NazwaGosc + newLine;

        }

        private void ObslugaPilkaNozna_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.YCH.ToString();
            textBox2.Text = Settings.Default.YCG.ToString();
            textBox3.Text = Settings.Default.RCH.ToString();
            textBox4.Text = Settings.Default.RCG.ToString();
            textBox5.Text = Settings.Default.GoleGosp.ToString();
            textBox6.Text = Settings.Default.GoleGosc.ToString();
            GoscBox.Text = Settings.Default.NazwaGosc;
            GospBox.Text = Settings.Default.NazwaGosp;
            relacjaBox.Text = Settings.Default.relacja;

        }

        //BUTTONS FOR CARDS
        private void RedCardGuest_Click(object sender, EventArgs e)
        {
            int redCards = Convert.ToInt32(textBox4.Text);
            redCards++;
            textBox4.Text = redCards.ToString();
            Settings.Default.RCG = Convert.ToInt32(textBox4.Text);
            this.ownerForm.GuestRedCards(textBox4.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "Czerwoną kartkę otrzymał gracz drużyny " + Settings.Default.NazwaGosc + newLine;
        }

        private void RedCardHost_Click(object sender, EventArgs e)
        {
            int redCards = Convert.ToInt32(textBox3.Text);
            redCards++;
            textBox3.Text = redCards.ToString();
            Settings.Default.RCH = Convert.ToInt32(textBox3.Text);
            this.ownerForm.HomeRedCards(textBox3.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "Czerwoną kartkę otrzymał gracz drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        private void YellowCardGuest_Click(object sender, EventArgs e)
        {
            int yellowCards = Convert.ToInt32(textBox2.Text);
            yellowCards++;
            textBox2.Text = yellowCards.ToString();
            Settings.Default.YCG = Convert.ToInt32(textBox2.Text);
            this.ownerForm.GuestYellowCards(textBox2.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "Żółtą kartkę otrzymał gracz drużyny " + Settings.Default.NazwaGosc + newLine;
        }

        private void YellowCardHost_Click(object sender, EventArgs e)
        {
            int yellowCards = Convert.ToInt32(textBox1.Text);
            yellowCards++;
            textBox1.Text = yellowCards.ToString();
            Settings.Default.YCH = Convert.ToInt32(textBox1.Text);
            this.ownerForm.HomeYellowCards(textBox1.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "Żółtą kartkę otrzymał gracz drużyny " + Settings.Default.NazwaGosp + newLine;
        }

        //TEXT CHANGE FOR CARDS
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            if (textBox1.Text.Length > 0) {
                this.ownerForm.HomeYellowCards(textBox1.Text);
                Settings.Default.YCH = Convert.ToInt32(textBox1.Text);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
            }
            if (textBox2.Text.Length > 0)
            {
                this.ownerForm.GuestYellowCards(textBox2.Text);
                Settings.Default.YCG = Convert.ToInt32(textBox2.Text);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
            }
            if (textBox3.Text.Length > 0)
            {
                this.ownerForm.HomeRedCards(textBox3.Text);
                Settings.Default.RCH = Convert.ToInt32(textBox3.Text);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox4.Text = textBox4.Text.Remove(textBox4.Text.Length - 1);
            }
            if (textBox4.Text.Length > 0)
            {
                this.ownerForm.GuestRedCards(textBox4.Text);
                Settings.Default.RCG = Convert.ToInt32(textBox4.Text);
            }
        }

        //Doliczanie czasu
        private void button2_Click(object sender, EventArgs e)
        {
            DoliczonyCzas doliczCzas = new DoliczonyCzas(ownerForm);
            doliczCzas.ShowDialog();
        }

        //Gole gospodarzy
        private void button3_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox5.Text);
            goals++;
            textBox5.Text = goals.ToString();
            Settings.Default.GoleGosp = Convert.ToInt32(textBox5.Text);
            this.ownerForm.HomeScore(textBox5.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "GOOOOOOL!!! Gola zdobyła drużyna " + Settings.Default.NazwaGosp + newLine;
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

        //Gole gosci
        private void button4_Click(object sender, EventArgs e)
        {
            int goals = Convert.ToInt32(textBox6.Text);
            goals++;
            textBox6.Text = goals.ToString();
            Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            this.ownerForm.GuestScore(textBox6.Text);
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + "GOOOOOOL!!! Gola zdobyła drużyna " + Settings.Default.NazwaGosc + newLine;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "[^0-9]"))
            {
                MessageBox.Show("Proszę wpisywać tylko liczby.");
                textBox6.Text = textBox5.Text.Remove(textBox6.Text.Length - 1);
            }
            if (textBox6.Text.Length > 0)
            {
                this.ownerForm.GuestScore(textBox6.Text);
                Settings.Default.GoleGosc = Convert.ToInt32(textBox6.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ZmienCzas zmienCzas = new ZmienCzas(ownerForm);
            zmienCzas.ShowDialog();
        }

        private void relacjaBox_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.relacja = relacjaBox.Text;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.ownerForm.SetRelation(relacjaBox.Text);
            try
            {
                using (StreamWriter streamW = new StreamWriter((Settings.Default.SciezkaZRelacja + "\\Relacja_Piłka_Nożna.txt"), false))
                {
                    streamW.WriteLine("Relacja z meczu pomiędzy " + Settings.Default.NazwaGosp + ", a " + Settings.Default.NazwaGosc +".\n");
                    streamW.WriteLine(relacjaBox.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dane nie zapisały się w pliku :(");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            relacjaBox.Text += this.ownerForm.getMins().ToString() + " min. - " + newLine;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UstawPolowe ustawPolowe = new UstawPolowe(ownerForm);
            ustawPolowe.ShowDialog();
            if (this.ownerForm.whichHalf() == "2")
            {
                this.button1.Enabled = true;
            }
        }
    }
}
