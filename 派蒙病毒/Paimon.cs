using System;
using System.Windows.Forms;
using System.Threading;

namespace PaimonVirus
{
    public partial class Paimon : Form
    {
        private int x;

        private int y;
        
        public Paimon(int x, int y)
        {
            this.x = x;
            this.y = y;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Paimon_Load(object sender, EventArgs e)
        {
            this.Left = x;
            this.Top = y;
            new Thread(() =>
            {
                Thread.Sleep(2000);
                this.Close();
            }).Start();
        }
    }
}