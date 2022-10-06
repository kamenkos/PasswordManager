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
    public partial class AddVaultForm : Form
    {
        private readonly IVaultBusiness vaultBusiness;
        private int UserID;
        private string VaultKey;

        public AddVaultForm(int UserID, string VaultKey, IVaultBusiness vaultBusiness)
        {
            this.UserID = UserID;
            this.VaultKey = VaultKey;
            this.vaultBusiness = vaultBusiness;
            InitializeComponent();
        }

        private void button_Confirm_Click(object sender, EventArgs e)
        {
            String url = textBox_URL_New.Text;
            String name = textBox_Name_New.Text;
            String username = textBox_Email_New.Text;
            String password = textBox_Password_New.Text;
            if (url == "" && name == "" && username == "" && password == "")
            {
                Label_cancel.Visible = true;
            }
            else
            {
                VaultData vaultData = new VaultData(url, name, username, password);
                InsertVault(UserID, VaultKey, vaultData);
                this.Dispose();
            }
        }



        public void InsertVault(int userID, string vaultKey, VaultData vaultData)
        {
            vaultBusiness.InsertVault(userID, vaultKey, vaultData);
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (textBox_URL_New.Text != "" || textBox_Name_New.Text != "" || textBox_Email_New.Text != "" || textBox_Password_New.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("You have unsaved work! Are you sure you want to quit?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    this.Dispose();
                }


                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            if (textBox_URL_New.Text == "" || textBox_Name_New.Text == "" || textBox_Email_New.Text == "" || textBox_Password_New.Text == "")
                this.Dispose();


        }
        private void buttonShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordTextVisibility(buttonShowHideConfirmPassword ,textBox_Password_New);

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
            textBox_Password_New.Text = randomPassword;
        }

        private void textBox_URL_New_TextChanged(object sender, EventArgs e)
        {
            Label_cancel.Hide();
        }

        private void textBox_Name_New_TextChanged(object sender, EventArgs e)
        {
            Label_cancel.Hide();
        }

        private void textBox_Email_New_TextChanged(object sender, EventArgs e)
        {
            Label_cancel.Hide();
        }

        private void textBox_Password_New_TextChanged(object sender, EventArgs e)
        {
            Label_cancel.Hide();
        }
    }
}
