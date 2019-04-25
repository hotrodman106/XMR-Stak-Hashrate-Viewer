using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class MainPage : MetroForm
    {

        private MetroContextMenu rightclickmenu;
        private ToolStripMenuItem addmineritem;
        private ToolStripMenuItem removemineritem;
        public static ValueUpdater background;
        public int delay;

        public Color accentcolor = Color.FromArgb(45, 137, 239);
        public Color textcolor = Color.FromArgb(149, 149, 146);
        public Color backcolor = Color.FromArgb(17, 17, 17);

        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_FormLoad(object sender, EventArgs e)
        {
            rightclickmenu = new MetroContextMenu(Container);
            rightclickmenu.Theme = MetroFramework.MetroThemeStyle.Dark;

            addmineritem = new ToolStripMenuItem("Add Miner");
            removemineritem = new ToolStripMenuItem("Remove Selected Miner");
            addmineritem.Image = Properties.Resources.addminer;
            rightclickmenu.Items.Add(addmineritem);
            rightclickmenu.Items[0].Click += new EventHandler(onAddMinerClick);
            removemineritem.Image = Properties.Resources.removeminer;
            rightclickmenu.Items.Add(removemineritem);
            rightclickmenu.Items[1].Click += new EventHandler(onRemoveMinerClick);
          
            ContextMenuStrip = rightclickmenu;

            sidepanel.MaximumSize = new Size(Int32.MaxValue, 800);
            attributionlabel.Text = Program.assembly.GetName().Name + " v" +Program.assembly.GetName().Version;

            delay = Properties.Settings.Default.RefreshRate;

            Height = Properties.Settings.Default.Height;
            Width = Properties.Settings.Default.Width;
            Location = Properties.Settings.Default.WindowLocation;

            if (Properties.Settings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
            }

            refreshintervaltrackbar.Value = delay;
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(delay, 1000).ToString("0.00") + "s";
          
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
                        miner.startLoop();
                    }
                    index++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }

            if (maintabcontrol.Controls.Count != 0)
            {
                rightclickmenu.Items[1].Visible = true;
            }
            else
            {
                rightclickmenu.Items[1].Visible = false;
            }

            background = new ValueUpdater();
        }

        private void onAddMinerClick(object sender, EventArgs e)

        {
            new AddMinerScreen().ShowDialog();

            if (maintabcontrol.Controls.Count != 0)
            {
                rightclickmenu.Items[1].Visible = true;
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
                rightclickmenu.Items[1].Visible = false;
            }
            
        }

        private void OnTrackbarValueChanged(object sender, EventArgs e)
        {
            delay = refreshintervaltrackbar.Value;
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(refreshintervaltrackbar.Value, 1000).ToString("0.00") + "s";
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
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
                Properties.Settings.Default.IPs.Add(miner.name);
                Properties.Settings.Default.Usernames.Add(miner.username);
                Properties.Settings.Default.Passwords.Add(miner.password);
                miner.minerThread.Interrupt();
            }
            Properties.Settings.Default.Save();
        }
    }


}
