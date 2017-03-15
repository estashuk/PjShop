using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PartyJuice.PJManagementSystem.PJServiceReference;

namespace PartyJuice.PJManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        public PJShop GetSelectedShop()
        {
            return (PJShop) cbShops.SelectedItem;
        }

        public string GetUserLogin()
        {
            return tbLogin.Text;
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            btLogin.Enabled = false;
            using (var client = new PJServiceClient())
            {
                if (client.UserValidation(tbLogin.Text, tbPassword.Text) && cbShops.SelectedItem != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else if(!client.UserValidation(tbLogin.Text, tbPassword.Text))
                {
                    tsError.Text = @"Entered Login or Password is invalid!";
                }
                else if (cbShops.SelectedItem == null)
                {
                    tsError.Text = @"Please choose shop to enter!";
                }
                
            }
            btLogin.Enabled = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (var client = new PJServiceClient())
            {
                PJShop[] shopList = client.GetShops();
                cbShops.Items.AddRange(shopList);
                cbShops.SelectedItem = cbShops.Items[0];
            }
        }
    }
}
