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

        private void btLogin_Click(object sender, EventArgs e)
        {
            btLogin.Enabled = false;
            using (var client = new PJServiceClient())
            {
                if (client.UserValidation(tbLogin.Text, tbPassword.Text))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    tsError.Text = @"Entered Login or Password is invalid!";
                }
            }
            btLogin.Enabled = true;
        }
    }
}
