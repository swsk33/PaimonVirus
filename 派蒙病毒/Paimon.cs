using System;
using System.Windows.Forms;
using System.Threading;

namespace PaimonVirus
{
    public partial class Paimon : Form
    {

        public Paimon()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Paimon_Load(object sender, EventArgs e)
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            Random random = new Random();
            this.Left = random.Next(0, width - this.Width);
            this.Top = random.Next(0, height - this.Height);
            new Thread(() =>
            {
                Thread.Sleep(2000);
                this.Close();
            }).Start();
        }
    }
}
