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
    public partial class Form1 : Form
    {
        private readonly IUserBusiness iUserBusiness;
        private readonly IVaultBusiness vaultBusiness;
        private Thread thread;
        public Form1(IUserBusiness iUserBusiness, IVaultBusiness vaultBusiness)
        {

            this.iUserBusiness = iUserBusiness;
            this.vaultBusiness = vaultBusiness;

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            this.ActiveControl = label_Email;
            panel_Registration.Visible = false;
            panel_LogIn.Visible = true;
            button_LogInChoose.PerformClick();
        }

        public void HideValidationLabels()
        {

            List<Label> validationLabels = new List<Label>() { label_EmailExist, label_Password, label_Email, label_ConfirmPassword, label_EmailLogin };

            foreach (var item in validationLabels)
            {
                item.Hide();
            }

        }

        private void button_SignUp_Enter(object sender, EventArgs e)
        {
            button_SignUp.BackColor = Color.FromArgb(35, 85, 148);
            button_SignUp.ForeColor = Color.White;
        }

        private void button_SignUp_Leave(object sender, EventArgs e)
        {
            button_SignUp.BackColor = Color.White;
            button_SignUp.ForeColor = Color.FromArgb(35, 85, 148);
        }

        private void button_LogIn_Enter(object sender, EventArgs e)
        {
            button_LogIn.BackColor = Color.FromArgb(35, 85, 148);
            button_LogIn.ForeColor = Color.White;
        }

        private void button_LogIn_Leave(object sender, EventArgs e)
        {
            button_LogIn.BackColor = Color.White;
            button_LogIn.ForeColor = Color.FromArgb(35, 85, 148);
        }


        private void button_LogInChoose_Click(object sender, EventArgs e)
        {
            button_LogInChoose.BackColor = Color.FromArgb(35, 85, 148);
            button_LogInChoose.ForeColor = Color.White;
            button_RegisterChoose.BackColor = Color.White;
            button_RegisterChoose.ForeColor = Color.FromArgb(35, 85, 148);
            panel_Registration.Visible = false;

            panel_LogIn.Visible = true;
            panel_LogIn.BringToFront();
        }

        private void button_RegisterChoose_Click(object sender, EventArgs e)
        {
            HideValidationLabels();
            button_RegisterChoose.BackColor = Color.FromArgb(35, 85, 148);
            button_RegisterChoose.ForeColor = Color.White;
            button_LogInChoose.BackColor = Color.White;
            button_LogInChoose.ForeColor = Color.FromArgb(35, 85, 148);
            panel_LogIn.Visible = false;
            panel_Registration.Visible = true;
            panel_Registration.BringToFront();
        }



        private void ResetPasswordMeter(List<Panel> panels)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].BackColor = Color.LightGray;
            }

        }

        private void ChangePasswordMeter(List<Panel> panels, string strength)
        {

            if (strength == "Weak")
            {
                panels[0].BackColor = Color.FromArgb(250, 54, 1);
                panels[1].BackColor = Color.LightGray;
                panels[2].BackColor = Color.LightGray;
            }

            if (strength == "Fair")
            {
                panels[0].BackColor = Color.FromArgb(250, 54, 1);
                panels[1].BackColor = Color.FromArgb(250, 213, 1);
                panels[2].BackColor = Color.LightGray;
            }
            if (strength == "Strong")
            {
                panels[0].BackColor = Color.FromArgb(250, 54, 1);
                panels[1].BackColor = Color.FromArgb(250, 213, 1);
                panels[2].BackColor = Color.FromArgb(94, 217, 138);
            }

        }

        private void textBox_Password_TextChanged(object sender, EventArgs e)
        {
            HideValidationLabels();
            string pass = textBox_Password.Text;
            List<Button> buttons = new List<Button>() { buttonLength, buttonNumbers, buttonLowercase, buttonUppercase };
            List<Panel> panels = new List<Panel>() { panel_1, panel_3, panel_4 };
            List<bool> requirements = IsValidPassword(pass);
            string strength = "";
            if (textBox_Password.Text != "")
            {
                strength = CalculatePasswordStrength(pass);
            }



            if (pass == "")
            {
                ResetRequirementsIcons(buttons);
                ResetPasswordMeter(panels);
            }
            else
            {
                ChangeRequirementsIcons(buttons, requirements);
                ChangePasswordMeter(panels, strength);
            }



        }

        private void button_SignUp_Click(object sender, EventArgs e)
        {
            string emailAddress = textBox_Email.Text;

            string password = textBox_Password.Text;

            string confirmPassword = textBox_ConfirmPassword.Text;

           
            if (password != confirmPassword)
                label_ConfirmPassword.Visible = true;
            if (CalculatePasswordStrength(textBox_Password.Text) == "Weak")
                label_Password.Visible = true;
            if (IsEmailAddressExist(textBox_Email.Text))
            {
                label_EmailExist.Visible = true;
            }
            if (emailAddress.Length == 0)
            {
                label_Email.Text = "Please enter your email address.";
                label_Email.Visible = true;
                return;
            }
            else
            {
                if (!IsValidEmailAddress(emailAddress))
                {
                    label_Email.Text = "Please enter a valid email address.";
                    label_Email.Visible = true;
                    return;
                }
            }


            if (IsValidEmailAddress(emailAddress) && textBox_Password.Text == textBox_ConfirmPassword.Text && textBox_Password.Text != "Password" && !IsEmailAddressExist(textBox_Email.Text) && CalculatePasswordStrength(textBox_Password.Text) != "Weak")
            {
                DialogResult dialogResult = MessageBox.Show("Did you saved or remembered your master password?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    label_EmailExist.Visible = false;

                    string email = textBox_Email.Text.Trim();
                    string passwordText = textBox_Password.Text;

                    iUserBusiness.InsertUser(passwordText, email);

                    textBox_EmailLogin.Text = "";
                    textBox_Email.Text = "";
                    textBox_Password.Text = "";
                    textBox_ConfirmPassword.Text = "";
                    textBox_PasswordLogin.Text = "";

                    string message = "Succesfull registration. Now you can login to your account!";

                    List<Button> buttons = new List<Button>() { buttonLength, buttonNumbers, buttonLowercase, buttonUppercase };
                    List<Panel> panels = new List<Panel>() { panel_1, panel_3, panel_4 };

                    ResetPasswordMeter(panels);
                    ResetRequirementsIcons(buttons);

                    MessageBox.Show(message);

                    panel_LogIn.Visible = true;
                    panel_LogIn.BringToFront();

                    button_LogInChoose.BackColor = Color.FromArgb(35, 85, 148);
                    button_LogInChoose.ForeColor = Color.White;
                    button_RegisterChoose.BackColor = Color.White;
                    button_RegisterChoose.ForeColor = Color.FromArgb(35, 85, 148);
                    panel_Registration.Visible = false;

                }
            }
        }

        public Boolean IsValidEmailAddress(string emailAddress)
        {
            return iUserBusiness.IsValidEmailAddress(emailAddress);
        }
        public List<Boolean> IsValidPassword(string password)
        {
            return iUserBusiness.ValidationOfPasswordRequirements(password);
        }
        public Boolean IsEmailAddressExist(string emailAddress)
        {
            return iUserBusiness.IsEmailAddressExist(emailAddress);
        }

        private void button_LogIn_Click(object sender, EventArgs e)
        {
            string emailAddress = textBox_EmailLogin.Text;
            string password = textBox_PasswordLogin.Text;
            if (!IsEmailAddressExist(textBox_EmailLogin.Text))
            {
                label_EmailLogin.Visible = true;
                return;
            }
            if (!LoginValidation(textBox_EmailLogin.Text, textBox_PasswordLogin.Text))
            {
                label_EmailLogin.Visible = true;
                return;
            }
            else
            {
                User user = iUserBusiness.GetUserInformation(emailAddress);

                string VaultKey = vaultBusiness.CreateVaultKey(emailAddress, password, user.Salt);

                List<Vault> vaults = vaultBusiness.GetUserVaults(user.UserID, VaultKey);

                thread = new Thread(() => OpenNewForm(user.UserID, user.EmailAddress, VaultKey, vaults, vaultBusiness, iUserBusiness));
                thread.Start();
                this.Dispose();


            }
        }
        private void OpenNewForm(int UserID, string EmailAddress, string VaultKey, List<Vault> vaults, IVaultBusiness vaultBusiness, IUserBusiness userBusiness)
        {
            Application.Run(new VaultsForm(UserID, EmailAddress, VaultKey, vaults, vaultBusiness, userBusiness));
        }


        private void buttonShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            TogglePasswordTextVisibility(new List<Button> { buttonShowHidePassword, buttonShowHideConfirmPassword }, new List<TextBox> { textBox_Password, textBox_ConfirmPassword });

        }
        private void buttonShowHidePassword_Click(object sender, EventArgs e)
        {
            TogglePasswordTextVisibility(new List<Button> { buttonShowHidePassword, buttonShowHideConfirmPassword }, new List<TextBox> { textBox_Password, textBox_ConfirmPassword });

        }
        private void buttonShowHidePasswordLogin_Click(object sender, EventArgs e)
        {
            TogglePasswordTextVisibility(new List<Button> { buttonShowHidePasswordLogin }, new List<TextBox> { textBox_PasswordLogin });
        }

        private void TogglePasswordTextVisibility(List<Button> buttons, List<TextBox> textBoxes)
        {
            foreach (var button in buttons)
            {
                if (textBoxes[0].UseSystemPasswordChar)
                {
                    button.BackgroundImage = global::PresentationLayer.Properties.Resources.hide;

                   
                }
                else
                {
                    button.BackgroundImage = global::PresentationLayer.Properties.Resources.show;
                   
                }
            }


            foreach (var textBox in textBoxes)
            {
                textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
            }
        }
        private void ChangeRequirementsIcons(List<Button> buttons, List<bool> requirements)
        {

            // buttons[0] => buttonLength
            // buttons[1] => buttonNumbers
            // buttons[2] => buttonUppercase
            // buttons[3] => buttonLowercase
            if (textBox_Password.Text != "Password")
            {
                for (int i = 0; i < requirements.Count - 1; i++)
                {
                    if (requirements[i])
                        buttons[i].BackgroundImage = global::PresentationLayer.Properties.Resources.success;
                    else
                        buttons[i].BackgroundImage = global::PresentationLayer.Properties.Resources.warning;
                }
            }

        }

        private void ResetRequirementsIcons(List<Button> buttons)
        {
            foreach (var item in buttons)
            {
                item.BackgroundImage = global::PresentationLayer.Properties.Resources.blank;
            }

        }
        bool LoginValidation(string emailAddress, string password)
        {
            return iUserBusiness.LoginValidation(emailAddress, password);
        }

        public string CalculatePasswordStrength(string password)
        {
            return iUserBusiness.CalculatePasswordStrength(password);
        }

        private void textBox_Email_TextChanged(object sender, EventArgs e)
        {
            HideValidationLabels();
        }

        private void textBox_ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            HideValidationLabels();
        }

        private void textBox_EmailLogin_TextChanged(object sender, EventArgs e)
        {
            HideValidationLabels();
        }

        private void textBox_PasswordLogin_TextChanged(object sender, EventArgs e)
        {
            HideValidationLabels();
        }
    }

}
