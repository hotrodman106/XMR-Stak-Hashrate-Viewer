using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace XMR_Stak_Hashrate_Viewer
{

    public partial class MainPage : Form
    {
        public int delay;
        private Point _imageLocation = new Point(16, 3);
        private Point _imgHitArea = new Point(16, 0);
        BackgroundThread background;

        Image CloseImage;

        public MainPage()
        {
            InitializeComponent();
            background = new BackgroundThread();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            background.state = false;
            Properties.Settings.Default.IPs.Clear();
            Properties.Settings.Default.Usernames.Clear();
            Properties.Settings.Default.Passwords.Clear();
            Properties.Settings.Default.Height = this.Height;
            Properties.Settings.Default.Width = this.Width;
            Properties.Settings.Default.WindowLocation = this.Location;
            if (this.WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Maximized = true;
            }
            else
            {
                Properties.Settings.Default.Maximized = false;
            }
            foreach (MinerObject miner in Program.minerList)
            {
               Properties.Settings.Default.IPs.Add(miner.name);
               Properties.Settings.Default.Usernames.Add(miner.username);
               Properties.Settings.Default.Passwords.Add(miner.password);
            }
            Properties.Settings.Default.Save();
        }

        private void MainPage_FormLoad(object sender, EventArgs e)
        {
            CloseImage = Properties.Resources.close;
            tabControl1.Padding = new Point(10, 3);
            delay = Properties.Settings.Default.RefreshRate;
            toolStripComboBox1.SelectedIndex = (delay / 1000) - 1;
            this.Height = Properties.Settings.Default.Height;
            this.Width = Properties.Settings.Default.Width;
            this.Location = Properties.Settings.Default.WindowLocation;
            if (Properties.Settings.Default.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            int index = 0;
            foreach (string u in Properties.Settings.Default.IPs)
            {
                try
                {
                    Uri uri = new Uri("http://" + u);
                    MinerObject miner = new MinerObject(uri, Properties.Settings.Default.Usernames[index], Properties.Settings.Default.Passwords[index]);
                    if (miner.isInitialized)
                    {
                      Program.minerList.Add(miner);
                    }
                    index++;
                }
                catch (Exception ex)
                {
                    if (ex is ThreadAbortException != true)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {

            try
            {
                Image img = new Bitmap(CloseImage);
                Rectangle r = e.Bounds;
                r = tabControl1.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = Font;
                string title = tabControl1.TabPages[e.Index].Text;

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y));
                e.Graphics.DrawImage(img, new Point(r.X + (tabControl1.GetTabRect(e.Index).Width - _imageLocation.X), _imageLocation.Y));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
            }
        }


        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TabControl tc = (TabControl)sender;
                Point p = e.Location;
                int _tabWidth = 0;
                _tabWidth = tabControl1.GetTabRect(tc.SelectedIndex).Width - (_imgHitArea.X);
                Rectangle r = tabControl1.GetTabRect(tc.SelectedIndex);
                r.Offset(_tabWidth, _imgHitArea.Y);
                r.Width = 16;
                r.Height = 16;
                if (r.Contains(p))
                {
                    int ind = tabControl1.SelectedIndex;
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                    Program.minerList.RemoveAt(ind);
                    Properties.Settings.Default.IPs.RemoveAt(ind);
                    if (Program.minerList.Count == 0)
                    {
                        highestHashrate.Text = "Highest Total Hashrate: 0 H/s";
                        averageHashrate.Text = "Total Hashrate: 0 H/s";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException != true)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void toolStripComboBox1_SelectionChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.Text)
            {
                case "1s":
                    delay = 1000;
                    break;
                case "2s":
                    delay = 2000;
                    break;
                case "3s":
                    delay = 3000;
                    break;
                case "4s":
                    delay = 4000;
                    break;
                case "5s":
                    delay = 5000;
                    break;
                case "6s":
                    delay = 6000;
                    break;
                case "7s":
                    delay = 7000;
                    break;
                case "8s":
                    delay = 8000;
                    break;
                case "9s":
                    delay = 9000;
                    break;
                case "10s":
                    delay = 10000;
                    break;
            }
            Properties.Settings.Default.RefreshRate = delay;
            Properties.Settings.Default.Save();
        }
    }
}
