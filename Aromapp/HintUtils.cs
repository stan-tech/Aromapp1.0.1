using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public class HintUtils
    {
        public static void ShowHint(HintTexBox box)
        {
            if (string.IsNullOrEmpty(box.Text))
            {
                box.Text = (string)box.Tag;
                box.ForeColor = Color.Gray;
            }
        }
        public static void HideHint(HintTexBox box)
        {
            if (box.Text == (string)box.Tag)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }


        }
        public static void ShowHint(Guna2TextBox box)
        {
            if (string.IsNullOrEmpty(box.Text))
            {
                box.Text = (string)box.Tag;
                box.ForeColor = Color.Gray;
            }
        }
        public static void HideHint(Guna2TextBox box)
        {
            if (box.Text == (string)box.Tag)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }


        }
    }
}
