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

        private static Color accentcolor = Color.FromArgb(45, 137, 239);
        private static Color textcolor = Color.FromArgb(149, 149, 146);
        private static Color backcolor = Color.FromArgb(17, 17, 17);

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
            rightclickmenu.Items[1].Visible = false;
            ContextMenuStrip = rightclickmenu;

            sidepanel.MaximumSize = new Size(Int32.MaxValue, 800);
            attributionlabel.Text = Program.assembly.GetName().Name + " v" +Program.assembly.GetName().Version;

        }

        private void onAddMinerClick(object sender, EventArgs e)

        {
            /*TabPage testpage = new TabPage();
            testpage.Text = new Random().Next(1000).ToString();

            TreeView testtree = new TreeView();
            testtree.BackColor = backcolor;
            testtree.ForeColor = textcolor;
            testtree.Nodes.Add(new Random().Next(1000).ToString());
            testtree.Dock = DockStyle.Fill;
            testpage.Controls.Add(testtree);
            maintabcontrol.Controls.Add(testpage);*/
            new AddMinerScreen().ShowDialog();
            if (maintabcontrol.Controls.Count == 0)
            {
                rightclickmenu.Items[1].Visible = true;
            }
            

        }

        private void onRemoveMinerClick(object sender, EventArgs e)

        {
            int selectedindex = maintabcontrol.SelectedIndex;

            maintabcontrol.GetControl(selectedindex).Dispose();

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
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(refreshintervaltrackbar.Value, 1000).ToString("0.00") + "s";
        }
    }


}
