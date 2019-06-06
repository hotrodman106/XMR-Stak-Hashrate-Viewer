using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class SettingsScreen : MetroForm
    {
        private int TabNameSelected;
        public SettingsScreen()
        {
            InitializeComponent();
        }

        
        private void SettingsScreen_Load(object sender, EventArgs e)
        {
            ExpandAllToggle.Checked = Properties.Settings.Default.ExpandAll;
            setTabNameState(Properties.Settings.Default.TabNameType);
            VersionDataToggle.Checked = Properties.Settings.Default.ShowVersion;
            ResultDataToggle.Checked = Properties.Settings.Default.ShowResults;
            ConnectionDataToggle.Checked = Properties.Settings.Default.ShowConnection;
            SidebarDataToggle.Checked = Properties.Settings.Default.ShowSidebar;
            CloseOnExitToggle.Checked = Properties.Settings.Default.CloseonExit;
        }

        private void TabNameOption1_CheckedChanged(object sender, EventArgs e)
        {
            TabNameSelected = 0;
        }

        private void TabNameOption2_CheckedChanged(object sender, EventArgs e)
        {
            TabNameSelected = 1;
        }

        private void TabNameOption3_CheckedChanged(object sender, EventArgs e)
        {
            TabNameSelected = 2;
        }

        private void setTabNameState(int value)
        {
            switch (value)
            {
                case 0:
                    TabNameOption1.Checked = true;
                    TabNameSelected = 0;
                break;
                case 1:
                    TabNameOption2.Checked = true;
                    TabNameSelected = 1;
                break;
                case 2:
                    TabNameOption3.Checked = true;
                    TabNameSelected = 2;
                break;
                default:
                    TabNameOption1.Checked = true;
                    TabNameSelected = 0;
                break;
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MetroMessageBox.Show(Program.mainPage, "The program must restart to save your settings, proceed?", "Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(dialogResult == DialogResult.Yes) {
                Properties.Settings.Default.ExpandAll = ExpandAllToggle.Checked;
                Properties.Settings.Default.TabNameType = TabNameSelected;
                Properties.Settings.Default.ShowVersion = VersionDataToggle.Checked;
                Properties.Settings.Default.ShowResults = ResultDataToggle.Checked;
                Properties.Settings.Default.ShowConnection = ConnectionDataToggle.Checked;
                Properties.Settings.Default.ShowSidebar = SidebarDataToggle.Checked;
                Properties.Settings.Default.CloseonExit = CloseOnExitToggle.Checked;
                Properties.Settings.Default.Save();
                Program.mutex.Close();
                Application.Restart();
            }
        }
    }
}
