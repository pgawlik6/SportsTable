using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TablicaWynikow.Properties;


namespace TablicaWynikow
{
    public partial class FormKonfig2 : Form
    {
        public FormKonfig2()
        {
            InitializeComponent();
        }
        private void ZapiszKonfig2()
        {
            Settings.Default.KolorCzcionka = TableForeColor.BackColor.Name;
            Settings.Default.KolorTło = TableBackColor.BackColor.Name;
            Settings.Default.NazwaGosp = hostName.Text;
            Settings.Default.OpisGosp = hostDescTxt.Text;
            Settings.Default.GospZdj = hostImageTxt.Text;
            Settings.Default.NazwaGosc = guestName.Text;
            Settings.Default.OpisGosc = guestDescTxt.Text;
            Settings.Default.GoscZdj = guestImageTxt.Text;
            Settings.Default.SciezkaZRelacja = sciezka_do_relacji.Text;

            Settings.Default.Save();
            Settings.Default.Reload();

        }
        private void BackToFormSport_Click(object sender, EventArgs e)
        {
            ZapiszKonfig2();
            this.Hide();
            FormSport formSport = new FormSport();
            formSport.ShowDialog();
            this.Close();
        }

        private void NextToTableForm_Click(object sender, EventArgs e)
        {
            ZapiszKonfig2();
            this.Hide();
            if(Settings.Default.Sport == "Piłka Nożna")
            {
                Form2 formPilkaNozna = new Form2();
                formPilkaNozna.ShowDialog();
            }
            else if(Settings.Default.Sport == "Siatkówka")
            {
                FormSiatkowka formSiatkowka = new FormSiatkowka();
                formSiatkowka.ShowDialog();
            }
            else if (Settings.Default.Sport == "Koszykówka")
            {
                FormKoszykowka formKoszykowka = new FormKoszykowka();
                formKoszykowka.ShowDialog();
            }

            this.Close();
        }

        private void TableForeColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = TableForeColor.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                TableForeColor.BackColor = MyDialog.Color;

        }

        private void TableBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = TableBackColor.BackColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                TableBackColor.BackColor = MyDialog.Color;
        }

        private void hostImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse PNG Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                hostImageTxt.Text = openFileDialog1.FileName;
            }
        }

        private void guestImageBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse PNG Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                guestImageTxt.Text = openFileDialog1.FileName;
            }
        }

        private void FormKonfig_Load(object sender, EventArgs e)
        {
            //Loading Font Color
            if (Settings.Default.KolorCzcionka.Substring(0, 2) == "ff")
            {
                string colorcode = Settings.Default.KolorCzcionka;
                int argb = Int32.Parse(colorcode, NumberStyles.HexNumber);
                TableForeColor.BackColor = Color.FromArgb(argb);
            }
            else
            {
                TableForeColor.BackColor = Color.FromName(Settings.Default.KolorCzcionka);

            }
            //Loading Background Color
            if (Settings.Default.KolorTło.Substring(0, 2) == "ff")
            {
                string colorcode = Settings.Default.KolorTło;
                int argb = Int32.Parse(colorcode, NumberStyles.HexNumber);
                TableBackColor.BackColor = Color.FromArgb(argb);
            }
            else
            {
                TableBackColor.BackColor = Color.FromName(Settings.Default.KolorTło);

            }
            
            hostName.Text = Settings.Default.NazwaGosp;
            hostDescTxt.Text = Settings.Default.OpisGosp;
            hostImageTxt.Text = Settings.Default.GospZdj;
            guestName.Text = Settings.Default.NazwaGosc;
            guestDescTxt.Text = Settings.Default.OpisGosc;
            guestImageTxt.Text = Settings.Default.GoscZdj;
            sciezka_do_relacji.Text = Settings.Default.SciezkaZRelacja;

        }

         
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                sciezka_do_relacji.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }
    }
}
