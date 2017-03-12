using System.Windows.Forms;
using PartyJuice.PJManagementSystem.Forms;

namespace PartyJuice.PJManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            }
            toolStripMain.Text = $"You entered into {loginForm.GetSelectedShop()}";
        }

        private void logoutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            this.Enabled = false;
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            }
            toolStripMain.Text = $"You entered into {loginForm.GetSelectedShop()}";
            this.Enabled = true;
        }
    }
}
