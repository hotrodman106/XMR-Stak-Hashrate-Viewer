using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class MainPage : MetroForm
    {
        private MetroContextMenu testmenu;
        private ToolStripMenuItem testmenuitem2 = new ToolStripMenuItem("Remove Selected Miner");
        private static Color accentColor = Color.FromArgb(45, 137, 239);
        private static Color textColor = Color.FromArgb(149, 149, 146);
        private static Color backColor = Color.FromArgb(17, 17, 17);
        public MainPage()
        {
            InitializeComponent();
        }

        private void Form4_FormLoad(object sender, EventArgs e)
        {
            testmenu = new MetroContextMenu(maintabcontrolcontainer.Container);
            testmenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            ToolStripMenuItem testmenuitem = new ToolStripMenuItem("Add Miner");
            testmenuitem.Image = Properties.Resources.addminer;
            testmenu.Items.Add(testmenuitem);
            testmenu.Items[0].Click += new EventHandler(this.TestMenuItemClick);
            testmenu.Items.Add(testmenuitem2);
            testmenu.Items[1].Click += new EventHandler(this.TestMenuItemClick2);
            testmenuitem2.Image = Properties.Resources.removeminer;
            testmenu.Items[1].Visible = false;
            ContextMenuStrip = testmenu;
            sidepanel.MaximumSize = new Size(Int32.MaxValue, 800);
            attributionlabel.Text = Program.assembly.GetName().Name + " v" +Program.assembly.GetName().Version;

        }

        private void TestMenuItemClick(object sender, EventArgs e)

        {
            TabPage testpage = new TabPage();
            testpage.Text = new Random().Next(1000).ToString();

            TreeView testtree = new TreeView();
            testtree.BackColor = backColor;
            testtree.ForeColor = textColor;
            testtree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            testtree.Nodes.Add(new Random().Next(1000).ToString());
            testtree.Dock = DockStyle.Fill;
            testpage.Controls.Add(testtree);
            if (maintabcontrol.Controls.Count == 0)
            {
                testmenu.Items[1].Visible = true;
            }
            maintabcontrol.Controls.Add(testpage);

        }

        private void TestMenuItemClick2(object sender, EventArgs e)

        {
            int testint = maintabcontrol.SelectedIndex;
            maintabcontrol.GetControl(testint).Dispose();
            if(testint != 0)
            {
                maintabcontrol.SelectedIndex = testint - 1;
            }
            if (maintabcontrol.Controls.Count == 0)
            {
                testmenu.Items[1].Visible = false;
            }
            
        }

        private void OnValueChanged(object sender, EventArgs e)

        {
            refreshintervallabel.Text = "Refresh Interval: " + Decimal.Divide(refreshintervaltrackbar.Value, 1000).ToString("0.00") + "s";
            Console.WriteLine(refreshintervaltrackbar.Value);

        }


        private void resize(object sender, EventArgs e)
        {
            Console.WriteLine(Size);
        }
    }


}
