using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public partial class AccountItem : DevExpress.XtraEditors.XtraUserControl
    {
        public bool SELECTED { get; set; }

        bool selected = false;
        private Timer timer;
        private int targetX;
        private int currentX;
        public AccountItem()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SELECTED = false;
            InitializeTimer();
            this.Load += OnLoad;

        }

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 10; // Adjust the interval for smoothness
            timer.Tick += Timer_Tick;
            targetX = Left / 10;
            Left = -Width; // Start off-screen to the left
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Gradually move the control towards its target X position
            if (currentX < targetX)
            {
                currentX += 10; // Adjust the step size for speed
                if (currentX > targetX)
                {
                    currentX = targetX;
                    timer.Stop(); // Stop the timer once reached the target position
                }
                Left = currentX;
            }
        }
        public void Select()
        {
            this.BackColor = Color.DodgerBlue;
            this.name.ForeColor = Color.White;
            this.amount.ForeColor = Color.White;
            roundedButton1.Image = Properties.Resources.PW;
        }

        public void UnSelect()
        {
            this.BackColor = Color.LightSteelBlue;
            this.name.ForeColor = Color.Black;
            this.amount.ForeColor = Color.Black;
            roundedButton1.Image = Properties.Resources.PB;

        }
        private void AccountItem_MouseEnter(object sender, EventArgs e)
        {
            Select();
        }

        private void AccountItem_MouseLeave(object sender, EventArgs e)
        {

            if (!selected && !SELECTED)
            {
                UnSelect();
            }
        }



        private void AccountItem_Load(object sender, EventArgs e)
        {

        }




        public void OnLoad(object sender, EventArgs e)
        {


        }


        public int CornerRadius { get; set; } = 15;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            int radius = CornerRadius * 2;

            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(Width - radius, Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, Height - radius, radius, radius), 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            using (Pen pen = new Pen(this.ForeColor, 1))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
