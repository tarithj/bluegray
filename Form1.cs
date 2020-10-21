using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace bluegray
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.TransparencyKey = this.BackColor; // Sets the transparancy key to the background color
            this.TopMost = true;

            // Removes the border
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.Text = String.Empty;

            System.Threading.Timer t = new System.Threading.Timer(timerC, null, 25000, 25000);

        }

        Timer t;
        Random r;
        string[] msgs = { "REGISTRY_ERROR (0x00000051)", "Fatel Error", "Out of memory or system resources. Close some programs and try again", "Cant load user " + Environment.UserName, "0x000146 ERROR", "0x012458 Error", "CPU usage too high", "Memory usage too high" };


        private void timerC(object state)
        {
            Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Left = 0;
            this.Top = 0;

            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;

            t = new Timer();
            r = new Random();

            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            int generateNumber = r.Next(2);
            t.Interval = r.Next(200, 2000);

            if (generateNumber == 1)
            {
                Bitmap blueError;
                int ranBackgroud = r.Next(2);
                if (ranBackgroud == 0)
                {
                    blueError = Properties.Resources.bluescreen;
                } else
                {
                    blueError = Properties.Resources.death;
                }
                this.BackgroundImage = blueError;
            }
            else
            {
                this.BackgroundImage = null;
            }
            switch (generateNumber)
            {
                case 1:
                    MessageBox.Show(msgs[r.Next(msgs.Length)]);
                    break;
            }

        }
        
    }
}
