using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Windows.Forms;

using PartyJuice.PJManagementSystem.Forms;
using PartyJuice.PJManagementSystem.PJServiceReference;
using PartyJuice.PJService;
using PartyJuice.PJService.ModelsHelper;

namespace PartyJuice.PJManagementSystem
{
    public partial class MainForm : Form
    {
        private ShopModel _shop;
        private User _currentUser;

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

            toolStripMain.Text = $"You entered into {_shop.Name}";

            _currentUser = loginForm.GetUser();
            lbName.Text = _currentUser?.Login;
            
            var Warehouses = _client.GetWarehouses(_shop.Id);

            if (Warehouses != null)
            {
                cbWarehouses.Items.Clear();
                cbWarehouses.Items.AddRange(Warehouses);
                cbWarehouses.SelectedItem = cbWarehouses.Items[0];
            }
            FillWarehouseElementsListView();
            var role = _currentUser?.Role.ToString();
            switch (role)
            {
                case "Admin":
                    if(!tc.Controls.Contains(tbUser))
                        tc.Controls.Add(tbUser);
                    return;
                case "Manager":
                    if(tc.Controls.Contains(tbUser))
                        tc.Controls.Remove(tbUser);
                    return;
                case "Seller":
                    if (tc.Controls.Contains(tbUser))
                        tc.Controls.Remove(tbUser);
                    return;
                case "StoreKeeper":
                    if (tc.Controls.Contains(tbUser))
                        tc.Controls.Remove(tbUser);
                    return;
                default:
                    return;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            lbName.Text = "";
            toolStripMain.Text = @"Logged out..";
            tc.SelectedTab = tc.TabPages[0];
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
            var warehouse = (WarehouseModel) cbWarehouses.SelectedItem;
            var warehouseElements = _client.GetWarehouseElements(warehouse.Id);
            
            if (warehouseElements == null) return;
            lvWarehouseElements.Items.Clear();
            int elementCount = warehouseElements.Length;
            for (int i = 0; i < elementCount; i++)
            {
                var element = warehouseElements[i];
                //var fullEl = _client.GetWarehouseElement(warehouseElements[i].Id);
                
                ListViewItem lvi = new ListViewItem((i + 1).ToString());
                //lvi.SubItems.Add(fullEl.DrinkName);
                lvi.SubItems.Add(element.Count.ToString());
                //lvi.SubItems.Add(fullEl.Id.ToString());

                lvWarehouseElements.Items.Add(lvi);
            }
        }

        private void tcUsers_Click(object sender, System.EventArgs e)
        {
            FillUserLV();
        }

        private void FillUserLV()
        {
            lvUsers.Items.Clear();
            var users = _client.GetAllUsers();
            if(users == null) return;
            int usersCount = users.Length;

            for (int i = 0; i < usersCount; i++)
            {
                var user = users[i];
                
                ListViewItem item = new ListViewItem((i+1).ToString());
                item.SubItems.Add(user.Login);
                item.SubItems.Add(user.Password);
                item.SubItems.Add(user.Role);
                item.SubItems.Add(user.Id.ToString());

                lvUsers.Items.Add(item);
            }
        }

        private void btAddUser_Click(object sender, System.EventArgs e)
        {
            AddUser addingUser = new AddUser();
            addingUser.ShowDialog();
            toolStripMain.Text = $"New user {addingUser.GetLogin()} added";
            FillUserLV();
        }

        private void btDelete_Click(object sender, System.EventArgs e)
        {
            var usersCount = lvUsers.SelectedItems.Count;
            if (usersCount == 0)
            {
                toolStripMain.Text = "No user selected to delete";
                return;
            }
            if (_currentUser.Login == lvUsers.SelectedItems[0].SubItems[1].Text)
            {
                toolStripMain.Text = "Sorry, you can't delete yourself..";
                return;
            }
            var selectedUserId = lvUsers.SelectedItems[0].SubItems[4];
            _client.DeleteUser(Guid.Parse(selectedUserId.Text));
            FillUserLV();
        }
    }
}
