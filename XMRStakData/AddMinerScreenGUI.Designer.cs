namespace XMR_Stak_Hashrate_Viewer
{
    partial class AddMinerScreen
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
            this.addminerbuttoncontainer = new MetroFramework.Controls.MetroPanel();
            this.addminerbutton = new MetroFramework.Controls.MetroButton();
            this.ipaddresstextboxcontainer = new MetroFramework.Controls.MetroPanel();
            this.ipaddresstextbox = new MetroFramework.Controls.MetroTextBox();
            this.controlcontainer.SuspendLayout();
            this.addminerbuttoncontainer.SuspendLayout();
            this.ipaddresstextboxcontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlcontainer
            // 
            this.controlcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlcontainer.ColumnCount = 1;
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlcontainer.Controls.Add(this.addminerbuttoncontainer, 0, 1);
            this.controlcontainer.Controls.Add(this.ipaddresstextboxcontainer, 0, 0);
            this.controlcontainer.Location = new System.Drawing.Point(0, 23);
            this.controlcontainer.Name = "controlcontainer";
            this.controlcontainer.RowCount = 2;
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.controlcontainer.Size = new System.Drawing.Size(245, 85);
            this.controlcontainer.TabIndex = 0;
            // 
            // addminerbuttoncontainer
            // 
            this.addminerbuttoncontainer.Controls.Add(this.addminerbutton);
            this.addminerbuttoncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addminerbuttoncontainer.HorizontalScrollbarBarColor = true;
            this.addminerbuttoncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.addminerbuttoncontainer.HorizontalScrollbarSize = 10;
            this.addminerbuttoncontainer.Location = new System.Drawing.Point(3, 45);
            this.addminerbuttoncontainer.Name = "addminerbuttoncontainer";
            this.addminerbuttoncontainer.Size = new System.Drawing.Size(239, 37);
            this.addminerbuttoncontainer.TabIndex = 4;
            this.addminerbuttoncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addminerbuttoncontainer.VerticalScrollbarBarColor = true;
            this.addminerbuttoncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.addminerbuttoncontainer.VerticalScrollbarSize = 10;
            // 
            // addminerbutton
            // 
            this.addminerbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addminerbutton.Location = new System.Drawing.Point(0, 7);
            this.addminerbutton.Margin = new System.Windows.Forms.Padding(0);
            this.addminerbutton.Name = "addminerbutton";
            this.addminerbutton.Size = new System.Drawing.Size(239, 23);
            this.addminerbutton.TabIndex = 2;
            this.addminerbutton.TabStop = false;
            this.addminerbutton.Text = "Add Miner";
            this.addminerbutton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addminerbutton.UseSelectable = true;
            this.addminerbutton.Click += new System.EventHandler(this.addminerbutton_Click);
            // 
            // ipaddresstextboxcontainer
            // 
            this.ipaddresstextboxcontainer.Controls.Add(this.ipaddresstextbox);
            this.ipaddresstextboxcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ipaddresstextboxcontainer.HorizontalScrollbarBarColor = true;
            this.ipaddresstextboxcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.ipaddresstextboxcontainer.HorizontalScrollbarSize = 10;
            this.ipaddresstextboxcontainer.Location = new System.Drawing.Point(3, 3);
            this.ipaddresstextboxcontainer.Name = "ipaddresstextboxcontainer";
            this.ipaddresstextboxcontainer.Size = new System.Drawing.Size(239, 36);
            this.ipaddresstextboxcontainer.TabIndex = 5;
            this.ipaddresstextboxcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ipaddresstextboxcontainer.VerticalScrollbarBarColor = true;
            this.ipaddresstextboxcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.ipaddresstextboxcontainer.VerticalScrollbarSize = 10;
            // 
            // ipaddresstextbox
            // 
            this.ipaddresstextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.ipaddresstextbox.CustomButton.Image = null;
            this.ipaddresstextbox.CustomButton.Location = new System.Drawing.Point(217, 2);
            this.ipaddresstextbox.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.ipaddresstextbox.CustomButton.Name = "";
            this.ipaddresstextbox.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.ipaddresstextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ipaddresstextbox.CustomButton.TabIndex = 1;
            this.ipaddresstextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ipaddresstextbox.CustomButton.UseSelectable = true;
            this.ipaddresstextbox.CustomButton.Visible = false;
            this.ipaddresstextbox.Lines = new string[0];
            this.ipaddresstextbox.Location = new System.Drawing.Point(2, 14);
            this.ipaddresstextbox.Margin = new System.Windows.Forms.Padding(2);
            this.ipaddresstextbox.MaxLength = 32767;
            this.ipaddresstextbox.Name = "ipaddresstextbox";
            this.ipaddresstextbox.PasswordChar = '\0';
            this.ipaddresstextbox.WaterMark = "IP Address:Port";
            this.ipaddresstextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ipaddresstextbox.SelectedText = "";
            this.ipaddresstextbox.SelectionLength = 0;
            this.ipaddresstextbox.SelectionStart = 0;
            this.ipaddresstextbox.ShortcutsEnabled = true;
            this.ipaddresstextbox.Size = new System.Drawing.Size(235, 20);
            this.ipaddresstextbox.TabIndex = 1;
            this.ipaddresstextbox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ipaddresstextbox.UseSelectable = true;
            this.ipaddresstextbox.WaterMark = "IP Address:Port";
            this.ipaddresstextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ipaddresstextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // AddMinerScreen
            // 
            this.AcceptButton = this.addminerbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 110);
            this.Controls.Add(this.controlcontainer);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddMinerScreen";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TopMost = true;
            this.controlcontainer.ResumeLayout(false);
            this.addminerbuttoncontainer.ResumeLayout(false);
            this.ipaddresstextboxcontainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel controlcontainer;
        private MetroFramework.Controls.MetroPanel addminerbuttoncontainer;
        private MetroFramework.Controls.MetroButton addminerbutton;
        private MetroFramework.Controls.MetroPanel ipaddresstextboxcontainer;
        private MetroFramework.Controls.MetroTextBox ipaddresstextbox;
    }
}