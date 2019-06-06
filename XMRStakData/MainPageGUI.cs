﻿using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class MainPage : MetroForm
    {

        public ValueUpdater background;
        public int delay;
        private bool closeonexit;
        private bool hasseenballon;

        public Color accentcolor = Color.FromArgb(45, 137, 239);
        public Color textcolor = Color.FromArgb(149, 149, 146);
        public Color backcolor = Color.FromArgb(17, 17, 17);

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_FormLoad(object sender, EventArgs e)
        {
            attributionlabel.Text = Program.assembly.GetName().Name + " v" +Program.assembly.GetName().Version;

            tooltrayiconrightclick.BackColor = backcolor;
            tooltrayiconrightclick.ForeColor = textcolor;
            tooltrayiconrightclick.ShowImageMargin = false;

            delay = Properties.Settings.Default.RefreshRate;

            Height = Properties.Settings.Default.Height;
            Width = Properties.Settings.Default.Width;
            Location = Properties.Settings.Default.WindowLocation;

            closeonexit = Properties.Settings.Default.CloseonExit;

            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            refreshintervaltrackbar.Value = delay;
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(delay, 1000).ToString("0.00") + "s";

            if (!Properties.Settings.Default.ShowSidebar)
            {
                sidepanel.Visible = false;
                attributionlabelcontainer.Visible = false;
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
                        //miner.createTabPage();
                        //Program.minerList.Add(miner);
                        //miner.startLoop();
                    }
                    index++;
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this,ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }

            if (maintabcontrol.Controls.Count != 0)
            {
                removeminerbutton.Visible = true;
            }
            else
            {
                removeminerbutton.Visible = false;
            }

            //background = new ValueUpdater();
        }

        private void onAddMinerClick(object sender, EventArgs e)

        {
            new AddMinerScreen().ShowDialog();

            if (maintabcontrol.Controls.Count != 0)
            {
                removeminerbutton.Visible = true;
            }
            
        }

        private void onRemoveMinerClick(object sender, EventArgs e)

        {
            int selectedindex = maintabcontrol.SelectedIndex;

            maintabcontrol.TabPages.Remove(maintabcontrol.SelectedTab);
            Program.minerList[selectedindex].minerThread.Interrupt();
            Program.minerList.RemoveAt(selectedindex);
            Program.totals.RemoveAt(selectedindex);
            Program.highestValues.RemoveAt(selectedindex);
            background.thread.Interrupt();

            if(selectedindex != 0)
            {
                maintabcontrol.SelectedIndex = selectedindex - 1;
            }

            if (maintabcontrol.Controls.Count == 0)
            {
                removeminerbutton.Visible = false;
            }
            
        }

        private void OnTrackbarValueChanged(object sender, EventArgs e)
        {
            delay = refreshintervaltrackbar.Value;
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(refreshintervaltrackbar.Value, 1000).ToString("0.00") + "s";
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeonexit)
            {
                background.state = false;
                background.thread.Interrupt();
                Properties.Settings.Default.IPs.Clear();
                Properties.Settings.Default.Usernames.Clear();
                Properties.Settings.Default.Passwords.Clear();
                Properties.Settings.Default.Height = Height;
                Properties.Settings.Default.Width = Width;
                Properties.Settings.Default.WindowLocation = Location;
                Properties.Settings.Default.RefreshRate = delay;

                if (WindowState == FormWindowState.Maximized)
                {
                    Properties.Settings.Default.Maximized = true;
                }
                else
                {
                    Properties.Settings.Default.Maximized = false;
                }
                foreach (MinerObject miner in Program.minerList)
                {
                    Properties.Settings.Default.IPs.Add(miner.ip);
                    Properties.Settings.Default.Usernames.Add(miner.username);
                    Properties.Settings.Default.Passwords.Add(miner.password);
                    miner.minerThread.Interrupt();
                }
                Properties.Settings.Default.Save();
            }
            else
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    tooltrayicon.Visible = true;
                    if (!hasseenballon)
                    {
                        tooltrayicon.ShowBalloonTip(1000);
                        hasseenballon = true;
                    }
                    
                    e.Cancel = true;
                    Hide();
                }
            }
        }

        private void settingsbutton_Click(object sender, EventArgs e)
        {
            new SettingsScreen().ShowDialog();
        }

        private void taskbaricon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            tooltrayicon.Visible = false;
        }

        private void taskbaricon_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            tooltrayicon.Visible = false;
        }

        private void restoremenuitem_Click(object sender, EventArgs e)
        {
            Show();
            tooltrayicon.Visible = false;
        }

        private void exitmenuitem_Click(object sender, EventArgs e)
        {
            closeonexit = true;
            Close();
        }

        private void onResize(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(maintabcontrol.TabPages[0].Controls[0].Controls[0].Size);
            }
            catch (Exception)
            {}
            
        }
    }


}
