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
using PartyJuice.PJService.ModelsHelper;

namespace PartyJuice.PJManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

        }

        public ShopModel GetSelectedShop()
        {
            return (ShopModel) cbShops.SelectedItem;
        }

        public User GetUser()
        {
            using (var client = new PJServiceClient())
            {
                var user = client.GetUser(tbLogin.Text, tbPassword.Text);
                return user;
            }
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
                var shopList = client.GetShops();
                cbShops.Items.AddRange(shopList);
                if(cbShops.Items.Count == 0) return;
                cbShops.SelectedItem = cbShops.Items[0];
            }
        }
    }
}
