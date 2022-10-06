using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class VaultsForm : Form
    {
        private Thread thread;
        private int UserID;
        private string EmailAddress;
        private string VaultKey;
        private List<Vault> vaults;
        private readonly IVaultBusiness vaultBusiness;
        private readonly IUserBusiness iUserBusiness;
        public VaultsForm(int UserID, string EmailAddress, string VaultKey, List<Vault> vaults, IVaultBusiness vaultBusiness, IUserBusiness iUserBusiness)
        {
            this.iUserBusiness = iUserBusiness;
            this.UserID = UserID;
            this.EmailAddress = EmailAddress;
            this.VaultKey = VaultKey;
            this.vaults = vaults;
            this.vaultBusiness = vaultBusiness;
            InitializeComponent();
        }

        private void VaultForm_Load(object sender, EventArgs e)
        {
            refreshVolts(vaults);
        }
        public void clearLayout()
        {
            while (flowLayoutPanelMain.Controls.Count > 1) 
                flowLayoutPanelMain.Controls.RemoveAt(1);
        }
        public  void refreshVolts(List<Vault> vaults)
        {
            
            labelUserEmailAddress.Text = EmailAddress;
            
            foreach (Vault vault in vaults)
            {
                
                VaultData vaultData = vault.VaultDataDecrypted;

                int vaultID = vault.VaultID;

                Panel panel = new Panel();
                panel.Padding = new Padding(15);
                panel.Margin = new Padding(0, 0, 20, 20);
                panel.Size = new Size(250, 145);
                panel.BackColor = Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Name = $"panelVault{vault.VaultID}";

                Label labelName = new Label();
                string Name = vaultData.Name.Length <= 9 ? vaultData.Name : vaultData.Name.Substring(0, 9) + "...";
                labelName.Text = Name;
                labelName.Font = new Font("Segoe UI", 30.75F);
                labelName.AutoSize = true;
                labelName.Top = 10;
                panel.Controls.Add(labelName);


                Label labelUsername = new Label();
                string username = vaultData.Username.Length <= 25 ? vaultData.Username : vaultData.Username.Substring(0, 23) + "...";
                labelUsername.Text = username;
                labelUsername.Font = new Font("Segoe UI", 12.75F);
                labelUsername.AutoSize = true;
                labelUsername.Margin = new Padding(30, 10, 10, 10);
                labelUsername.Top = 70;
                labelUsername.Left = 10;
                panel.Controls.Add(labelUsername);


                Label labelEdit = new Label();
                labelEdit.Text = "Edit";
                labelEdit.Font = new Font("Segoe UI", 12.75F);
                labelEdit.AutoSize = true;
                labelEdit.Margin = new Padding(30, 10, 10, 10);
                labelEdit.Top = 110;
                labelEdit.Left = 10;
                labelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
                labelEdit.Name = $"labelEdit{vault.VaultID}";
                labelEdit.Click += labelEdit_Click;
                panel.Controls.Add(labelEdit);




                Label labelDelete = new Label();

                labelDelete.Text = "Delete";
                labelDelete.ForeColor = Color.Red;
                labelDelete.Font = new Font("Segoe UI", 12.75F);
                labelDelete.AutoSize = true;
                labelDelete.Margin = new Padding(30, 10, 10, 10);
                labelDelete.Top = 110;
                labelDelete.Left = 50;
                labelDelete.Cursor = System.Windows.Forms.Cursors.Hand;
                labelDelete.Name = $"labelDelete{vault.VaultID}";
                labelDelete.Click += labelDelete_Click;
                panel.Controls.Add(labelDelete);

                flowLayoutPanelMain.Controls.Add(panel);
            }
        }

        private void UpdateVaults(List<Vault> vaults)
        {


        }

        public VaultData GetVaultData(int VaultID)
        {
            VaultData vaultData = new VaultData();
            foreach (var item in vaults)
            {
                if (item.VaultID == VaultID)
                    vaultData = item.VaultDataDecrypted;
            }
            return vaultData;
        }
        

        public void labelEdit_Click(object sender, EventArgs e)
        {
            Label labelEdit = sender as Label;

            string labelName = labelEdit.Name;

            string removedLabelName = labelName.Replace("labelEdit", "");

            int VaultID = Convert.ToInt32(removedLabelName);
            VaultData vaultData = GetVaultData(VaultID);

            this.Enabled = false;
            using (EditVaultForm vault = new EditVaultForm(UserID, VaultKey, vaultBusiness,vaultData, VaultID))
            {
                vault.ShowDialog();
            }

            clearLayout();
            vaults.Clear();
            vaults = vaultBusiness.GetUserVaults(UserID, VaultKey);
            refreshVolts(vaults);
            string nameToSearch = textBox_Search.Text;
            SearchByName(nameToSearch);


            this.Enabled = true;
        }
        

        public int FindItemListIndex(List<Vault> vaults, int VaultID)
        {
            int index = 0;

            for (int i = 0; i < vaults.Count; i++)
            {
                if (vaults[i].VaultID == VaultID)
                    index = i;
            }


            return index;


        }

        public void labelDelete_Click(object sender, EventArgs e)
        {
            Label labelDelete = sender as Label;

            string labelName = labelDelete.Name;

            string removedLabelName = labelName.Replace("labelDelete", "");

            int VaultID = Convert.ToInt32(removedLabelName);

            Control panelToDelete = flowLayoutPanelMain.Controls.Find($"panelVault{VaultID}", true)[0];

            

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                flowLayoutPanelMain.Controls.Remove(panelToDelete);
                int vaultIndex = FindItemListIndex(vaults, VaultID);
                this.vaults.RemoveAt(vaultIndex);
                vaultBusiness.DeleteVault(this.UserID, VaultID);
                string nameToSearch = textBox_Search.Text;
                SearchByName(nameToSearch);
            }


            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void buttonAddNewVault_MouseHover(object sender, EventArgs e)
        {

            buttonAddNewVault.BackgroundImage = global::PresentationLayer.Properties.Resources.AddNewIconHover;

        }

        private void buttonAddNewVault_MouseLeave(object sender, EventArgs e)
        {
            buttonAddNewVault.BackgroundImage = global::PresentationLayer.Properties.Resources.AddNewIcon;
        }

        private void flowLayoutPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            


            thread = new Thread(() => OpenRegistrationForm(iUserBusiness, vaultBusiness));
            thread.Start();
            this.Dispose();

        }
        private void OpenRegistrationForm(IUserBusiness iUserBusiness, IVaultBusiness vaultBusiness)
        {
            Application.Run(new Form1(iUserBusiness, vaultBusiness));
        }

        private void buttonAddNewVault_Click(object sender, EventArgs e)
        {

            if (vaults.Count < 50)
            {
                this.Enabled = false;

                using (AddVaultForm vault = new AddVaultForm(UserID, VaultKey, vaultBusiness))
                {
                    vault.ShowDialog();
                }
                clearLayout();
                vaults.Clear();
                vaults = vaultBusiness.GetUserVaults(UserID, VaultKey);
                refreshVolts(vaults);

                this.Enabled = true;
            }
            else {
                MessageBox.Show("Maximum number of vaults is 50.");
            }
        }

        public void SearchByName(string nameToSearch)
        {
            if (nameToSearch.Length != 0)
            {
                buttonAddNewVault.Hide();
                foreach (var item in vaults)
                {
                    Control panelToHide = flowLayoutPanelMain.Controls.Find($"panelVault{item.VaultID}", true)[0];
                    if (!item.VaultDataDecrypted.Name.StartsWith(nameToSearch, StringComparison.OrdinalIgnoreCase))
                        panelToHide.Hide();
                    else {

                        panelToHide.Show();
                    }

                }


            }
            else
            {
                buttonAddNewVault.Show();
                textBox_Search.Text = "";
                foreach (var item in vaults)
                {
                    Control panelToHide = flowLayoutPanelMain.Controls.Find($"panelVault{item.VaultID}", true)[0];
                    panelToHide.Show();

                }
            }
        }
      
        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            string nameToSearch = textBox_Search.Text;

            SearchByName(textBox_Search.Text);



        }
    }
}
