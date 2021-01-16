using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class FormKoszykowka : Form
    {
        public FormKoszykowka()
        {
            InitializeComponent();
        }

        //Timer variables
        private int _minuty, _sekundy, _milisekundy, _akcjaSekundy, _akcjaMiliSekundy;

        private void FormKoszykowka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ObslugaKoszykowka obslugaKoszykowka = new ObslugaKoszykowka(this);
                obslugaKoszykowka.ShowDialog();
                QFaulsH.Text = Settings.Default.QFaulsH.ToString();
                QFaulsG.Text = Settings.Default.QFaulsG.ToString();
                AllFaulsH.Text = Settings.Default.AllFaulsH.ToString();
                AllFaulsG.Text = Settings.Default.AllFaulsG.ToString();
                timer2.Enabled = Settings.Default.Start;
            }
            if(e.KeyCode == Keys.F3)
            {
                timer2.Enabled = true;
            }
        }

        //Przypisanie połowy
        public void Quart(string quart)
        {
            polowaMeczu.Text = quart;
        }

        //Przypisanie gola dla gosci
        public void GuestScore(string goal)
        {
            wynikGosc.Text = goal;
        }
        public int czasgry = Settings.Default.CzasGry - 1;

        //Przypisanie gola dla gospodarzy
        public void HomeScore(string goal)
        {
            wynikGosp.Text = goal;
        }

        //Przypisanie fauli gospodarzom
        public void set_QFaulsH(string fauls)
        {
            QFaulsH.Text = fauls;
        }

        //Przypisanie fauli gosciom
        public void set_QFaulsG(string fauls)
        {
            QFaulsG.Text = fauls;
        }

        //Przypisanie fauli
        public void set_AllFaulsH(string fauls)
        {
            AllFaulsH.Text = fauls;
        }

        //Przypisanie fauli
        public void set_AllFaulsG(string fauls)
        {
            AllFaulsG.Text = fauls;
        }

        //Uruchomienie/zatrzymanie zagara
        public void StartStopClock(bool s)
        {
            timer2.Enabled = s;
            timer24.Enabled = s;
        }

        //Uruchomienie/zatrzymanie zagara 24 sekund
        public void StartStopClock24(bool s)
        {
            timer24.Enabled = s;
        }

        //Pobranie kwarty
        public string whichQuart()
        {
            return polowaMeczu.Text;
        }

        //Przypisanie czasu gry
        public void SetTime(string minutes, string seconds, string miliseconds)
        {
            minuty.Text = minutes;
            sekundy.Text = seconds;
            milisekundy.Text = miliseconds;
            _minuty = Convert.ToInt32(minutes);
            _sekundy = Convert.ToInt32(seconds);
            _milisekundy = Convert.ToInt32(miliseconds);
        }

        //Metoda do pokazywania czasu
        private void ShowTime()
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                minuty.Text = _minuty.ToString("00");
                sekundy.Text = _sekundy.ToString("00");
                milisekundy.Text = _milisekundy.ToString("0");
            }
            else
            {
                minuty.Text = _minuty.ToString("00");
                sekundy.Text = _sekundy.ToString("00");
                milisekundy.Text = _milisekundy.ToString("0");
            }
        }

        //Ustawienia zegara rosnącego
        private void IncreaseSeconds()
        {
            if (_sekundy == 59)
            {
                _sekundy = 0;
                IncreaseMinutes();
            }
            else
            {
                _sekundy++;
            }
            if (_minuty == Settings.Default.CalkowityCzas && _sekundy == 0)
            {
                Settings.Default.Start = false;
                timer2.Enabled = false;
            }
        }

        private void IncreaseMinutes()
        {
            _minuty++;
        }
        
        //Ustawienia zegara malejącego
        private void DecreaseMiliSeconds()
        {
            if(_milisekundy == 0)
            {
                _milisekundy = 9;
                DecreaseSeconds();
            }
            else
            {
                _milisekundy--;
            }
            if (_sekundy == 0 && _minuty == 0 && _milisekundy == 0)
            {
                Settings.Default.Start = false;
                
                timer2.Enabled = false;
            }
        }

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

        }

        private void DecreaseMinutes()
        {
            _minuty--;
        }

        //Tick zegara głównego
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                IncreaseSeconds();
                //IncreaseMiliSeconds();
            }
            else
            {
                DecreaseMiliSeconds();
            }
            ShowTime();
        }

        //Tick zegara 24 sekund
        private void timer24_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                IncreaseSeconds();
                //IncreaseMiliSeconds();
            }
            else
            {
                DecreaseMiliSeconds2();
            }
            ShowTime2();
        }

        //Wyświetlanie czasu 24sekund
        private void ShowTime2()
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                AkcjaSekundy.Text = _akcjaSekundy.ToString("00");
                AkcjaMiliSekundy.Text = _akcjaMiliSekundy.ToString("0");
            }
            else
            {
                AkcjaSekundy.Text = _akcjaSekundy.ToString("00");
                AkcjaMiliSekundy.Text = _akcjaMiliSekundy.ToString("0");
            }
        }

        //Czas malejąco
        private void DecreaseMiliSeconds2()
        {
            if (_akcjaMiliSekundy == 0)
            {
                _akcjaMiliSekundy = 9;
                DecreaseSeconds2();
            }
            else
            {
                _akcjaMiliSekundy--;
            }
            if(_akcjaMiliSekundy == 0 && _akcjaSekundy == 0)
            {
                timer24.Enabled = false;
                timer2.Enabled = false;
            }
        }

        private void DecreaseSeconds2()
        {
            if (_akcjaSekundy == 0)
            {
                _akcjaSekundy = 23;
            }
            else
            {
                _akcjaSekundy--;
            }
        }

        //Czas rosnąco
        private void IncreaseMiliSeconds2()
        {
            if (_akcjaMiliSekundy == 9)
            {
                _akcjaMiliSekundy = 0;
                IncreaseSeconds2();
            }
            else
            {
                _akcjaMiliSekundy++;
            }
            if (_akcjaMiliSekundy == 0 && _akcjaSekundy == 24)
            {
                timer24.Enabled = false;
            }
        }

        private void IncreaseSeconds2()
        {
            if (_akcjaSekundy == 24)
            {
                _akcjaSekundy = 0;
            }
            else
            {
                _akcjaSekundy++;
            }
        }
        //Getter minut dla zegara głównego
        public int getMins()
        {
            return _minuty;
        }

        //Getter sekund dla zegara głównego
        public int getSecs()
        {
            return _sekundy;
        }

        //Getter milisekund dla zegara głównego
        public int getMiliSecs()
        {
            return _milisekundy;
        }

        //Getter sekund dla zegara 24 sekundowego
        public int getActionSecs()
        {
            return _akcjaSekundy;
        }

        //Getter milisekund dla zegara 24 sekundowego
        public int getActionMiliSecs()
        {
            return _akcjaMiliSekundy;
        }

        //Setter sekund i milisekund akcji
        public void action(string sekundy, string milisekundy)
        {
            AkcjaSekundy.Text = sekundy;
            AkcjaMiliSekundy.Text = milisekundy;
            _akcjaSekundy = Convert.ToInt32(sekundy);
            _akcjaMiliSekundy = 0;
        }
        
        //Setter relacja
        public void SetRelation(string rel)
        {
            relacjaBox.Text = rel;
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

        //Załadowywanie kolorów tła i czcionki
        private void Color_Load()
        {
            if (Settings.Default.KolorCzcionka.Substring(0, 2) == "ff")
            {
                string colorcode = Settings.Default.KolorCzcionka;
                int argb = Int32.Parse(colorcode, NumberStyles.HexNumber);
                NazwaGosp.ForeColor = Color.FromArgb(argb);
                NazwaGosc.ForeColor = Color.FromArgb(argb);
                label1.ForeColor = Color.FromArgb(argb);
                label11.ForeColor = Color.FromArgb(argb);
                label8.ForeColor = Color.FromArgb(argb);
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
                AkcjaSekundy.ForeColor = Color.FromArgb(argb);
                AkcjaMiliSekundy.ForeColor = Color.FromArgb(argb);
                label15.ForeColor = Color.FromArgb(argb);
                milisekundy.ForeColor = Color.FromArgb(argb);
                AllFaulsG.ForeColor = Color.FromArgb(argb);
                AllFaulsH.ForeColor = Color.FromArgb(argb);
                QFaulsG.ForeColor = Color.FromArgb(argb);
                QFaulsH.ForeColor = Color.FromArgb(argb);
            }
            else
            {
                NazwaGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                NazwaGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label8.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label11.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
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
                AkcjaSekundy.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                AkcjaMiliSekundy.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label15.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                milisekundy.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                AllFaulsG.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                AllFaulsH.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                QFaulsG.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                QFaulsH.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);

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

        //Załadowywanie textu
        private void Text_Load()
        {
            NazwaGosp.Text = Settings.Default.NazwaGosp;
            NazwaGosc.Text = Settings.Default.NazwaGosc;
            OpisGosp.Text = Settings.Default.OpisGosp;
            OpisGosc.Text = Settings.Default.OpisGosc;

        }

        //Wyświetlanie czasu
        private void Time_Load()
        {
            if (Settings.Default.Typ == "Rosnąco")
            {
                _sekundy = 0;
                _minuty = 0;
            }
            else
            {
                _sekundy = 0;
                _minuty = Settings.Default.CzasGry;
            }
        }

        private void FormKoszykowka_Load(object sender, EventArgs e)
        {
            this.Width = Settings.Default.SzerokoscOkna;
            this.Height = Settings.Default.WysokoscOkna;
            this.KeyPreview = true;
            Settings.Default.CalkowityCzas = Settings.Default.CzasGry;
            
            Color_Load();
            Text_Load();
            Img_Load();
            Time_Load();
        }
    }
}
