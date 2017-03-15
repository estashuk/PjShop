using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Windows.Forms;
using PartyJuice.PJManagementSystem.Forms;
using PartyJuice.PJManagementSystem.PJServiceReference;

namespace PartyJuice.PJManagementSystem
{
    public partial class MainForm : Form
    {
        private PJShop _shop;
        readonly PJServiceClient _client = new PJServiceClient();
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
            InitializationAfterLogin(loginForm);
        }

        private void InitializationAfterLogin(LoginForm loginForm)
        {
            _shop = loginForm.GetSelectedShop();

            toolStripMain.Text = $"You entered into {_shop}";

            lbName.Text = loginForm.GetUserLogin();

            Warehouse[] Warehouses = _client.GetWarehouses(_shop);
            if (Warehouses != null)
            {
                cbWarehouses.Items.AddRange(Warehouses);
                cbWarehouses.SelectedItem = cbWarehouses.Items[0];
            }

            FillWarehouseElementsListView();
        }

        private void logoutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            lbName.Text = "";
            toolStripMain.Text = @"Logged out..";
            this.Enabled = false;
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.Cancel)
            {
                Close();
            }
            InitializationAfterLogin(loginForm);
            this.Enabled = true;
        }

        private void FillWarehouseElementsListView()
        {
            WarehouseElement[] warehouseElements = _client.GetWarehouseElements((Warehouse) cbWarehouses.SelectedItem);
            lvWarehouseElements.Items.Clear();
            if (warehouseElements == null) return;
            int elementCount = warehouseElements.Length;
            for (int i = 0; i < elementCount; i++)
            {
                var element = warehouseElements[i];

                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                lvi.SubItems.Add(element.Drink.Name);
                lvi.SubItems.Add(element.Count.ToString());

                lvWarehouseElements.Items.Add(lvi);
            }
        }
    }
}
