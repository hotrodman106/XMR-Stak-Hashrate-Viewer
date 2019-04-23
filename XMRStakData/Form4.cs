using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class Form4 : MetroForm
    {
        private MetroContextMenu testmenu;
        private ToolStripMenuItem testmenuitem2 = new ToolStripMenuItem("Remove");
        private static Color accentColor = Color.FromArgb(45, 137, 239);
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormLoad(object sender, EventArgs e)
        {
            testmenu = new MetroContextMenu(metroPanel5.Container);
            testmenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            ToolStripMenuItem testmenuitem = new ToolStripMenuItem("Create");
            testmenu.Items.Add(testmenuitem);
            testmenu.Items[0].Click += new EventHandler(this.TestMenuItemClick);
            ContextMenuStrip = testmenu;


        }

        private void TestMenuItemClick(object sender, EventArgs e)

        {
            TabPage testpage = new TabPage();
            testpage.Text = new Random().Next(1000).ToString();

            TreeView testtree = new TreeView();
            testtree.Nodes.Add("TEST1");
            testtree.Nodes.Add("TEST2");
            testtree.Nodes.Add("TEST3");
            testtree.Dock = DockStyle.Fill;
            testpage.Controls.Add(testtree);
            metroTabControl1.Controls.Add(testpage);
            
            testmenu.Items.Add(testmenuitem2);
            testmenu.Items[1].Click += new EventHandler(this.TestMenuItemClick2);

        }

        private void TestMenuItemClick2(object sender, EventArgs e)

        {
            int testint = metroTabControl1.SelectedIndex;
            metroTabControl1.GetControl(testint).Dispose();
            if (metroTabControl1.Controls.Count == 0)
            {
                testmenu.Items.Remove(testmenuitem2);
            }
            
        }

        private void resize(object sender, EventArgs e)
        {

        }
    }


}
