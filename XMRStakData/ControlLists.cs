using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    class ControlLists
    {
        public List<Control> tabPageElements { get; private set; } = new List<Control>();
        public TabPage tabPage { get; private set; }
        public bool isInit { get; private set; } = false;
        

        public ControlLists(List<List<string>> netdata, List<string> headerdata, string ip, float total, string poolname)
        {
            initTabPage(netdata, headerdata,  ip, total,  poolname);
        }

        private void initTabPage(List<List<string>> netdata, List<string> headerdata, string ip, float total, string poolname)
        {
            try
            {


                tabPage = createTabPage(netdata, headerdata, ip, total, poolname);
                TableLayoutPanel mainPanel = createMainPanel();
                TableLayoutPanel dataPanel = createDataPanel();

                switch (dataPanel.RowCount)
                {
                    case 1:
                        dataPanel.Controls.Add(createHashratePanel(netdata, headerdata), 0, 0);
                        break;
                    case 2:
                        dataPanel.Controls.Add(createHashratePanel(netdata, headerdata), 0, 0);
                        if (Properties.Settings.Default.ShowResults) { dataPanel.Controls.Add(createResultsPanel(netdata), 0, 1); }
                        if (Properties.Settings.Default.ShowConnection) { dataPanel.Controls.Add(createConnectionPanel(netdata), 0, 1); }
                    break;
                    case 3:
                        dataPanel.Controls.Add(createHashratePanel(netdata, headerdata), 0, 0);
                        dataPanel.Controls.Add(createResultsPanel(netdata), 0, 1);
                        dataPanel.Controls.Add(createConnectionPanel(netdata), 0, 2);
                    break;
                    default:
                        dataPanel.Controls.Add(createHashratePanel(netdata, headerdata), 0, 0);
                        dataPanel.Controls.Add(createResultsPanel(netdata), 0, 1);
                        dataPanel.Controls.Add(createConnectionPanel(netdata), 0, 2);
                    break;
                }

                mainPanel.Controls.Add(dataPanel, 0, 0);
                tabPage.Controls.Add(mainPanel);
                
                foreach(Control c in mainPanel.Controls)
                {
                    tabPageElements.Add(c);
                }

                isInit = true;

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(Program.mainPage, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isInit = false;
            }
        }

        private TabPage createTabPage(List<List<string>> netdata, List<string> headerdata, string ip, float total, string poolname)
        {
                TabPage tab;

                if (netdata != null && headerdata != null)
                {
                    if (Properties.Settings.Default.TabNameType == 0)
                    {
                        tab = new TabPage(ip);
                    }
                    else if (Properties.Settings.Default.TabNameType == 1)
                    {
                        tab = new TabPage(total.ToString() + " H/s");
                    }
                    else
                    {
                        if (poolname != null && poolname != "")
                        {
                            tab = new TabPage(poolname);
                        }
                        else
                        {
                            tab = new TabPage(ip);
                        }
                        tab.BackColor = Program.mainPage.backcolor;
                    }
                    return tab;
                }
                else
                {
                    return null;
                }
        }

        private TableLayoutPanel createMainPanel()
        {
            TableLayoutPanel mainPanel = new TableLayoutPanel();
            mainPanel.ColumnCount = 2;
            mainPanel.RowCount = 1;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Margin = new Padding(10);
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70f));
            return mainPanel;
        }

        private TableLayoutPanel createDataPanel()
        {
            int rowcount = 1;
            if (Properties.Settings.Default.ShowResults) { rowcount++; }
            if (Properties.Settings.Default.ShowConnection) { rowcount++;}

            TableLayoutPanel dataPanel = new TableLayoutPanel();
            dataPanel.ColumnCount = 1;
            dataPanel.RowCount = rowcount;
            dataPanel.MinimumSize = new Size(350,Int32.MinValue);
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;


            switch (rowcount)
            {
                case 1:
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
                    break;
                case 2:
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75f));
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    break;
                case 3:
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 75f));
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 15f));
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
                    break;
                default:
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 80f));
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    dataPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    break;
            }

            return dataPanel;
        }

        private TableLayoutPanel createHashratePanel(List<List<string>> netdata, List<string> headerdata)
        {
            if (netdata != null && headerdata != null)
            {
                TableLayoutPanel hashratePanel = new TableLayoutPanel();
                hashratePanel.AutoScroll = true;
                hashratePanel.Margin = new Padding(5);
                hashratePanel.ColumnCount = 1;
                hashratePanel.RowCount = netdata[0].Count + netdata[1].Count + 1;
                hashratePanel.Dock = DockStyle.Fill;

                for (int i = 0; i < hashratePanel.RowCount; i++)
                {
                    hashratePanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }

                MetroLabel hashlabel;

                for (int i = 0; i < hashratePanel.RowCount - 1; i++)
                {
                    if (i == netdata[0].Count)
                    {
                        hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Total: " + netdata[1][0] + " H/s" };
                    }
                    else if (i == netdata[0].Count + 1)
                    {
                        hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Highest: " + netdata[1][1] + " H/s" };
                    }
                    else
                    {
                        hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = headerdata[i] + ": " + netdata[0][i] + " H/s" };
                    }
                   
                    hashratePanel.Controls.Add(hashlabel, 0, i);
                }

                return hashratePanel;
            }
            else
            {
                return null;
            }
        }

        private TableLayoutPanel createResultsPanel(List<List<string>> netdata)
        {
            if (netdata != null)
            {
                TableLayoutPanel resultsPanel = new TableLayoutPanel();
                resultsPanel.AutoScroll = true;
                resultsPanel.Margin = new Padding(5);
                resultsPanel.ColumnCount = 1;
                resultsPanel.RowCount = netdata[2].Count + 1;
                resultsPanel.Dock = DockStyle.Fill;

                for (int i = 0; i < resultsPanel.RowCount; i++)
                {
                    resultsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }


                int j = 0;
                MetroLabel hashlabel;

                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Difficulty: " + netdata[2][0]};
                resultsPanel.Controls.Add(hashlabel, 0, 0);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Good Results: " + netdata[2][1]};
                resultsPanel.Controls.Add(hashlabel, 0, 1);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Total Results: " + netdata[2][2]};
                resultsPanel.Controls.Add(hashlabel, 0, 2);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Average Result Time: " + netdata[2][3] + " s" };
                resultsPanel.Controls.Add(hashlabel, 0, 3);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Pool-Side Hashes: " + netdata[2][4]};
                resultsPanel.Controls.Add(hashlabel, 0, 4);


                return resultsPanel;
            }
            else
            {
                return null;
            }
        }

        private TableLayoutPanel createConnectionPanel(List<List<string>> netdata)
        {
            if (netdata != null)
            {
                TableLayoutPanel connectionPanel = new TableLayoutPanel();
                connectionPanel.AutoScroll = true;
                connectionPanel.Margin = new Padding(5);
                connectionPanel.ColumnCount = 1;
                connectionPanel.RowCount = netdata[2].Count + 1;
                connectionPanel.Dock = DockStyle.Fill;

                for (int i = 0; i < connectionPanel.RowCount; i++)
                {
                    connectionPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }


                MetroLabel hashlabel;

                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Pool Address: " + netdata[3][0] };
                connectionPanel.Controls.Add(hashlabel, 0, 0);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Uptime: " + netdata[3][1] + " s" };
                connectionPanel.Controls.Add(hashlabel, 0, 1);
                hashlabel = new MetroLabel() { AutoSize = true, Margin = new Padding(3), Theme = MetroThemeStyle.Dark, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, Text = "Pool Ping Time: " + netdata[3][2] + " ms" };
                connectionPanel.Controls.Add(hashlabel, 0, 2);

                return connectionPanel;
            }
            else
            {
                return null;
            }
        }

        private TableLayoutPanel createGraphPanel (List<List<string>> netdata)
        {
            //TODO
            return null;
        }

    }
}
