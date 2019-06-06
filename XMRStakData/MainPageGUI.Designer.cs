namespace XMR_Stak_Hashrate_Viewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.mainpanel = new System.Windows.Forms.TableLayoutPanel();
            this.attributionlabelcontainer = new MetroFramework.Controls.MetroPanel();
            this.attributionlabel = new MetroFramework.Controls.MetroLabel();
            this.sidepanel = new System.Windows.Forms.TableLayoutPanel();
            this.weeklyrevenuecontainer = new MetroFramework.Controls.MetroPanel();
            this.weeklyrevenueimage = new System.Windows.Forms.PictureBox();
            this.weeklyrevenuelabel = new MetroFramework.Controls.MetroLabel();
            this.monerovaluecontainer = new MetroFramework.Controls.MetroPanel();
            this.monerovalueimage = new System.Windows.Forms.PictureBox();
            this.monerovaluelabel = new MetroFramework.Controls.MetroLabel();
            this.totalhashratecontainer = new MetroFramework.Controls.MetroPanel();
            this.totalhashrateimage = new System.Windows.Forms.PictureBox();
            this.totalhashratelabel = new MetroFramework.Controls.MetroLabel();
            this.highesthashratecontainer = new MetroFramework.Controls.MetroPanel();
            this.highesthashrateimage = new System.Windows.Forms.PictureBox();
            this.highesthashratelabel = new MetroFramework.Controls.MetroLabel();
            this.logocontainer = new MetroFramework.Controls.MetroPanel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.maintabcontrolcontainer = new MetroFramework.Controls.MetroPanel();
            this.maintabcontrol = new MetroFramework.Controls.MetroTabControl();
            this.controlcontainer = new System.Windows.Forms.TableLayoutPanel();
            this.removeminerbuttoncontainer = new MetroFramework.Controls.MetroPanel();
            this.removeminerbutton = new MetroFramework.Controls.MetroButton();
            this.refreshintervalcontainer = new System.Windows.Forms.TableLayoutPanel();
            this.refreshintervaltrackbar = new MetroFramework.Controls.MetroTrackBar();
            this.refreshintervallabel = new MetroFramework.Controls.MetroLabel();
            this.addminerbuttoncontainer = new MetroFramework.Controls.MetroPanel();
            this.addminerbutton = new MetroFramework.Controls.MetroButton();
            this.settingsbuttoncontainer = new MetroFramework.Controls.MetroPanel();
            this.settingsbutton = new MetroFramework.Controls.MetroButton();
            this.maintooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tooltrayicon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tooltrayiconrightclick = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainpanel.SuspendLayout();
            this.attributionlabelcontainer.SuspendLayout();
            this.sidepanel.SuspendLayout();
            this.weeklyrevenuecontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyrevenueimage)).BeginInit();
            this.monerovaluecontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monerovalueimage)).BeginInit();
            this.totalhashratecontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalhashrateimage)).BeginInit();
            this.highesthashratecontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highesthashrateimage)).BeginInit();
            this.logocontainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.maintabcontrolcontainer.SuspendLayout();
            this.controlcontainer.SuspendLayout();
            this.removeminerbuttoncontainer.SuspendLayout();
            this.refreshintervalcontainer.SuspendLayout();
            this.addminerbuttoncontainer.SuspendLayout();
            this.settingsbuttoncontainer.SuspendLayout();
            this.tooltrayiconrightclick.SuspendLayout();
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
            this.mainpanel.Controls.Add(this.attributionlabelcontainer, 1, 1);
            this.mainpanel.Controls.Add(this.sidepanel, 1, 0);
            this.mainpanel.Controls.Add(this.maintabcontrolcontainer, 0, 0);
            this.mainpanel.Controls.Add(this.controlcontainer, 0, 1);
            this.mainpanel.Location = new System.Drawing.Point(23, 23);
            this.mainpanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.RowCount = 2;
            this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.mainpanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainpanel.Size = new System.Drawing.Size(972, 673);
            this.mainpanel.TabIndex = 0;
            // 
            // attributionlabelcontainer
            // 
            this.attributionlabelcontainer.Controls.Add(this.attributionlabel);
            this.attributionlabelcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributionlabelcontainer.HorizontalScrollbarBarColor = true;
            this.attributionlabelcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.attributionlabelcontainer.HorizontalScrollbarSize = 10;
            this.attributionlabelcontainer.Location = new System.Drawing.Point(663, 608);
            this.attributionlabelcontainer.Name = "attributionlabelcontainer";
            this.attributionlabelcontainer.Size = new System.Drawing.Size(306, 62);
            this.attributionlabelcontainer.TabIndex = 1004;
            this.attributionlabelcontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.attributionlabelcontainer.VerticalScrollbarBarColor = true;
            this.attributionlabelcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.attributionlabelcontainer.VerticalScrollbarSize = 10;
            // 
            // attributionlabel
            // 
            this.attributionlabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attributionlabel.Location = new System.Drawing.Point(0, 0);
            this.attributionlabel.Name = "attributionlabel";
            this.attributionlabel.Size = new System.Drawing.Size(306, 62);
            this.attributionlabel.TabIndex = 1001;
            this.attributionlabel.Text = "XMR-Stak Hashrate Viewer v0.0.0.0";
            this.attributionlabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.attributionlabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.attributionlabel, "Program by: Paul Ferreira, 2019\r\n");
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
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.sidepanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.sidepanel.Size = new System.Drawing.Size(312, 605);
            this.sidepanel.TabIndex = 0;
            // 
            // weeklyrevenuecontainer
            // 
            this.weeklyrevenuecontainer.Controls.Add(this.weeklyrevenueimage);
            this.weeklyrevenuecontainer.Controls.Add(this.weeklyrevenuelabel);
            this.weeklyrevenuecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklyrevenuecontainer.HorizontalScrollbarBarColor = true;
            this.weeklyrevenuecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.weeklyrevenuecontainer.HorizontalScrollbarSize = 10;
            this.weeklyrevenuecontainer.Location = new System.Drawing.Point(3, 485);
            this.weeklyrevenuecontainer.Name = "weeklyrevenuecontainer";
            this.weeklyrevenuecontainer.Size = new System.Drawing.Size(306, 117);
            this.weeklyrevenuecontainer.TabIndex = 3;
            this.weeklyrevenuecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.weeklyrevenuecontainer.VerticalScrollbarBarColor = true;
            this.weeklyrevenuecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.weeklyrevenuecontainer.VerticalScrollbarSize = 10;
            // 
            // weeklyrevenueimage
            // 
            this.weeklyrevenueimage.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.weeklyrevenue;
            this.weeklyrevenueimage.Location = new System.Drawing.Point(93, -3);
            this.weeklyrevenueimage.Name = "weeklyrevenueimage";
            this.weeklyrevenueimage.Size = new System.Drawing.Size(54, 54);
            this.weeklyrevenueimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.weeklyrevenueimage.TabIndex = 1003;
            this.weeklyrevenueimage.TabStop = false;
            this.maintooltip.SetToolTip(this.weeklyrevenueimage, "Estimated Weekly Revenue");
            this.weeklyrevenueimage.WaitOnLoad = true;
            // 
            // weeklyrevenuelabel
            // 
            this.weeklyrevenuelabel.AutoSize = true;
            this.weeklyrevenuelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.weeklyrevenuelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.weeklyrevenuelabel.Location = new System.Drawing.Point(153, 16);
            this.weeklyrevenuelabel.Margin = new System.Windows.Forms.Padding(0);
            this.weeklyrevenuelabel.Name = "weeklyrevenuelabel";
            this.weeklyrevenuelabel.Size = new System.Drawing.Size(56, 25);
            this.weeklyrevenuelabel.TabIndex = 999;
            this.weeklyrevenuelabel.Text = "$0.00";
            this.weeklyrevenuelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.weeklyrevenuelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.weeklyrevenuelabel, "Estimated Weekly Revenue");
            // 
            // monerovaluecontainer
            // 
            this.monerovaluecontainer.Controls.Add(this.monerovalueimage);
            this.monerovaluecontainer.Controls.Add(this.monerovaluelabel);
            this.monerovaluecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monerovaluecontainer.HorizontalScrollbarBarColor = true;
            this.monerovaluecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.monerovaluecontainer.HorizontalScrollbarSize = 10;
            this.monerovaluecontainer.Location = new System.Drawing.Point(3, 425);
            this.monerovaluecontainer.Name = "monerovaluecontainer";
            this.monerovaluecontainer.Size = new System.Drawing.Size(306, 54);
            this.monerovaluecontainer.TabIndex = 2;
            this.monerovaluecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.monerovaluecontainer.VerticalScrollbarBarColor = true;
            this.monerovaluecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.monerovaluecontainer.VerticalScrollbarSize = 10;
            // 
            // monerovalueimage
            // 
            this.monerovalueimage.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.monerovalue;
            this.monerovalueimage.Location = new System.Drawing.Point(93, 0);
            this.monerovalueimage.Name = "monerovalueimage";
            this.monerovalueimage.Size = new System.Drawing.Size(54, 50);
            this.monerovalueimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.monerovalueimage.TabIndex = 1002;
            this.monerovalueimage.TabStop = false;
            this.maintooltip.SetToolTip(this.monerovalueimage, "Monero Value");
            this.monerovalueimage.WaitOnLoad = true;
            // 
            // monerovaluelabel
            // 
            this.monerovaluelabel.AutoSize = true;
            this.monerovaluelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.monerovaluelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.monerovaluelabel.Location = new System.Drawing.Point(153, 13);
            this.monerovaluelabel.Name = "monerovaluelabel";
            this.monerovaluelabel.Size = new System.Drawing.Size(56, 25);
            this.monerovaluelabel.TabIndex = 999;
            this.monerovaluelabel.Text = "$0.00";
            this.monerovaluelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.monerovaluelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.monerovaluelabel, "Monero Value");
            // 
            // totalhashratecontainer
            // 
            this.totalhashratecontainer.Controls.Add(this.totalhashrateimage);
            this.totalhashratecontainer.Controls.Add(this.totalhashratelabel);
            this.totalhashratecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalhashratecontainer.HorizontalScrollbarBarColor = true;
            this.totalhashratecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.totalhashratecontainer.HorizontalScrollbarSize = 10;
            this.totalhashratecontainer.Location = new System.Drawing.Point(3, 365);
            this.totalhashratecontainer.Name = "totalhashratecontainer";
            this.totalhashratecontainer.Size = new System.Drawing.Size(306, 54);
            this.totalhashratecontainer.TabIndex = 1;
            this.totalhashratecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.totalhashratecontainer.VerticalScrollbarBarColor = true;
            this.totalhashratecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.totalhashratecontainer.VerticalScrollbarSize = 10;
            // 
            // totalhashrateimage
            // 
            this.totalhashrateimage.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.totalhashrate;
            this.totalhashrateimage.Location = new System.Drawing.Point(93, 0);
            this.totalhashrateimage.Name = "totalhashrateimage";
            this.totalhashrateimage.Size = new System.Drawing.Size(54, 50);
            this.totalhashrateimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.totalhashrateimage.TabIndex = 1001;
            this.totalhashrateimage.TabStop = false;
            this.maintooltip.SetToolTip(this.totalhashrateimage, "Total Hashrate");
            this.totalhashrateimage.WaitOnLoad = true;
            // 
            // totalhashratelabel
            // 
            this.totalhashratelabel.AutoSize = true;
            this.totalhashratelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.totalhashratelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.totalhashratelabel.Location = new System.Drawing.Point(153, 11);
            this.totalhashratelabel.Name = "totalhashratelabel";
            this.totalhashratelabel.Size = new System.Drawing.Size(55, 25);
            this.totalhashratelabel.TabIndex = 999;
            this.totalhashratelabel.Text = "0 H/s";
            this.totalhashratelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.totalhashratelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.totalhashratelabel, "Total Hashrate");
            // 
            // highesthashratecontainer
            // 
            this.highesthashratecontainer.Controls.Add(this.highesthashrateimage);
            this.highesthashratecontainer.Controls.Add(this.highesthashratelabel);
            this.highesthashratecontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.highesthashratecontainer.HorizontalScrollbarBarColor = true;
            this.highesthashratecontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.highesthashratecontainer.HorizontalScrollbarSize = 10;
            this.highesthashratecontainer.Location = new System.Drawing.Point(3, 305);
            this.highesthashratecontainer.Name = "highesthashratecontainer";
            this.highesthashratecontainer.Size = new System.Drawing.Size(306, 54);
            this.highesthashratecontainer.TabIndex = 0;
            this.highesthashratecontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.highesthashratecontainer.VerticalScrollbarBarColor = true;
            this.highesthashratecontainer.VerticalScrollbarHighlightOnWheel = false;
            this.highesthashratecontainer.VerticalScrollbarSize = 10;
            // 
            // highesthashrateimage
            // 
            this.highesthashrateimage.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.highesttotalhashrate;
            this.highesthashrateimage.Location = new System.Drawing.Point(93, 0);
            this.highesthashrateimage.Name = "highesthashrateimage";
            this.highesthashrateimage.Size = new System.Drawing.Size(54, 50);
            this.highesthashrateimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.highesthashrateimage.TabIndex = 1000;
            this.highesthashrateimage.TabStop = false;
            this.maintooltip.SetToolTip(this.highesthashrateimage, "Highest Hashrate");
            this.highesthashrateimage.WaitOnLoad = true;
            // 
            // highesthashratelabel
            // 
            this.highesthashratelabel.AutoSize = true;
            this.highesthashratelabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.highesthashratelabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.highesthashratelabel.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.highesthashratelabel.Location = new System.Drawing.Point(153, 12);
            this.highesthashratelabel.Name = "highesthashratelabel";
            this.highesthashratelabel.Size = new System.Drawing.Size(55, 25);
            this.highesthashratelabel.TabIndex = 999;
            this.highesthashratelabel.Text = "0 H/s";
            this.highesthashratelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.highesthashratelabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.highesthashratelabel, "Highest Hashrate");
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
            this.logocontainer.Size = new System.Drawing.Size(312, 302);
            this.logocontainer.TabIndex = 4;
            this.logocontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.logocontainer.VerticalScrollbarBarColor = true;
            this.logocontainer.VerticalScrollbarHighlightOnWheel = false;
            this.logocontainer.VerticalScrollbarSize = 10;
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logo.Image = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.icon;
            this.logo.Location = new System.Drawing.Point(36, 34);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(242, 238);
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
            this.maintabcontrolcontainer.Size = new System.Drawing.Size(655, 605);
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
            this.maintabcontrol.ShowToolTips = true;
            this.maintabcontrol.Size = new System.Drawing.Size(655, 605);
            this.maintabcontrol.TabIndex = 999;
            this.maintabcontrol.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintabcontrol.UseSelectable = true;
            // 
            // controlcontainer
            // 
            this.controlcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlcontainer.ColumnCount = 8;
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.controlcontainer.Controls.Add(this.removeminerbuttoncontainer, 4, 0);
            this.controlcontainer.Controls.Add(this.refreshintervalcontainer, 0, 0);
            this.controlcontainer.Controls.Add(this.addminerbuttoncontainer, 2, 0);
            this.controlcontainer.Controls.Add(this.settingsbuttoncontainer, 6, 0);
            this.controlcontainer.Location = new System.Drawing.Point(3, 608);
            this.controlcontainer.Name = "controlcontainer";
            this.controlcontainer.RowCount = 1;
            this.controlcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlcontainer.Size = new System.Drawing.Size(654, 62);
            this.controlcontainer.TabIndex = 3;
            // 
            // removeminerbuttoncontainer
            // 
            this.removeminerbuttoncontainer.Controls.Add(this.removeminerbutton);
            this.removeminerbuttoncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeminerbuttoncontainer.HorizontalScrollbarBarColor = true;
            this.removeminerbuttoncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.removeminerbuttoncontainer.HorizontalScrollbarSize = 10;
            this.removeminerbuttoncontainer.Location = new System.Drawing.Point(353, 3);
            this.removeminerbuttoncontainer.MaximumSize = new System.Drawing.Size(100, 70);
            this.removeminerbuttoncontainer.MinimumSize = new System.Drawing.Size(50, 30);
            this.removeminerbuttoncontainer.Name = "removeminerbuttoncontainer";
            this.removeminerbuttoncontainer.Size = new System.Drawing.Size(100, 56);
            this.removeminerbuttoncontainer.TabIndex = 4;
            this.removeminerbuttoncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.removeminerbuttoncontainer.VerticalScrollbarBarColor = true;
            this.removeminerbuttoncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.removeminerbuttoncontainer.VerticalScrollbarSize = 10;
            // 
            // removeminerbutton
            // 
            this.removeminerbutton.BackgroundImage = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.removeminer;
            this.removeminerbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.removeminerbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeminerbutton.Location = new System.Drawing.Point(0, 0);
            this.removeminerbutton.Name = "removeminerbutton";
            this.removeminerbutton.Size = new System.Drawing.Size(100, 56);
            this.removeminerbutton.TabIndex = 3;
            this.removeminerbutton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.removeminerbutton, "Remove Miner");
            this.removeminerbutton.UseSelectable = true;
            this.removeminerbutton.Click += new System.EventHandler(this.onRemoveMinerClick);
            // 
            // refreshintervalcontainer
            // 
            this.refreshintervalcontainer.ColumnCount = 1;
            this.refreshintervalcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.refreshintervalcontainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.refreshintervalcontainer.Controls.Add(this.refreshintervaltrackbar, 0, 1);
            this.refreshintervalcontainer.Controls.Add(this.refreshintervallabel, 0, 0);
            this.refreshintervalcontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.refreshintervalcontainer.Location = new System.Drawing.Point(2, 2);
            this.refreshintervalcontainer.Margin = new System.Windows.Forms.Padding(2);
            this.refreshintervalcontainer.MaximumSize = new System.Drawing.Size(200, 70);
            this.refreshintervalcontainer.MinimumSize = new System.Drawing.Size(200, 50);
            this.refreshintervalcontainer.Name = "refreshintervalcontainer";
            this.refreshintervalcontainer.RowCount = 2;
            this.refreshintervalcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.refreshintervalcontainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.refreshintervalcontainer.Size = new System.Drawing.Size(200, 58);
            this.refreshintervalcontainer.TabIndex = 0;
            // 
            // refreshintervaltrackbar
            // 
            this.refreshintervaltrackbar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshintervaltrackbar.BackColor = System.Drawing.Color.Transparent;
            this.refreshintervaltrackbar.LargeChange = 500;
            this.refreshintervaltrackbar.Location = new System.Drawing.Point(3, 32);
            this.refreshintervaltrackbar.Maximum = 10000;
            this.refreshintervaltrackbar.Minimum = 2000;
            this.refreshintervaltrackbar.MouseWheelBarPartitions = 16;
            this.refreshintervaltrackbar.Name = "refreshintervaltrackbar";
            this.refreshintervaltrackbar.Size = new System.Drawing.Size(197, 23);
            this.refreshintervaltrackbar.SmallChange = 500;
            this.refreshintervaltrackbar.TabIndex = 1;
            this.refreshintervaltrackbar.Text = "metroTrackBar1";
            this.refreshintervaltrackbar.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.refreshintervaltrackbar, "Refresh Interval");
            this.refreshintervaltrackbar.Value = 2000;
            this.refreshintervaltrackbar.ValueChanged += new System.EventHandler(this.OnTrackbarValueChanged);
            // 
            // refreshintervallabel
            // 
            this.refreshintervallabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshintervallabel.AutoSize = true;
            this.refreshintervallabel.Location = new System.Drawing.Point(3, 0);
            this.refreshintervallabel.Name = "refreshintervallabel";
            this.refreshintervallabel.Size = new System.Drawing.Size(197, 29);
            this.refreshintervallabel.TabIndex = 5;
            this.refreshintervallabel.Text = "Refresh Interval: 2.00s";
            this.refreshintervallabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.refreshintervallabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.refreshintervallabel, "Refresh Interval");
            // 
            // addminerbuttoncontainer
            // 
            this.addminerbuttoncontainer.Controls.Add(this.addminerbutton);
            this.addminerbuttoncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addminerbuttoncontainer.HorizontalScrollbarBarColor = true;
            this.addminerbuttoncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.addminerbuttoncontainer.HorizontalScrollbarSize = 10;
            this.addminerbuttoncontainer.Location = new System.Drawing.Point(242, 3);
            this.addminerbuttoncontainer.MaximumSize = new System.Drawing.Size(100, 70);
            this.addminerbuttoncontainer.MinimumSize = new System.Drawing.Size(50, 30);
            this.addminerbuttoncontainer.Name = "addminerbuttoncontainer";
            this.addminerbuttoncontainer.Size = new System.Drawing.Size(100, 56);
            this.addminerbuttoncontainer.TabIndex = 1;
            this.addminerbuttoncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addminerbuttoncontainer.VerticalScrollbarBarColor = true;
            this.addminerbuttoncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.addminerbuttoncontainer.VerticalScrollbarSize = 10;
            // 
            // addminerbutton
            // 
            this.addminerbutton.BackgroundImage = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.addminer;
            this.addminerbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addminerbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addminerbutton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addminerbutton.Location = new System.Drawing.Point(0, 0);
            this.addminerbutton.Name = "addminerbutton";
            this.addminerbutton.Size = new System.Drawing.Size(100, 56);
            this.addminerbutton.TabIndex = 2;
            this.addminerbutton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.addminerbutton, "Add Miner");
            this.addminerbutton.UseSelectable = true;
            this.addminerbutton.Click += new System.EventHandler(this.onAddMinerClick);
            // 
            // settingsbuttoncontainer
            // 
            this.settingsbuttoncontainer.Controls.Add(this.settingsbutton);
            this.settingsbuttoncontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsbuttoncontainer.HorizontalScrollbarBarColor = true;
            this.settingsbuttoncontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.settingsbuttoncontainer.HorizontalScrollbarSize = 10;
            this.settingsbuttoncontainer.Location = new System.Drawing.Point(464, 3);
            this.settingsbuttoncontainer.MaximumSize = new System.Drawing.Size(100, 70);
            this.settingsbuttoncontainer.MinimumSize = new System.Drawing.Size(50, 30);
            this.settingsbuttoncontainer.Name = "settingsbuttoncontainer";
            this.settingsbuttoncontainer.Size = new System.Drawing.Size(100, 56);
            this.settingsbuttoncontainer.TabIndex = 5;
            this.settingsbuttoncontainer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsbuttoncontainer.VerticalScrollbarBarColor = true;
            this.settingsbuttoncontainer.VerticalScrollbarHighlightOnWheel = false;
            this.settingsbuttoncontainer.VerticalScrollbarSize = 10;
            // 
            // settingsbutton
            // 
            this.settingsbutton.BackgroundImage = global::XMR_Stak_Hashrate_Viewer.Properties.Resources.settings;
            this.settingsbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.settingsbutton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsbutton.Location = new System.Drawing.Point(0, 0);
            this.settingsbutton.Name = "settingsbutton";
            this.settingsbutton.Size = new System.Drawing.Size(100, 56);
            this.settingsbutton.TabIndex = 3;
            this.settingsbutton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.maintooltip.SetToolTip(this.settingsbutton, "Settings");
            this.settingsbutton.UseSelectable = true;
            this.settingsbutton.Click += new System.EventHandler(this.settingsbutton_Click);
            // 
            // maintooltip
            // 
            this.maintooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.maintooltip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(149)))), ((int)(((byte)(146)))));
            // 
            // tooltrayicon
            // 
            this.tooltrayicon.BalloonTipText = "Hey! I\'m still here! Click this balloon or double click my icon in the taskbar to" +
    " get back into the program.\r\n";
            this.tooltrayicon.BalloonTipTitle = "XMR-Stak Hashrate Viewer";
            this.tooltrayicon.ContextMenuStrip = this.tooltrayiconrightclick;
            this.tooltrayicon.Icon = ((System.Drawing.Icon)(resources.GetObject("tooltrayicon.Icon")));
            this.tooltrayicon.BalloonTipClicked += new System.EventHandler(this.taskbaricon_BalloonTipClicked);
            this.tooltrayicon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.taskbaricon_MouseDoubleClick);
            // 
            // tooltrayiconrightclick
            // 
            this.tooltrayiconrightclick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.tooltrayiconrightclick.Name = "tooltrayiconrightclick";
            this.tooltrayiconrightclick.Size = new System.Drawing.Size(114, 48);
            this.tooltrayiconrightclick.UseCustomBackColor = true;
            this.tooltrayiconrightclick.UseCustomForeColor = true;
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.restoremenuitem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitmenuitem_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1018, 716);
            this.Controls.Add(this.mainpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(950, 700);
            this.Name = "MainPage";
            this.Text = "XMR-Stak Hashrate Viewer";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.Load += new System.EventHandler(this.MainPage_FormLoad);
            this.Resize += new System.EventHandler(this.onResize);
            this.mainpanel.ResumeLayout(false);
            this.attributionlabelcontainer.ResumeLayout(false);
            this.sidepanel.ResumeLayout(false);
            this.weeklyrevenuecontainer.ResumeLayout(false);
            this.weeklyrevenuecontainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weeklyrevenueimage)).EndInit();
            this.monerovaluecontainer.ResumeLayout(false);
            this.monerovaluecontainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monerovalueimage)).EndInit();
            this.totalhashratecontainer.ResumeLayout(false);
            this.totalhashratecontainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.totalhashrateimage)).EndInit();
            this.highesthashratecontainer.ResumeLayout(false);
            this.highesthashratecontainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.highesthashrateimage)).EndInit();
            this.logocontainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.maintabcontrolcontainer.ResumeLayout(false);
            this.controlcontainer.ResumeLayout(false);
            this.removeminerbuttoncontainer.ResumeLayout(false);
            this.refreshintervalcontainer.ResumeLayout(false);
            this.refreshintervalcontainer.PerformLayout();
            this.addminerbuttoncontainer.ResumeLayout(false);
            this.settingsbuttoncontainer.ResumeLayout(false);
            this.tooltrayiconrightclick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainpanel;
        private System.Windows.Forms.TableLayoutPanel sidepanel;
        private MetroFramework.Controls.MetroPanel weeklyrevenuecontainer;
        private MetroFramework.Controls.MetroPanel monerovaluecontainer;
        private MetroFramework.Controls.MetroPanel totalhashratecontainer;
        private MetroFramework.Controls.MetroPanel highesthashratecontainer;
        private MetroFramework.Controls.MetroPanel logocontainer;
        private System.Windows.Forms.PictureBox logo;
        public MetroFramework.Controls.MetroLabel weeklyrevenuelabel;
        public MetroFramework.Controls.MetroLabel monerovaluelabel;
        public MetroFramework.Controls.MetroLabel totalhashratelabel;
        public MetroFramework.Controls.MetroLabel highesthashratelabel;
        private System.Windows.Forms.PictureBox highesthashrateimage;
        private System.Windows.Forms.PictureBox weeklyrevenueimage;
        private System.Windows.Forms.PictureBox monerovalueimage;
        private System.Windows.Forms.PictureBox totalhashrateimage;
        public System.Windows.Forms.ToolTip maintooltip;
        private System.Windows.Forms.TableLayoutPanel controlcontainer;
        private MetroFramework.Controls.MetroPanel removeminerbuttoncontainer;
        public MetroFramework.Controls.MetroButton removeminerbutton;
        private System.Windows.Forms.TableLayoutPanel refreshintervalcontainer;
        private MetroFramework.Controls.MetroTrackBar refreshintervaltrackbar;
        private MetroFramework.Controls.MetroLabel refreshintervallabel;
        private MetroFramework.Controls.MetroPanel addminerbuttoncontainer;
        private MetroFramework.Controls.MetroButton addminerbutton;
        private MetroFramework.Controls.MetroPanel settingsbuttoncontainer;
        public MetroFramework.Controls.MetroButton settingsbutton;
        private MetroFramework.Controls.MetroPanel attributionlabelcontainer;
        private MetroFramework.Controls.MetroLabel attributionlabel;
        public System.Windows.Forms.NotifyIcon tooltrayicon;
        public MetroFramework.Controls.MetroContextMenu tooltrayiconrightclick;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private MetroFramework.Controls.MetroPanel maintabcontrolcontainer;
        public MetroFramework.Controls.MetroTabControl maintabcontrol;
    }
}