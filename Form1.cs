//////////////////////////////////////////
///    jack-debug | You Are An Idiot   ///
///    13/04/2021 | jack-debug.xyz     ///
//////////////////////////////////////////

using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youAreAnIdiot
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void change()
        {
        change:
            this.BackColor = Color.Black;
            this.label1.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;
            Thread.Sleep(500);
            this.BackColor = Color.White;
            this.label1.ForeColor = Color.Black;
            this.label3.ForeColor = Color.Black;
            Thread.Sleep(500);
            goto change;
        }
        private void flyAround()
        {
        fly:
            this.Left += 1;
            this.Top += 1;
            goto fly;
        }
        private void sound(string filee)
        {
            var soundPlayer = new SoundPlayer(filee);
        a:
            soundPlayer.PlaySync();
            goto a;
        }
        private void msgBoxSpam()
        {
            Random rnd = new Random();
        b:
            Thread.Sleep(rnd.Next(2000, 30000));
            MessageBox.Show("You are an idiot");
            goto b;
        }
        private void waitForFly()
        {
            Thread.Sleep(5000);
            Task.Factory.StartNew(this.flyAround);
            Thread.Sleep(10000);
            Task.Factory.StartNew(this.msgBoxSpam);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string file = @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\idiot.wav";
            if (!File.Exists(file))
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://jack-debug-xyz.github.io/idiot.wav", file);
            }
            Task.Factory.StartNew(this.change);
            Task.Factory.StartNew(() => sound(file));
            Task.Factory.StartNew(this.waitForFly);
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = true;
            //Form1 f = new Form1();
            //f.Show();
            //f.Show();
        }
    }
}