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
    public partial class Trash : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        string currentTab = "Produits";
        TrashView view;
        private bool _granted;
        private Panel unauthorizedPanel;


        

        public Trash()
        {
            InitializeComponent();

            AccessControl.AccessControl._Form = this;
            AccessControl.AccessControl.Granted = false;

        }

        private void Trash_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1032, 618);
            this.StartPosition= FormStartPosition.CenterParent;
            this.MinimumSize = this.Size;

            view = new TrashView(currentTab);
            view.Margin = new Padding(0);
            this.Margin = new Padding(0);

            Products.Controls.Clear();
            Products.Padding = new Padding(0);
            Products.Controls.Add(view);
            view.Dock = DockStyle.Fill;


        }

        private void TopTabs_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "Produits":
                    currentTab = "Produits";
                    LoadTrashView(Products, currentTab, view);
                    break;

                case "Clients":
                    currentTab = "Clients";
                    LoadTrashView(Clients, currentTab, view);
                    break;

                case "Suppliers":
                    currentTab = "Suppliers";
                    LoadTrashView(Suppliers, currentTab, view);
                    break;

                case "Purchases":
                    currentTab = "Purchases";
                    LoadTrashView(Purchases, currentTab, view);
                    break;

                case "Sales":
                    currentTab = "Sales";
                    LoadTrashView(Sales, currentTab, view);
                    break;

                case "Users":
                    currentTab = "Users";
                    LoadTrashView(Users, currentTab, view);
                    break;
            }
        }
        private void LoadTrashView(TabPage tab, string currentTab, TrashView view)
        {
            view = new TrashView(currentTab);
            view.Margin = new Padding(0);
            this.Margin = new Padding(0);

            tab.Controls.Clear();
            tab.Padding = new Padding(0);
            tab.Controls.Add(view);

            view.Dock = DockStyle.Fill;
        }
    }
}
