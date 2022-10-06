
namespace PresentationLayer
{
    partial class VaultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VaultsForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelUserEmailAddress = new System.Windows.Forms.Label();
            this.panelUserIcon = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMain = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAddNewVault = new System.Windows.Forms.Button();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.flowLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.labelUserEmailAddress);
            this.panelHeader.Controls.Add(this.panelUserIcon);
            this.panelHeader.Controls.Add(this.panel1);
            this.panelHeader.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(997, 70);
            this.panelHeader.TabIndex = 0;
            // 
            // labelUserEmailAddress
            // 
            this.labelUserEmailAddress.AutoSize = true;
            this.labelUserEmailAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserEmailAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.labelUserEmailAddress.Location = new System.Drawing.Point(107, 18);
            this.labelUserEmailAddress.Name = "labelUserEmailAddress";
            this.labelUserEmailAddress.Size = new System.Drawing.Size(194, 25);
            this.labelUserEmailAddress.TabIndex = 2;
            this.labelUserEmailAddress.Text = "example@email.com";
            // 
            // panelUserIcon
            // 
            this.panelUserIcon.BackgroundImage = global::PresentationLayer.Properties.Resources.UserLoginIcon;
            this.panelUserIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelUserIcon.Location = new System.Drawing.Point(45, 3);
            this.panelUserIcon.Name = "panelUserIcon";
            this.panelUserIcon.Size = new System.Drawing.Size(60, 60);
            this.panelUserIcon.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PresentationLayer.Properties.Resources.logoutIcon;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(894, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 40);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flowLayoutPanelMain
            // 
            this.flowLayoutPanelMain.AutoScroll = true;
            this.flowLayoutPanelMain.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelMain.Controls.Add(this.buttonAddNewVault);
            this.flowLayoutPanelMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.flowLayoutPanelMain.Location = new System.Drawing.Point(45, 150);
            this.flowLayoutPanelMain.Name = "flowLayoutPanelMain";
            this.flowLayoutPanelMain.Padding = new System.Windows.Forms.Padding(35, 20, 20, 20);
            this.flowLayoutPanelMain.Size = new System.Drawing.Size(889, 543);
            this.flowLayoutPanelMain.TabIndex = 3;
            this.flowLayoutPanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMain_Paint);
            // 
            // buttonAddNewVault
            // 
            this.buttonAddNewVault.BackgroundImage = global::PresentationLayer.Properties.Resources.AddNewIcon;
            this.buttonAddNewVault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddNewVault.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddNewVault.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonAddNewVault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddNewVault.ForeColor = System.Drawing.Color.Transparent;
            this.buttonAddNewVault.Location = new System.Drawing.Point(35, 20);
            this.buttonAddNewVault.Margin = new System.Windows.Forms.Padding(0, 0, 20, 20);
            this.buttonAddNewVault.Name = "buttonAddNewVault";
            this.buttonAddNewVault.Size = new System.Drawing.Size(250, 150);
            this.buttonAddNewVault.TabIndex = 0;
            this.buttonAddNewVault.UseVisualStyleBackColor = true;
            this.buttonAddNewVault.Click += new System.EventHandler(this.buttonAddNewVault_Click);
            this.buttonAddNewVault.MouseEnter += new System.EventHandler(this.buttonAddNewVault_MouseHover);
            this.buttonAddNewVault.MouseLeave += new System.EventHandler(this.buttonAddNewVault_MouseLeave);
            // 
            // panelFooter
            // 
            this.panelFooter.BackgroundImage = global::PresentationLayer.Properties.Resources.FooterBackground;
            this.panelFooter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelFooter.Location = new System.Drawing.Point(4, 741);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(993, 90);
            this.panelFooter.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(76, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search by name:";
            // 
            // textBox_Search
            // 
            this.textBox_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Search.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Search.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox_Search.Location = new System.Drawing.Point(245, 102);
            this.textBox_Search.MaximumSize = new System.Drawing.Size(249, 18);
            this.textBox_Search.MaxLength = 50;
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(249, 18);
            this.textBox_Search.TabIndex = 51;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(235, 97);
            this.label7.MinimumSize = new System.Drawing.Size(273, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 30);
            this.label7.TabIndex = 52;
            // 
            // VaultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(979, 831);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.flowLayoutPanelMain);
            this.Controls.Add(this.panelHeader);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VaultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password manager";
            this.Load += new System.EventHandler(this.VaultForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.flowLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelUserIcon;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMain;
        private System.Windows.Forms.Label labelUserEmailAddress;
        private System.Windows.Forms.Button buttonAddNewVault;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Label label7;
    }
}