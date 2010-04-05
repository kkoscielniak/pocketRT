using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.WindowsCE.Forms;
using pocketRT.Properties;

namespace pocketRT
{
    public partial class MainForm : Form
    {
        #region DLLImport
        // import bibliotek potrzebnych do obsługi wibracji
        [DllImport("aygshell.dll")]
        private static extern int Vibrate(int cvn, IntPtr rgvn, bool fRepeat, uint
        dwTimeout);

        [DllImport("aygshell.dll")]
        public static extern int VibrateStop();

        const uint INFINITE = 0xffffffff;

        // import bibliotek potrzebnych do minimalizacji formy
        [DllImport("coredll.dll")]
        static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_MINIMIZED = 6;
        #endregion

        bool isTimerEnabled = false;
        bool useVibration = true;
        bool useSound = true;
        bool useCommuniqueList = false;

        Sound alert;  // plik dźwiękowy alertu
        ArrayList arrCommuniques;   // tablica komunikatów
        StreamReader sReader;
        StreamWriter sWriter;
        DialogResult dlgResult;

        public MainForm()
        {
            InitializeComponent();
            LoadResources();

            // tylko cyfry w intervalTextBox
            InputModeEditor.SetInputMode(intervalTextBox, InputMode.Numeric);

            ReadCommuniquesFile();
            PrepareAlert();
        }

        #region Methods

        // wczytuje dużo syfu z zasobów i przygotowuje formatkę
        private void LoadResources()
        {
            communiqueTextBox.Text = pocketRT.Properties.Resources.defaultCommunique;
        }

        private void PrepareAlert()
        {
            alert = new Sound(pocketRT.Properties.Resources.alert);
        }

        // uruchamia timer
        private bool RunTimer()
        {
            try
            {
                // konwersja na minuty dla timera
                timer.Interval = Int32.Parse(intervalTextBox.Text) *1000*60;
                timer.Enabled = true;
                isTimerEnabled = true;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // zatrzymuje timer
        private bool StopTimer()
        {
            try
            {
                timer.Enabled = false;
                isTimerEnabled = false;
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        // wywołanie po tyknięciu timera
        private void OnTickEvent()
        {
            if (useSound == true)
            {
                alert.Play();
            }
            if (useVibration == true)
            {
                    Vibrate(0, IntPtr.Zero, true, INFINITE);
                    Thread.Sleep(2000);
                    VibrateStop();
            }
            if (useVibration == false)
            {
                MessageBox.Show(communiqueTextBox.Text);
            }
            else
            {
                ShowRandomCommunique();
            }
        }

        // minimalizowanie formy
        private void Minimize() {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.WindowState = FormWindowState.Normal;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            ShowWindow(this.Handle, SW_MINIMIZED);
        }

        // odczytywanie pliku z komunikatami
        private void ReadCommuniquesFile()
        {
            try
            {
                sReader = new StreamReader("pocketRT_communiques.txt");
                arrCommuniques = new ArrayList();
                string sLine = "";

                while (sLine != null)
                {
                    sLine = sReader.ReadLine();
                    if (sLine != null)
                    {
                        arrCommuniques.Add(sLine);
                    }
                }
                sReader.Close();
            }
            catch (Exception err)
            {
                dlgResult = MessageBox.Show("Communiques file not found! " +
                    "Would you like to create one?",
                    "Error",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk,
                    MessageBoxDefaultButton.Button1);

                switch (dlgResult)
                {
                    // jeśli TAK - tworzy nowy plik z domyślnymi komunikatami
                    case DialogResult.Yes:
                        this.CreateDefaultCommuniquesFile();
                        break;

                    // jeśli NIE - blokuje pole wyboru listy komunikatów
                    case DialogResult.No:
                        listCheckBox.Enabled = false;
                        break;
                }
            }
        }

        // tworzy nowy plik z domyślnymi komunikatami
        private void CreateDefaultCommuniquesFile()
        {
            FileStream fStream = new FileStream("pocketRT_communiques.txt", FileMode.CreateNew,
                FileAccess.ReadWrite, FileShare.None);
            sWriter = new StreamWriter(fStream);

            string defaultCommuniques = pocketRT.Properties.Resources.defaultCommuniqueList;

            sWriter.Write(defaultCommuniques, Encoding.GetEncoding(1252));
            sWriter.Close();

            // ponownie otwiera plik z komunikatami
            this.ReadCommuniquesFile();
        }

        // losuje a następnie wyświetla komunikat z listy
        private void ShowRandomCommunique()
        {
            int communiquesCount = arrCommuniques.Count;

            int i = RandomNumber(0, communiquesCount - 1);

            MessageBox.Show(arrCommuniques[i].ToString(),
                "pocketRT",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        // generuje liczbę losową
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion

        #region Events

        // aktywuj/deaktywuj
        private void enableMenuItem_Click(object sender, EventArgs e)
        {
            if (isTimerEnabled == false)
            {
                if (RunTimer() == true)
                {
                    enableMenuItem.Text = pocketRT.Properties.Resources.disableMenuItemText;
                    intervalTextBox.Enabled = false;
                    communiqueTextBox.Enabled = false;
                    listCheckBox.Enabled = false;
                    statusLabel.ForeColor = Color.Green;
                    statusLabel.Text = pocketRT.Properties.Resources.enabledMenuItemText;
                }
            }
            else
            {
                if (StopTimer() == true)
                {
                    enableMenuItem.Text = pocketRT.Properties.Resources.enableMenuItemText;
                    intervalTextBox.Enabled = true;
                    communiqueTextBox.Enabled = true;
                    listCheckBox.Enabled = true;
                    statusLabel.ForeColor = Color.Red;
                    statusLabel.Text = pocketRT.Properties.Resources.disabledMenuItemText;
                    intervalTextBox.Focus();
                }
            }
        }

        // wyjscie z aplikacji
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            OnTickEvent();
        }

        private void hideMenuItem_Click(object sender, EventArgs e)
        {
            this.Minimize();
        }

        private void soundMenuItem_Click(object sender, EventArgs e)
        {
            if (soundMenuItem.Checked == true)
            {
                useSound = false;
                soundMenuItem.Checked = false;
            }
            else
            {
                useSound = true;
                soundMenuItem.Checked = true;
            }
        }

        private void vibrateMenuItem_Click(object sender, EventArgs e)
        {
            if (vibrateMenuItem.Checked == true)
            {
                useVibration = false;
                vibrateMenuItem.Checked = false;
            }
            else
            {
                useVibration = true;
                vibrateMenuItem.Checked = true;
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pocketRT.Properties.Resources.aboutText,
                "pocketRT",
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }

        private void listCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            communiqueTextBox.Enabled = false;
            useCommuniqueList = true;
        }

        #endregion       
    }
}