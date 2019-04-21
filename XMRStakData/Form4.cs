using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class Form4 : MetroForm
    {
        private TabPage testpage = new TabPage();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_FormLoad(object sender, EventArgs e)
        {
            testpage.Name = "Test";
            MetroContextMenu testmenu = new MetroContextMenu(testpage.Container);
            testpage.ContextMenuStrip = testmenu;
            ToolStripMenuItem testmenuitem = new ToolStripMenuItem("Tester");
            testmenu.Items.Add(testmenuitem);
            testmenu.Click += new System.EventHandler(this.TestMenuItemClick);
            ContextMenuStrip = testmenu;
        }



private void TestMenuItemClick(object sender, EventArgs e)

        {

            metroTabControl1.Controls.Add(testpage);

        }
    }
}
