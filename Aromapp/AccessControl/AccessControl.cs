using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aromapp.AccessControl
{
    public static class AccessControl
    {
        public static bool _granted;
        public static Form _form;
        private static Panel unauthorizedPanel;
        public static event EventHandler TrashClosing;

        public static bool Granted
        {
            get => _granted;
            set
            {
                _granted = value;
                UpdateAccessUI();
            }
        }


        public static Form _Form
        {
            get => _form; set
            {
                _form = value;
            }
        }
        public static void OnTrashClosing(object sender, EventArgs e)
        {

            if (unauthorizedPanel != null && !unauthorizedPanel.IsDisposed)
            {
                _form.Controls.Remove(unauthorizedPanel);
                unauthorizedPanel.Dispose();
                unauthorizedPanel = null;
            }
        }

        public static void UpdateAccessUI()
        {
            if (!_granted)
            {
                ShowUnauthorizedPanel();
            }
            else
            {
                if (unauthorizedPanel != null && !unauthorizedPanel.IsDisposed)
                {
                    _form.Controls.Remove(unauthorizedPanel);
                    unauthorizedPanel.Dispose();
                    unauthorizedPanel = null;
                }
            }
        }


        public static void ShowUnauthorizedPanel()
        {
            if (unauthorizedPanel == null || unauthorizedPanel.IsDisposed)
            {
                unauthorizedPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    Name = "unauthorizedPanel"
                };

                var showAuth = new Guna.UI2.WinForms.Guna2Button
                {
                    Text = "S'identifier",
                    Dock = DockStyle.Fill
                };

                showAuth.Click += (s, e) =>
                {
                    var confirm = new Confirm();
                    confirm.Passed += PasswoCorrectDelete;
                    confirm.ShowDialog();
                };

                unauthorizedPanel.Controls.Add(showAuth);

                _form.Controls.Add(unauthorizedPanel);
            }

            unauthorizedPanel.BringToFront();
            unauthorizedPanel.Visible = true;
        }
        public static void PasswoCorrectDelete(object sender, EventArgs e)
        {
            _granted = true;
            _form.Controls.Remove(unauthorizedPanel);
            unauthorizedPanel.Dispose();
        }
    }
}
