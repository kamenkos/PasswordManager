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
    public partial class EditVaultForm : Form
    {


        private readonly IVaultBusiness vaultBusiness;
        private int UserID;
        private int vaultId;
        private string VaultKey;
        private VaultData vaultData;

        public EditVaultForm(int UserID, string VaultKey, IVaultBusiness vaultBusiness, VaultData vaultData, int vaultId)
        {
            this.UserID = UserID;
            this.vaultData = vaultData;
            this.VaultKey = VaultKey;
            this.vaultId = vaultId;
            this.vaultBusiness = vaultBusiness;
            InitializeComponent();
        }



        private void Edit_Load(object sender, EventArgs e)
        {

            textBox_URL_Edit.Text = vaultData.URL;
            textBox_Name_Edit.Text = vaultData.Name;
            textBox_Email_Edit.Text = vaultData.Username;
            textBox_Password_Edit.Text = vaultData.Password;
        }



        private void button_Confirm_Click(object sender, EventArgs e)
        {
            String url = textBox_URL_Edit.Text;
            String name = textBox_Name_Edit.Text;
            String username = textBox_Email_Edit.Text;
            String password = textBox_Password_Edit.Text;



            VaultData vaultData = new VaultData(url, name, username, password);


            UpdateVault(UserID, vaultId, VaultKey, vaultData);


            this.Dispose();

        }
        private void OpenVaultForm(int UserID, string EmailAddress, string VaultKey, List<Vault> vaults, IVaultBusiness vaultBusiness, IUserBusiness iUserBusiness)
        {
            Application.Run(new VaultsForm(UserID, EmailAddress, VaultKey, vaults, vaultBusiness, iUserBusiness));
        }
        public void UpdateVault(int userID, int vaultID, string vaultKey, VaultData vaultData)
        {
            vaultBusiness.UpdateVault(userID, vaultID, vaultKey, vaultData);

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (textBox_URL_Edit.Text != vaultData.URL || textBox_Name_Edit.Text != vaultData.Name || textBox_Email_Edit.Text != vaultData.Username || textBox_Password_Edit.Text != vaultData.Password)
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved changes! Are you sure you want to quit?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Dispose();
                }


                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else
            {
                this.Dispose();
            }
        }


        private void buttonShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordTextVisibility(buttonShowHideConfirmPassword , textBox_Password_Edit );

        }
        private void TogglePasswordTextVisibility(Button button, TextBox textBox)
        {
                if (textBox.UseSystemPasswordChar)
                {
                    button.BackgroundImage = global::PresentationLayer.Properties.Resources.hide;

                }
                else
                {
                    button.BackgroundImage = global::PresentationLayer.Properties.Resources.show;

                }
          
            
                textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
            
        }

        private void labelGeneratePassword_Click(object sender, EventArgs e)
        {
            string randomPassword = vaultBusiness.CreateRandomPassword(15);
            textBox_Password_Edit.Text = randomPassword;
        }
    }
}
