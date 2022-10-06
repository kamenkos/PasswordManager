
namespace PresentationLayer
{
    partial class EditVaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditVaultForm));
            this.textBox_Email_Edit = new System.Windows.Forms.TextBox();
            this.textBox_Password_Edit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonShowHideConfirmPassword = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelGeneratePassword = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Name_Edit = new System.Windows.Forms.TextBox();
            this.textBox_URL_Edit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Email_Edit
            // 
            this.textBox_Email_Edit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Email_Edit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Email_Edit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox_Email_Edit.Location = new System.Drawing.Point(42, 218);
            this.textBox_Email_Edit.MaximumSize = new System.Drawing.Size(249, 18);
            this.textBox_Email_Edit.Name = "textBox_Email_Edit";
            this.textBox_Email_Edit.Size = new System.Drawing.Size(175, 18);
            this.textBox_Email_Edit.TabIndex = 57;
            // 
            // textBox_Password_Edit
            // 
            this.textBox_Password_Edit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Password_Edit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Password_Edit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox_Password_Edit.Location = new System.Drawing.Point(277, 218);
            this.textBox_Password_Edit.MaximumSize = new System.Drawing.Size(249, 18);
            this.textBox_Password_Edit.Name = "textBox_Password_Edit";
            this.textBox_Password_Edit.Size = new System.Drawing.Size(151, 18);
            this.textBox_Password_Edit.TabIndex = 61;
            this.textBox_Password_Edit.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(266, 212);
            this.label9.MinimumSize = new System.Drawing.Size(200, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 30);
            this.label9.TabIndex = 60;
            // 
            // buttonShowHideConfirmPassword
            // 
            this.buttonShowHideConfirmPassword.BackColor = System.Drawing.Color.White;
            this.buttonShowHideConfirmPassword.BackgroundImage = global::PresentationLayer.Properties.Resources.show;
            this.buttonShowHideConfirmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonShowHideConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowHideConfirmPassword.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonShowHideConfirmPassword.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonShowHideConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowHideConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.buttonShowHideConfirmPassword.Location = new System.Drawing.Point(429, 216);
            this.buttonShowHideConfirmPassword.Name = "buttonShowHideConfirmPassword";
            this.buttonShowHideConfirmPassword.Size = new System.Drawing.Size(34, 23);
            this.buttonShowHideConfirmPassword.TabIndex = 63;
            this.buttonShowHideConfirmPassword.UseVisualStyleBackColor = false;
            this.buttonShowHideConfirmPassword.Click += new System.EventHandler(this.buttonShowHideConfirmPassword_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelGeneratePassword);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.buttonShowHideConfirmPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_Password_Edit);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Email_Edit);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox_Name_Edit);
            this.panel1.Controls.Add(this.textBox_URL_Edit);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_Confirm);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 360);
            this.panel1.TabIndex = 64;
            // 
            // labelGeneratePassword
            // 
            this.labelGeneratePassword.AutoSize = true;
            this.labelGeneratePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGeneratePassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGeneratePassword.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelGeneratePassword.Location = new System.Drawing.Point(267, 247);
            this.labelGeneratePassword.Name = "labelGeneratePassword";
            this.labelGeneratePassword.Size = new System.Drawing.Size(169, 17);
            this.labelGeneratePassword.TabIndex = 81;
            this.labelGeneratePassword.Text = "Generate strong password";
            this.labelGeneratePassword.Click += new System.EventHandler(this.labelGeneratePassword_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.panel2.Location = new System.Drawing.Point(34, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 4);
            this.panel2.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 37);
            this.label1.TabIndex = 60;
            this.label1.Text = "Edit password vault";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(261, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "URL:";
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(31, 212);
            this.label6.MinimumSize = new System.Drawing.Size(200, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 30);
            this.label6.TabIndex = 56;
            // 
            // textBox_Name_Edit
            // 
            this.textBox_Name_Edit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Name_Edit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name_Edit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox_Name_Edit.Location = new System.Drawing.Point(277, 138);
            this.textBox_Name_Edit.MaximumSize = new System.Drawing.Size(249, 18);
            this.textBox_Name_Edit.Name = "textBox_Name_Edit";
            this.textBox_Name_Edit.Size = new System.Drawing.Size(175, 18);
            this.textBox_Name_Edit.TabIndex = 59;
            // 
            // textBox_URL_Edit
            // 
            this.textBox_URL_Edit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_URL_Edit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_URL_Edit.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox_URL_Edit.Location = new System.Drawing.Point(42, 138);
            this.textBox_URL_Edit.MaximumSize = new System.Drawing.Size(249, 18);
            this.textBox_URL_Edit.Name = "textBox_URL_Edit";
            this.textBox_URL_Edit.Size = new System.Drawing.Size(175, 18);
            this.textBox_URL_Edit.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(261, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password:";
            // 
            // button_Confirm
            // 
            this.button_Confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.button_Confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Confirm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.button_Confirm.FlatAppearance.BorderSize = 2;
            this.button_Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Confirm.ForeColor = System.Drawing.Color.White;
            this.button_Confirm.Location = new System.Drawing.Point(266, 281);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(200, 46);
            this.button_Confirm.TabIndex = 21;
            this.button_Confirm.Text = "Save";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username:";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(266, 132);
            this.label8.MinimumSize = new System.Drawing.Size(200, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 30);
            this.label8.TabIndex = 58;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.button_Cancel.FlatAppearance.BorderSize = 2;
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.button_Cancel.Location = new System.Drawing.Point(31, 281);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(200, 46);
            this.button_Cancel.TabIndex = 20;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(31, 132);
            this.label7.MinimumSize = new System.Drawing.Size(200, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 30);
            this.label7.TabIndex = 51;
            // 
            // EditVaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 360);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditVaultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Edit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Email_Edit;
        private System.Windows.Forms.TextBox textBox_Password_Edit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonShowHideConfirmPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Name_Edit;
        private System.Windows.Forms.TextBox textBox_URL_Edit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelGeneratePassword;
    }
}