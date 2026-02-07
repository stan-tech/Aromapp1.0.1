using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp
{
    public class HintTexBox:TextBox
    {

        public HintTexBox()
        {


            this.Click += TextBox_Click;
            this.Leave += TextBox_Leave;


        }
        void TextBox_Click(object sender, EventArgs e)
        {
            HintUtils.ShowHint(this);
        }
        void TextBox_Leave(object sender, EventArgs e)
        {
            HintUtils.HideHint(this);
        }

    }
}
