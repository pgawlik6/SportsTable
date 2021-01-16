using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TablicaWynikow.Properties;

namespace TablicaWynikow
{
    public partial class FormSiatkowka : Form
    {
        public FormSiatkowka()
        {
            InitializeComponent();
        }


        //Przypisanie punktu dla gosci
        public void GuestScore(string point)
        {
            wynikGosc.Text = point;
        }

        //Przypisanie punktu dla gospodarzy
        public void HomeScore(string point)
        {
            wynikGosp.Text = point;
        }

        //Przypisanie seta
        public void Set(string set)
        {
            polowaMeczu.Text = set;
        }

        //Pobranie seta
        public string whichSet()
        {
            return polowaMeczu.Text;
        }
        //Przebieg wyświetl
        public void przebieg()
        {
            label1.Visible = true;
        }

        //Relacja
        public void SetRelation(string rel)
        {
            relacjaBox.Text = rel;
        }

        //Przebieg meczu
        //set 1
        public void setScore_1(string score1, string score2)
        {
            Set_1.Text = score1 + ":" + score2;
        }

        //set 2
        public void setScore_2(string score1, string score2)
        {
            Set_2.Text = score1 + ":" + score2;
        }

        //set 3
        public void setScore_3(string score1, string score2)
        {
            Set_3.Text = score1 + ":" + score2;
        }

        //set 4
        public void setScore_4(string score1, string score2)
        {
            Set_4.Text = score1 + ":" + score2;
        }

        //set 5
        public void setScore_5(string score1, string score2)
        {
            Set_5.Text = score1 + ":" + score2;
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
        private Bitmap ResizeImage(Image image, int width, int height)
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

        //Wczytanie kolorów tła i czcionki
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
                label10.ForeColor = Color.FromArgb(argb);
                wynikGosc.ForeColor = Color.FromArgb(argb);
                wynikGosp.ForeColor = Color.FromArgb(argb);
                label7.ForeColor = Color.FromArgb(argb);
                polowaMeczu.ForeColor = Color.FromArgb(argb);
                OpisGosc.ForeColor = Color.FromArgb(argb);
                OpisGosp.ForeColor = Color.FromArgb(argb);
                label1.ForeColor = Color.FromArgb(argb);
                Set_1.ForeColor = Color.FromArgb(argb);
                Set_2.ForeColor = Color.FromArgb(argb);
                Set_3.ForeColor = Color.FromArgb(argb);
                Set_4.ForeColor = Color.FromArgb(argb);
                Set_5.ForeColor = Color.FromArgb(argb);

            }
            else
            {
                NazwaGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                NazwaGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label2.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label10.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                wynikGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                wynikGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                label7.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                polowaMeczu.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                OpisGosc.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                OpisGosp.ForeColor = Color.FromName(Settings.Default.KolorCzcionka); 
                label1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                Set_1.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                Set_2.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                Set_3.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                Set_4.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
                Set_5.ForeColor = Color.FromName(Settings.Default.KolorCzcionka);
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


        private void FormSiatkowka_Load(object sender, EventArgs e)
        {
            this.Width = Settings.Default.SzerokoscOkna;
            this.Height = Settings.Default.WysokoscOkna;
            this.KeyPreview = true;

            Text_Load();
            Img_Load();
            Color_Load();
        }

        private void FormSiatkowka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ObslugaSiatkowka obslugaSiatkowka = new ObslugaSiatkowka(this);
                obslugaSiatkowka.ShowDialog();
            }
        }
    }

}
