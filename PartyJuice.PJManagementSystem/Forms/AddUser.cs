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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            object[] elements = Enum.GetValues(typeof(Roles)).Cast<object>().ToArray();
            cbUserRoles.Items.AddRange(elements);
            cbUserRoles.SelectedIndex = 0;
        }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            btAddUser.Enabled = false;

            if (tbLogin.Text == "")
            {
                toolStripStatusLabelAddUser.Text = "Please enter login";
                btAddUser.Enabled = true;
                return;
            }
            else if (tbPassword.Text == "")
            {
                toolStripStatusLabelAddUser.Text = "Please enter password";
                btAddUser.Enabled = true;
                return;
            }
            
            var newUser = new User();
            newUser.Login = tbLogin.Text.Trim();
            newUser.Password = tbPassword.Text.Trim();
            newUser.Role = (Roles)cbUserRoles.SelectedItem;
            newUser.IsDeleted = false;

            using (var client = new PJServiceClient())
            {
                if (client.UserLoginValidation(newUser.Login))
                {
                    toolStripStatusLabelAddUser.Text = "User with the same login is already exist";
                    btAddUser.Enabled = true;
                    return;
                }
                client.AddUser(newUser);
                this.DialogResult = DialogResult.OK;
            }

            btAddUser.Enabled = true;
        }

        public string GetLogin()
        {
            return tbLogin.Text.Trim();
        }
    }
}
