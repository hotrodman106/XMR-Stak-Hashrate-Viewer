namespace XMR_Stak_Hashrate_Viewer
{
    partial class LoginScreen
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
            this.controlcontainer = new System.Windows.Forms.TableLayoutPanel();
            this.loginbuttoncontainer = new MetroFramework.Controls.MetroPanel();
            this.loginbutton = new MetroFramework.Controls.MetroButton();
            this.passwordtextboxcontainer = new MetroFramework.Controls.MetroPanel();
            this.passwordtextbox = new MetroFramework.Controls.MetroTextBox();
            this.usernametextboxcontainer = new MetroFramework.Controls.MetroPanel();
            this.usernametextbox = new MetroFramework.Controls.MetroTextBox();
            this.controlcontainer.SuspendLayout();
            this.loginbuttoncontainer.SuspendLayout();
            this.passwordtextboxcontainer.SuspendLayout();
            this.usernametextboxcontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlcontainer
            // 
            this.controlcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlcontainer.ColumnCount = 1;
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.controlcontainer.Controls.Add(this.loginbuttoncontainer, 0, 2);
            this.controlcontainer.Controls.Add(this.passwordtextboxcontainer, 0, 1);
            this.controlcontainer.Controls.Add(this.usernametextboxcontainer, 0, 0);
            this.controlcontainer.Location = new System.Drawing.Point(2, 25);
            this.controlcontainer.Name = "controlcontainer";
            this.controlcontainer.RowCount = 3;
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.controlcontainer.Size = new System.Drawing.Size(243, 125);
            this.controlcontainer.TabIndex = 0;
            // 
            // loginbuttoncontainer
            // 
            this.loginbuttoncontainer.Controls.Add(this.loginbutton);
            this.loginbuttoncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginbuttoncontainer.HorizontalScrollbarBarColor = true;
            this.loginbuttoncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.loginbuttoncontainer.HorizontalScrollbarSize = 10;
            this.loginbuttoncontainer.Location = new System.Drawing.Point(3, 85);
            this.loginbuttoncontainer.Name = "loginbuttoncontainer";
            this.loginbuttoncontainer.Size = new System.Drawing.Size(237, 37);
            this.loginbuttoncontainer.TabIndex = 0;
            this.loginbuttoncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginbuttoncontainer.VerticalScrollbarBarColor = true;
            this.loginbuttoncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.loginbuttoncontainer.VerticalScrollbarSize = 10;
            // 
            // loginbutton
            // 
            this.loginbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginbutton.Location = new System.Drawing.Point(0, 0);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(237, 37);
            this.loginbutton.TabIndex = 3;
            this.loginbutton.TabStop = false;
            this.loginbutton.Text = "Login";
            this.loginbutton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.loginbutton.UseSelectable = true;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // passwordtextboxcontainer
            // 
            this.passwordtextboxcontainer.Controls.Add(this.passwordtextbox);
            this.passwordtextboxcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordtextboxcontainer.HorizontalScrollbarBarColor = true;
            this.passwordtextboxcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.passwordtextboxcontainer.HorizontalScrollbarSize = 10;
            this.passwordtextboxcontainer.Location = new System.Drawing.Point(3, 44);
            this.passwordtextboxcontainer.Name = "passwordtextboxcontainer";
            this.passwordtextboxcontainer.Size = new System.Drawing.Size(237, 35);
            this.passwordtextboxcontainer.TabIndex = 1;
            this.passwordtextboxcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordtextboxcontainer.VerticalScrollbarBarColor = true;
            this.passwordtextboxcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.passwordtextboxcontainer.VerticalScrollbarSize = 10;
            // 
            // passwordtextbox
            // 
            this.passwordtextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.passwordtextbox.CustomButton.Image = null;
            this.passwordtextbox.CustomButton.Location = new System.Drawing.Point(208, 1);
            this.passwordtextbox.CustomButton.Name = "";
            this.passwordtextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordtextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordtextbox.CustomButton.TabIndex = 1;
            this.passwordtextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordtextbox.CustomButton.UseSelectable = true;
            this.passwordtextbox.CustomButton.Visible = false;
            this.passwordtextbox.Lines = new string[0];
            this.passwordtextbox.Location = new System.Drawing.Point(4, 9);
            this.passwordtextbox.MaxLength = 32767;
            this.passwordtextbox.Name = "passwordtextbox";
            this.passwordtextbox.PasswordChar = '*';
            this.passwordtextbox.WaterMark = "Password";
            this.passwordtextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordtextbox.SelectedText = "";
            this.passwordtextbox.SelectionLength = 0;
            this.passwordtextbox.SelectionStart = 0;
            this.passwordtextbox.ShortcutsEnabled = true;
            this.passwordtextbox.Size = new System.Drawing.Size(230, 23);
            this.passwordtextbox.TabIndex = 2;
            this.passwordtextbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.passwordtextbox.UseSelectable = true;
            this.passwordtextbox.WaterMark = "Password";
            this.passwordtextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordtextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // usernametextboxcontainer
            // 
            this.usernametextboxcontainer.Controls.Add(this.usernametextbox);
            this.usernametextboxcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usernametextboxcontainer.HorizontalScrollbarBarColor = true;
            this.usernametextboxcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.usernametextboxcontainer.HorizontalScrollbarSize = 10;
            this.usernametextboxcontainer.Location = new System.Drawing.Point(3, 3);
            this.usernametextboxcontainer.Name = "usernametextboxcontainer";
            this.usernametextboxcontainer.Size = new System.Drawing.Size(237, 35);
            this.usernametextboxcontainer.TabIndex = 2;
            this.usernametextboxcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usernametextboxcontainer.VerticalScrollbarBarColor = true;
            this.usernametextboxcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.usernametextboxcontainer.VerticalScrollbarSize = 10;
            // 
            // usernametextbox
            // 
            this.usernametextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.usernametextbox.CustomButton.Image = null;
            this.usernametextbox.CustomButton.Location = new System.Drawing.Point(208, 1);
            this.usernametextbox.CustomButton.Name = "";
            this.usernametextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.usernametextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.usernametextbox.CustomButton.TabIndex = 1;
            this.usernametextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.usernametextbox.CustomButton.UseSelectable = true;
            this.usernametextbox.CustomButton.Visible = false;
            this.usernametextbox.Lines = new string[0];
            this.usernametextbox.Location = new System.Drawing.Point(4, 9);
            this.usernametextbox.MaxLength = 32767;
            this.usernametextbox.Name = "usernametextbox";
            this.usernametextbox.PasswordChar = '\0';
            this.usernametextbox.WaterMark = "Username";
            this.usernametextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.usernametextbox.SelectedText = "";
            this.usernametextbox.SelectionLength = 0;
            this.usernametextbox.SelectionStart = 0;
            this.usernametextbox.ShortcutsEnabled = true;
            this.usernametextbox.Size = new System.Drawing.Size(230, 23);
            this.usernametextbox.TabIndex = 1;
            this.usernametextbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usernametextbox.UseSelectable = true;
            this.usernametextbox.WaterMark = "Username";
            this.usernametextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.usernametextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // LoginScreen
            // 
            this.AcceptButton = this.loginbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 150);
            this.Controls.Add(this.controlcontainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginScreen";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.controlcontainer.ResumeLayout(false);
            this.loginbuttoncontainer.ResumeLayout(false);
            this.passwordtextboxcontainer.ResumeLayout(false);
            this.usernametextboxcontainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel controlcontainer;
        private MetroFramework.Controls.MetroPanel loginbuttoncontainer;
        private MetroFramework.Controls.MetroButton loginbutton;
        private MetroFramework.Controls.MetroPanel passwordtextboxcontainer;
        private MetroFramework.Controls.MetroTextBox passwordtextbox;
        private MetroFramework.Controls.MetroPanel usernametextboxcontainer;
        private MetroFramework.Controls.MetroTextBox usernametextbox;
    }
}