﻿namespace XMR_Stak_Hashrate_Viewer
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.mainpanel = new System.Windows.Forms.TableLayoutPanel();
            this.sidepanel = new System.Windows.Forms.TableLayoutPanel();
            this.weeklyrevenuecontainer = new MetroFramework.Controls.MetroPanel();
            this.weeklyrevenuelabel = new MetroFramework.Controls.MetroLabel();
            this.monerovaluecontainer = new MetroFramework.Controls.MetroPanel();
            this.monerovaluelabel = new MetroFramework.Controls.MetroLabel();
            this.totalhashratecontainer = new MetroFramework.Controls.MetroPanel();
            this.totalhashratelabel = new MetroFramework.Controls.MetroLabel();
            this.highesthashratecontainer = new MetroFramework.Controls.MetroPanel();
            this.highesthashratelabel = new MetroFramework.Controls.MetroLabel();
            this.logocontainer = new MetroFramework.Controls.MetroPanel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.maintabcontrolcontainer = new MetroFramework.Controls.MetroPanel();
            this.maintabcontrol = new MetroFramework.Controls.MetroTabControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.refreshintervalcontainer = new MetroFramework.Controls.MetroPanel();
            this.refreshintervallabel = new MetroFramework.Controls.MetroLabel();
            this.refreshintervaltrackbar = new MetroFramework.Controls.MetroTrackBar();
            this.attributioncontainer = new MetroFramework.Controls.MetroPanel();
            this.attributionlabel = new MetroFramework.Controls.MetroLabel();
            this.mainpanel.SuspendLayout();
            this.sidepanel.SuspendLayout();
            this.weeklyrevenuecontainer.SuspendLayout();
            this.monerovaluecontainer.SuspendLayout();
            this.totalhashratecontainer.SuspendLayout();
            this.highesthashratecontainer.SuspendLayout();
            this.logocontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.maintabcontrolcontainer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.refreshintervalcontainer.SuspendLayout();
            this.attributioncontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.ColumnCount = 2;
            this.mainpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainpanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.mainpanel.Controls.Add(this.sidepanel, 1, 0);
            this.mainpanel.Controls.Add(this.maintabcontrolcontainer, 0, 0);
            this.mainpanel.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.mainpanel.Controls.Add(this.attributioncontainer, 1, 1);
            this.mainpanel.Location = new System.Drawing.Point(23, 63);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.RowCount = 2;
            this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainpanel.Size = new System.Drawing.Size(972, 633);
            this.mainpanel.TabIndex = 0;
            // 
            // sidepanel
            // 
            this.sidepanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sidepanel.ColumnCount = 1;
            this.sidepanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.sidepanel.Controls.Add(this.weeklyrevenuecontainer, 0, 4);
            this.sidepanel.Controls.Add(this.monerovaluecontainer, 0, 3);
            this.sidepanel.Controls.Add(this.totalhashratecontainer, 0, 2);
            this.sidepanel.Controls.Add(this.highesthashratecontainer, 0, 1);
            this.sidepanel.Controls.Add(this.logocontainer, 0, 0);
            this.sidepanel.Location = new System.Drawing.Point(660, 0);
            this.sidepanel.Margin = new System.Windows.Forms.Padding(0);
            this.sidepanel.Name = "sidepanel";
            this.sidepanel.RowCount = 5;
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.Size = new System.Drawing.Size(312, 569);
            this.sidepanel.TabIndex = 0;
            // 
            // weeklyrevenuecontainer
            // 
            this.weeklyrevenuecontainer.Controls.Add(this.weeklyrevenuelabel);
            this.weeklyrevenuecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklyrevenuecontainer.HorizontalScrollbarBarColor = true;
            this.weeklyrevenuecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.weeklyrevenuecontainer.HorizontalScrollbarSize = 10;
            this.weeklyrevenuecontainer.Location = new System.Drawing.Point(3, 512);
            this.weeklyrevenuecontainer.Name = "weeklyrevenuecontainer";
            this.weeklyrevenuecontainer.Size = new System.Drawing.Size(306, 54);
            this.weeklyrevenuecontainer.TabIndex = 3;
            this.weeklyrevenuecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.weeklyrevenuecontainer.VerticalScrollbarBarColor = true;
            this.weeklyrevenuecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.weeklyrevenuecontainer.VerticalScrollbarSize = 10;
            // 
            // weeklyrevenuelabel
            // 
            this.weeklyrevenuelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklyrevenuelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.weeklyrevenuelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.weeklyrevenuelabel.Location = new System.Drawing.Point(0, 0);
            this.weeklyrevenuelabel.Margin = new System.Windows.Forms.Padding(0);
            this.weeklyrevenuelabel.Name = "weeklyrevenuelabel";
            this.weeklyrevenuelabel.Size = new System.Drawing.Size(306, 54);
            this.weeklyrevenuelabel.TabIndex = 3;
            this.weeklyrevenuelabel.Text = "Estimated Weekly Revenue: $0.00";
            this.weeklyrevenuelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.weeklyrevenuelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // monerovaluecontainer
            // 
            this.monerovaluecontainer.Controls.Add(this.monerovaluelabel);
            this.monerovaluecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monerovaluecontainer.HorizontalScrollbarBarColor = true;
            this.monerovaluecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.monerovaluecontainer.HorizontalScrollbarSize = 10;
            this.monerovaluecontainer.Location = new System.Drawing.Point(3, 456);
            this.monerovaluecontainer.Name = "monerovaluecontainer";
            this.monerovaluecontainer.Size = new System.Drawing.Size(306, 50);
            this.monerovaluecontainer.TabIndex = 2;
            this.monerovaluecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.monerovaluecontainer.VerticalScrollbarBarColor = true;
            this.monerovaluecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.monerovaluecontainer.VerticalScrollbarSize = 10;
            // 
            // monerovaluelabel
            // 
            this.monerovaluelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monerovaluelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.monerovaluelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.monerovaluelabel.Location = new System.Drawing.Point(0, 0);
            this.monerovaluelabel.Name = "monerovaluelabel";
            this.monerovaluelabel.Size = new System.Drawing.Size(306, 50);
            this.monerovaluelabel.TabIndex = 3;
            this.monerovaluelabel.Text = "Current Monero Value: $0.00";
            this.monerovaluelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.monerovaluelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // totalhashratecontainer
            // 
            this.totalhashratecontainer.Controls.Add(this.totalhashratelabel);
            this.totalhashratecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalhashratecontainer.HorizontalScrollbarBarColor = true;
            this.totalhashratecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.totalhashratecontainer.HorizontalScrollbarSize = 10;
            this.totalhashratecontainer.Location = new System.Drawing.Point(3, 400);
            this.totalhashratecontainer.Name = "totalhashratecontainer";
            this.totalhashratecontainer.Size = new System.Drawing.Size(306, 50);
            this.totalhashratecontainer.TabIndex = 1;
            this.totalhashratecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.totalhashratecontainer.VerticalScrollbarBarColor = true;
            this.totalhashratecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.totalhashratecontainer.VerticalScrollbarSize = 10;
            // 
            // totalhashratelabel
            // 
            this.totalhashratelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalhashratelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.totalhashratelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.totalhashratelabel.Location = new System.Drawing.Point(0, 0);
            this.totalhashratelabel.Name = "totalhashratelabel";
            this.totalhashratelabel.Size = new System.Drawing.Size(306, 50);
            this.totalhashratelabel.TabIndex = 3;
            this.totalhashratelabel.Text = "Total Hashrate: 0 H/s";
            this.totalhashratelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.totalhashratelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // highesthashratecontainer
            // 
            this.highesthashratecontainer.Controls.Add(this.highesthashratelabel);
            this.highesthashratecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highesthashratecontainer.HorizontalScrollbarBarColor = true;
            this.highesthashratecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.highesthashratecontainer.HorizontalScrollbarSize = 10;
            this.highesthashratecontainer.Location = new System.Drawing.Point(3, 344);
            this.highesthashratecontainer.Name = "highesthashratecontainer";
            this.highesthashratecontainer.Size = new System.Drawing.Size(306, 50);
            this.highesthashratecontainer.TabIndex = 0;
            this.highesthashratecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.highesthashratecontainer.VerticalScrollbarBarColor = true;
            this.highesthashratecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.highesthashratecontainer.VerticalScrollbarSize = 10;
            // 
            // highesthashratelabel
            // 
            this.highesthashratelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.highesthashratelabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highesthashratelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.highesthashratelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.highesthashratelabel.Location = new System.Drawing.Point(0, 0);
            this.highesthashratelabel.Name = "highesthashratelabel";
            this.highesthashratelabel.Size = new System.Drawing.Size(306, 50);
            this.highesthashratelabel.TabIndex = 2;
            this.highesthashratelabel.Text = "Highest Total Hashrate: 0 H/s";
            this.highesthashratelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.highesthashratelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // logocontainer
            // 
            this.logocontainer.Controls.Add(this.logo);
            this.logocontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logocontainer.HorizontalScrollbarBarColor = true;
            this.logocontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.logocontainer.HorizontalScrollbarSize = 10;
            this.logocontainer.Location = new System.Drawing.Point(0, 0);
            this.logocontainer.Margin = new System.Windows.Forms.Padding(0);
            this.logocontainer.Name = "logocontainer";
            this.logocontainer.Size = new System.Drawing.Size(312, 341);
            this.logocontainer.TabIndex = 4;
            this.logocontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logocontainer.VerticalScrollbarBarColor = true;
            this.logocontainer.VerticalScrollbarHighlightOnWheel = false;
            this.logocontainer.VerticalScrollbarSize = 10;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logo.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.icon;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(312, 341);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            this.logo.WaitOnLoad = true;
            // 
            // maintabcontrolcontainer
            // 
            this.maintabcontrolcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maintabcontrolcontainer.Controls.Add(this.maintabcontrol);
            this.maintabcontrolcontainer.HorizontalScrollbarBarColor = true;
            this.maintabcontrolcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.maintabcontrolcontainer.HorizontalScrollbarSize = 10;
            this.maintabcontrolcontainer.Location = new System.Drawing.Point(0, 0);
            this.maintabcontrolcontainer.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.maintabcontrolcontainer.Name = "maintabcontrolcontainer";
            this.maintabcontrolcontainer.Size = new System.Drawing.Size(655, 569);
            this.maintabcontrolcontainer.TabIndex = 2;
            this.maintabcontrolcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintabcontrolcontainer.VerticalScrollbarBarColor = true;
            this.maintabcontrolcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.maintabcontrolcontainer.VerticalScrollbarSize = 10;
            // 
            // maintabcontrol
            // 
            this.maintabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maintabcontrol.Location = new System.Drawing.Point(0, 0);
            this.maintabcontrol.Margin = new System.Windows.Forms.Padding(0);
            this.maintabcontrol.Name = "maintabcontrol";
            this.maintabcontrol.Size = new System.Drawing.Size(655, 569);
            this.maintabcontrol.TabIndex = 2;
            this.maintabcontrol.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintabcontrol.UseSelectable = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.refreshintervalcontainer, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 572);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(654, 58);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // refreshintervalcontainer
            // 
            this.refreshintervalcontainer.Controls.Add(this.refreshintervallabel);
            this.refreshintervalcontainer.Controls.Add(this.refreshintervaltrackbar);
            this.refreshintervalcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshintervalcontainer.HorizontalScrollbarBarColor = true;
            this.refreshintervalcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.refreshintervalcontainer.HorizontalScrollbarSize = 10;
            this.refreshintervalcontainer.Location = new System.Drawing.Point(3, 3);
            this.refreshintervalcontainer.Name = "refreshintervalcontainer";
            this.refreshintervalcontainer.Size = new System.Drawing.Size(157, 52);
            this.refreshintervalcontainer.TabIndex = 5;
            this.refreshintervalcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.refreshintervalcontainer.VerticalScrollbarBarColor = true;
            this.refreshintervalcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.refreshintervalcontainer.VerticalScrollbarSize = 10;
            // 
            // refreshintervallabel
            // 
            this.refreshintervallabel.AutoSize = true;
            this.refreshintervallabel.Location = new System.Drawing.Point(3, 7);
            this.refreshintervallabel.Name = "refreshintervallabel";
            this.refreshintervallabel.Size = new System.Drawing.Size(133, 19);
            this.refreshintervallabel.TabIndex = 3;
            this.refreshintervallabel.Text = "Refresh Interval: 1.00s";
            this.refreshintervallabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // refreshintervaltrackbar
            // 
            this.refreshintervaltrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshintervaltrackbar.BackColor = System.Drawing.Color.Transparent;
            this.refreshintervaltrackbar.LargeChange = 500;
            this.refreshintervaltrackbar.Location = new System.Drawing.Point(3, 29);
            this.refreshintervaltrackbar.Maximum = 10000;
            this.refreshintervaltrackbar.Minimum = 1000;
            this.refreshintervaltrackbar.MouseWheelBarPartitions = 18;
            this.refreshintervaltrackbar.Name = "refreshintervaltrackbar";
            this.refreshintervaltrackbar.Size = new System.Drawing.Size(151, 23);
            this.refreshintervaltrackbar.SmallChange = 500;
            this.refreshintervaltrackbar.TabIndex = 2;
            this.refreshintervaltrackbar.Text = "metroTrackBar1";
            this.refreshintervaltrackbar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.refreshintervaltrackbar.Value = 1000;
            this.refreshintervaltrackbar.ValueChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // attributioncontainer
            // 
            this.attributioncontainer.Controls.Add(this.attributionlabel);
            this.attributioncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributioncontainer.HorizontalScrollbarBarColor = true;
            this.attributioncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.attributioncontainer.HorizontalScrollbarSize = 10;
            this.attributioncontainer.Location = new System.Drawing.Point(663, 572);
            this.attributioncontainer.Name = "attributioncontainer";
            this.attributioncontainer.Size = new System.Drawing.Size(306, 58);
            this.attributioncontainer.TabIndex = 4;
            this.attributioncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.attributioncontainer.VerticalScrollbarBarColor = true;
            this.attributioncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.attributioncontainer.VerticalScrollbarSize = 10;
            // 
            // attributionlabel
            // 
            this.attributionlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributionlabel.Location = new System.Drawing.Point(0, 0);
            this.attributionlabel.Name = "attributionlabel";
            this.attributionlabel.Size = new System.Drawing.Size(306, 58);
            this.attributionlabel.TabIndex = 2;
            this.attributionlabel.Text = "metroLabel6";
            this.attributionlabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.attributionlabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1018, 716);
            this.Controls.Add(this.mainpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 650);
            this.Name = "MainPage";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form4_FormLoad);
            this.Resize += new System.EventHandler(this.resize);
            this.mainpanel.ResumeLayout(false);
            this.sidepanel.ResumeLayout(false);
            this.weeklyrevenuecontainer.ResumeLayout(false);
            this.monerovaluecontainer.ResumeLayout(false);
            this.totalhashratecontainer.ResumeLayout(false);
            this.highesthashratecontainer.ResumeLayout(false);
            this.logocontainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.maintabcontrolcontainer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.refreshintervalcontainer.ResumeLayout(false);
            this.refreshintervalcontainer.PerformLayout();
            this.attributioncontainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainpanel;
        private System.Windows.Forms.TableLayoutPanel sidepanel;
        private MetroFramework.Controls.MetroPanel weeklyrevenuecontainer;
        private MetroFramework.Controls.MetroPanel monerovaluecontainer;
        private MetroFramework.Controls.MetroPanel totalhashratecontainer;
        private MetroFramework.Controls.MetroPanel highesthashratecontainer;
        private MetroFramework.Controls.MetroLabel weeklyrevenuelabel;
        private MetroFramework.Controls.MetroPanel maintabcontrolcontainer;
        private MetroFramework.Controls.MetroTabControl maintabcontrol;
        private MetroFramework.Controls.MetroLabel monerovaluelabel;
        private MetroFramework.Controls.MetroLabel totalhashratelabel;
        private MetroFramework.Controls.MetroLabel highesthashratelabel;
        private MetroFramework.Controls.MetroPanel logocontainer;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private MetroFramework.Controls.MetroPanel refreshintervalcontainer;
        private MetroFramework.Controls.MetroLabel refreshintervallabel;
        private MetroFramework.Controls.MetroTrackBar refreshintervaltrackbar;
        private MetroFramework.Controls.MetroPanel attributioncontainer;
        private MetroFramework.Controls.MetroLabel attributionlabel;
    }
}