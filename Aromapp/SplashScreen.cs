using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class SplashScreen : Form
    {
        Timer timer;
        int x = 0;
        public SplashScreen()
        {

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += timer_tick;
            timer.Start();


            InitializeComponent();
            this.guna2ProgressBar1.Value += 50;


        }
        void timer_tick(object sender, EventArgs e)
        {
            x++;
            this.guna2ProgressBar1.Value += 10;
            if (x == 50)
            {
                timer.Stop();

            }
        }
    }
}
