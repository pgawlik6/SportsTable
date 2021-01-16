using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Timer variables
        private int _minuty, _sekundy;

        //Getter minut
        public int getMins()
        {
            return _minuty;
        }

        //Getter sekund
        public int getSecs()
        {
            return _sekundy;
        }

        //Metody
        private void Img_Load()
        {
            Bitmap GospBitmap, GoscBitmap;
            Image img = Image.FromFile(Settings.Default.GospZdj);
            GospBitmap = ResizeImage(img, GospZdj.Width, GospZdj.Height);
            GospZdj.Image = GospBitmap;

            Image img2 = Image.FromFile(Settings.Default.GoscZdj);
            GoscBitmap = ResizeImage(img2, GoscZdj.Width, GoscZdj.Height);
            GoscZdj.Image = GoscBitmap;
        }
        
        //Załadowanie kolorów czcionki i tła
        private void Color_Load()
        {
            if (Settings.Default.KolorCzcionka.Substring(0, 2) == "ff")
            {
                string colorcode = Settings.Default.KolorCzcionka;
                int argb = Int32.Parse(colorcode, NumberStyles.HexNumber);
                NazwaGosp.ForeColor = Color.FromArgb(argb);
                NazwaGosc.ForeColor = Color.FromArgb(argb);
                label1.ForeColor = Color.FromArgb(argb);
                label2.ForeColor = Color.FromArgb(argb);
                sekundy.ForeColor = Color.FromArgb(argb);
                minuty.ForeColor = Color.FromArgb(argb);
                label9.ForeColor = Color.FromArgb(argb);
                label10.ForeColor = Color.FromArgb(argb);
                wynikGosc.ForeColor = Color.FromArgb(argb);
                wynikGosp.ForeColor = Color.FromArgb(argb);
                label7.ForeColor = Color.FromArgb(argb);
                polowaMeczu.ForeColor = Color.FromArgb(argb);
                doliczonyCzas.ForeColor = Color.FromArgb(argb);
                OpisGosc.ForeColor = Color.FromArgb(argb);
                OpisGosp.ForeColor = Color.FromArgb(argb);
                label3.ForeColor = Color.FromArgb(argb);
                label4.ForeColor = Color.FromArgb(argb);
                label5.ForeColor = Color.FromArgb(argb);
                label6.ForeColor = Color.FromArgb(argb);
                YCG.ForeColor = Color.FromArgb(argb);
                YCH.ForeColor = Color.FromArgb(argb);
                RCG.ForeColor = Color.FromArgb(argb);
                RCH.ForeColor = Color.FromArgb(argb);
                label1.ForeColor = Color.FromArgb(argb);
                groupBox2.ForeColor = Color.FromArgb(argb);
                groupBox1.ForeColor = Color.FromArgb(argb);
                label8.ForeColor = Color.FromArgb(argb);
            }
            else
            {
                NazwaGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                NazwaGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label2.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                sekundy.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                minuty.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label9.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label10.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                wynikGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                wynikGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label7.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                polowaMeczu.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                doliczonyCzas.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                OpisGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                OpisGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label3.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label4.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label5.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label6.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                YCG.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                YCH.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                RCG.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                RCH.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                groupBox2.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                groupBox1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label8.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
            }

            if (Settings.Default.KolorTło.Substring(0, 2) == "ff")
            {
                string colorcode = Settings.Default.KolorTło;
                int argb = Int32.Parse(colorcode, NumberStyles.HexNumber);
                this.BackColor = Color.FromArgb(argb);
            }
            else
            {
                this.BackColor = Color.FromName(Settings.Default.KolorTło);
            }
        }

        //Załadowanie napisów
        private void Text_Load()
        {
            NazwaGosp.Text = Settings.Default.NazwaGosp;
            NazwaGosc.Text = Settings.Default.NazwaGosc;
            OpisGosp.Text = Settings.Default.OpisGosp;
            OpisGosc.Text = Settings.Default.OpisGosc;

        }

        //Załadowanie czasu
        private void TimeLoad()
        {
            if(Settings.Default.Typ == "Rosnąco") { 
                _sekundy = 0;
                _minuty = 0;
            }
            else
            {
                _sekundy = 0;
                _minuty = Settings.Default.CzasGry;
            }
        }

        //Załadowanie kartek
        public void CardsLoad()
        {
            YCH.Text = Settings.Default.YCH.ToString();
            YCG.Text = Settings.Default.YCG.ToString();
            RCH.Text = Settings.Default.RCH.ToString();
            RCG.Text = Settings.Default.RCG.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Width = Settings.Default.SzerokoscOkna;
            this.Height = Settings.Default.WysokoscOkna;
            this.KeyPreview = true;
            Settings.Default.CalkowityCzas = Settings.Default.CzasGry;

            Img_Load();
            Color_Load();
            Text_Load();
            TimeLoad();
            CardsLoad();

        }
        
        //Skalowanie obrazów
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        //Przypisanie gola dla gosci
        public void GuestScore(string goal)
        {
            wynikGosc.Text = goal;
        }
        
        //Przypisanie gola dla gospodarzy
        public void HomeScore(string goal)
        {
            wynikGosp.Text = goal;
        }  
        
        //Przypisanie czerwonych kartek dla gospodarzy
        public void HomeRedCards(string cards)
        {
            RCH.Text = cards;
        }

        //Przypisanie żółtych kartek dla gospodarzy
        public void HomeYellowCards(string cards)
        {
            YCH.Text = cards;
        }

        //Przypisanie czerwonych kartek dla gosci
        public void GuestRedCards(string cards)
        {
            RCG.Text = cards;
        }

        //Przypisanie żółtych kartek dla gosci
        public void GuestYellowCards(string cards)
        {
            YCG.Text = cards;
        }

        //Przypisanie połowy
        public void Half(string half)
        {
            polowaMeczu.Text = half;
        }

        //Przypisanie doliczonego czasu gry
        public void AddedTime(string time)
        {
            if (time != "0")
            {
                doliczonyCzas.Text = "+" + time;
            }
            else
            {
                doliczonyCzas.Text = "";
            }  
        }

        //Pobranie polowy
        public string whichHalf()
        {
            return polowaMeczu.Text;
        }


        //Przypisanie czasu gry
        public int czasgry = Settings.Default.CzasGry - 1;

        public void SetTime(string minutes, string seconds)
        {
            minuty.Text = minutes;
            sekundy.Text = seconds;
            _minuty = Convert.ToInt32(minutes);
            _sekundy = Convert.ToInt32(seconds);
        }
        //Uruchomienie/zatrzymanie zagara
        public void StartStopClock(bool s)
        {
            timer1.Enabled = s;
        }

        public void SetRelation(string rel)
        {
            relacjaBox.Text = rel;
        }

        //Ustawienia zegara rosnącego
        private void IncreaseSeconds()
        {
            if(_sekundy == 59)
            {
                _sekundy = 0;
                IncreaseMinutes();
            }
            else
            {
                _sekundy++;
            }
            if(_minuty == Settings.Default.CalkowityCzas && _sekundy == 0)
            {
                Settings.Default.Start = false;
                timer1.Enabled = false;
            }
        }

        private void IncreaseMinutes()
        {
                _minuty++;
        }

        //Ustawienia zegara malejącego
        private void DecreaseSeconds()
        {
            if (_sekundy == 0)
            {
                _sekundy = 59;
                DecreaseMinutes();
            }
            else
            {
                _sekundy--;
            }
            if(_sekundy == 0 && _minuty == 0)
            {
                Settings.Default.Start = false;
                timer1.Enabled = false;
            }
        }

        private void DecreaseMinutes()
        {
            _minuty--;
        }

        private void ShowTime()
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                minuty.Text = _minuty.ToString("00");
                sekundy.Text = _sekundy.ToString("00");
            }
            else
            {
                minuty.Text = _minuty.ToString("00");
                sekundy.Text = _sekundy.ToString("00");
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ObslugaPilkaNozna obslugaPilkaNozna = new ObslugaPilkaNozna(this);
                obslugaPilkaNozna.ShowDialog();
                YCH.Text = Settings.Default.YCH.ToString();
                YCG.Text = Settings.Default.YCG.ToString();
                RCH.Text = Settings.Default.RCH.ToString();
                RCG.Text = Settings.Default.RCG.ToString();
                timer1.Enabled = Settings.Default.Start;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                IncreaseSeconds();
            }
            else
            {
                DecreaseSeconds();
            }
            ShowTime();
        }

    }
}
