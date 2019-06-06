using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Security;
using System.Text;
using System.Threading;
using XMR_Stak_Hashrate_Viewer;
using MetroFramework.Controls;
using MetroFramework;
using System.Drawing;

namespace XMR_Stak_Hashrate_Viewer
{
    class MinerObject
    {
        private Uri uri;
        public Uri uriApi;
        private Uri uriResults;
        public string ip = null;
        public string poolname = null;
        public string xmrstakversion = null;
        private List<List<string>> netdata = new List<List<string>>();
        private List<string> headerdata = new List<string>();
        private TreeView tree;
        private TreeNode hashratenode = new TreeNode("Hashrates");
        private TreeNode resultsnode = new TreeNode("Results");
        private TreeNode connectionnode = new TreeNode("Connection");
        private TreeNode versionnode = new TreeNode("XMR-Stak Version");
        private TabPage tab;
        private ControlLists controls;
        public float total = 0;
        public float highest = 0;
        public bool isInitialized = false;
        public string password = null;
        public string username = null;
        public string passwordTemp = null;
        public string usernameTemp = null;
        public CredentialCache credentialCache = new CredentialCache();
        public Thread minerThread;
        public bool connectionsuccess = true;
        private NetworkGatherer networkGatherer = new NetworkGatherer();

        public MinerObject(Uri u, string us, string p)
        {
            try
            {
                uri = u;
                passwordTemp = p;
                usernameTemp = us;
                uriApi = new Uri(uri.AbsoluteUri.ToString() + "api.json");
                uriResults = new Uri(uri.AbsoluteUri.ToString() + "c");
                ip = uri.Authority;
                int state = networkGatherer.isXMRStakMiner(uri, this);

                if (state == 0)
                {
                    credentialCache.Add(uri, "Digest", new NetworkCredential("", ""));

                    netdata = networkGatherer.getNetData(uriApi, false, this, 2);
                    headerdata = networkGatherer.getNetData(uri, true, this, 2)[0];

                    if (netdata != null && headerdata != null)
                    {
                        total = float.Parse(netdata[1][0]);
                        highest = float.Parse(netdata[1][1]);
                        Program.highestValues.Add(highest);
                        Program.totals.Add(total);
                        poolname = networkGatherer.getRigID(uriResults, 2, this);
                        controls = new ControlLists(netdata,headerdata,ip,total,poolname);
                        Program.mainPage.maintabcontrol.Controls.Add(controls.tabPage);
                        //tree = createTreeView();
                        isInitialized = true;
                    }
                }
                else if (state == 1)
                {
                    MetroMessageBox.Show(Program.mainPage, "Request Timed Out!", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Request Timed Out!");
                }
                else if (state == 2 || (username != null && password != null))
                {
                    credentialCache.Add(uri, "Digest", new NetworkCredential(username, CryptographyEngine.DecryptString(password, uriApi.AbsolutePath)));

                    netdata = networkGatherer.getNetData(uriApi, false, this, 2);
                    if(netdata == null)
                    {
                        headerdata = null;
                    }
                    else
                    {
                        headerdata = networkGatherer.getNetData(uri, true, this, 2)[0];
                    }

                    if (netdata != null && headerdata != null)
                    {
                        total = float.Parse(netdata[1][0]);
                        highest = float.Parse(netdata[1][1]);
                        Program.highestValues.Add(highest);
                        Program.totals.Add(total);
                        poolname = networkGatherer.getRigID(uriResults, 2, this);
                        controls = new ControlLists(netdata, headerdata, ip, total, poolname);
                        Program.mainPage.maintabcontrol.Controls.Add(controls.tabPage);
                        //tree = createTreeView();
                        isInitialized = true;
                    }
                    else
                    {
                        isInitialized = false;
                        connectionsuccess = false;
                        MetroMessageBox.Show(Program.mainPage,"Username or Password Incorrect!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        Console.WriteLine("Username or Password Incorrect!");
                    }
                }
                else if (state == 3)
                {

                    MetroMessageBox.Show(Program.mainPage, "Invalid XMR-Stak Miner", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Console.WriteLine("Invalid XMR-Stak Miner");
                }
                    }
            catch (Exception ex)
            {
                if (ex is NullReferenceException) {

                } else if (ex is FormatException)
                {
                    MetroMessageBox.Show(Program.mainPage, "Miner is not yet initialized, please try again momentarily!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Console.WriteLine("Miner is not yet initialized, please try again momentarily!");
                } else
                {
                    Console.WriteLine(ex.Message);
                    MetroMessageBox.Show(Program.mainPage, ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }
        public bool updateMinerData()
        {
            if (netdata != null && headerdata != null)
            {
                try
                {
                    netdata = networkGatherer.getNetData(uriApi, false, this, 3);
                    if(!netdata[1][0].Equals("")){ total = float.Parse(netdata[1][0]); }
                    if (!netdata[1][1].Equals("")) { highest = float.Parse(netdata[1][1]); }

                    int identifierindex = Program.minerList.IndexOf(this);
                    if (Program.totals.Count < Program.minerList.Count && Program.totals.Count != 0)
                    {
                        Program.totals.Add(total);
                    }
                    else if (Program.totals.Count == Program.minerList.Count)
                    {
                        Program.totals[identifierindex] = total;
                    }

                    if (Program.highestValues.Count < Program.minerList.Count && Program.totals.Count != 0)
                    {
                        Program.highestValues.Add(total);
                    }
                    else if (Program.highestValues.Count == Program.minerList.Count)
                    {
                        Program.highestValues[identifierindex] = highest;
                    }

                    return true;
                }
                catch (NullReferenceException)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MetroMessageBox.Show(Program.mainPage, ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool redrawMinerScreen()
        {
            try
            {
                Program.mainPage.Invoke((MethodInvoker)delegate
            {

                try
                {
                    int i = 0;
                    tree.BeginUpdate();

                    foreach (string q in netdata[0])
                    {
                        hashratenode.Nodes[i].Nodes.Clear();
                        hashratenode.Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }

                    foreach (string q in netdata[1])
                    {
                        hashratenode.Nodes[i].Nodes.Clear();
                        hashratenode.Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[2])
                    {
                        resultsnode.Nodes[i].Nodes.Clear();
                        if (i == 3)
                        {
                            resultsnode.Nodes[i].Nodes.Add(q + " s");
                        }
                        else
                        {
                            resultsnode.Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[3])
                    {
                        connectionnode.Nodes[i].Nodes.Clear();
                        if (i == 1)
                        {
                            connectionnode.Nodes[i].Nodes.Add(q + " s");
                        }
                        else if (i == 2)
                        {
                            connectionnode.Nodes[i].Nodes.Add(q + " ms");
                        }
                        else
                        {
                            connectionnode.Nodes[i].Nodes.Add(q);
                        }
                        i++;
                }

                    tree.EndUpdate();
                    tree.Refresh();
                    if (Properties.Settings.Default.TabNameType == 1)
                    {
                        tab.Text = total.ToString() + " H/s";
                    }
                }
                catch (InvalidOperationException)
            { }
            catch (Exception ex)
                {
                MetroMessageBox.Show(Program.mainPage, ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TreeView createTreeView()
        {
            try
            {
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

                    }


                    TreeView content = new TreeView();
                    content.BackColor = Program.mainPage.backcolor;
                    content.ForeColor = Program.mainPage.textcolor;
                    content.Font = MetroFonts.Default(12);
                    content.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    content.ShowPlusMinus = false;
                    content.Size = tab.Size;

                    int i = 0;

                    foreach (string header in headerdata)
                    {
                        hashratenode.Nodes.Add(header);
                    }

                    hashratenode.Nodes.Add("Total");
                    hashratenode.Nodes.Add("Highest");
                    hashratenode.ForeColor = Program.mainPage.accentcolor;
                    hashratenode.NodeFont = MetroFonts.DefaultBold(14);

                    resultsnode.Nodes.Add("Current Difficulty");
                    resultsnode.Nodes.Add("Good Shares");
                    resultsnode.Nodes.Add("Total Shares");
                    resultsnode.Nodes.Add("Average Result Time");
                    resultsnode.Nodes.Add("Pool-Side Hashes");
                    resultsnode.ForeColor = Program.mainPage.accentcolor;
                    resultsnode.NodeFont = MetroFonts.DefaultBold(14);

                    connectionnode.Nodes.Add("Pool Address");
                    connectionnode.Nodes.Add("Uptime");
                    connectionnode.Nodes.Add("Ping");
                    connectionnode.ForeColor = Program.mainPage.accentcolor;
                    connectionnode.NodeFont = MetroFonts.DefaultBold(14);

                    versionnode.Nodes.Add(xmrstakversion);
                    versionnode.ForeColor = Program.mainPage.accentcolor;
                    versionnode.NodeFont = MetroFonts.DefaultBold(14);

                    foreach (string q in netdata[0])
                    {
                        hashratenode.Nodes[i].Nodes.Clear();
                        hashratenode.Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }

                    foreach (string q in netdata[1])
                    {
                        hashratenode.Nodes[i].Nodes.Clear();
                        hashratenode.Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[2])
                    {
                        resultsnode.Nodes[i].Nodes.Clear();
                        if (i == 3)
                        {
                            resultsnode.Nodes[i].Nodes.Add(q + " s");
                        }
                        else
                        {
                            resultsnode.Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[3])
                    {
                        connectionnode.Nodes[i].Nodes.Clear();
                        if (i == 1)
                        {
                            connectionnode.Nodes[i].Nodes.Add(q + " s");
                        }
                        else if (i == 2)
                        {
                            connectionnode.Nodes[i].Nodes.Add(q + " ms");
                        }
                        else
                        {
                            connectionnode.Nodes[i].Nodes.Add(q);
                        }
                        i++;

                    }

                    if (Properties.Settings.Default.ShowVersion)
                    {
                        content.Nodes.Add(versionnode);
                    }

                    content.Nodes.Add(hashratenode);

                    if (Properties.Settings.Default.ShowResults)
                    {
                        content.Nodes.Add(resultsnode);
                    }

                    if (Properties.Settings.Default.ShowConnection)
                    {
                        content.Nodes.Add(connectionnode);
                    }

                    tab.Controls.Add(content);
                    Program.mainPage.maintabcontrol.Controls.Add(tab);

                    if (Properties.Settings.Default.ExpandAll)
                    {
                        content.ExpandAll();
                    }
                    else
                    {
                        foreach (TreeNode t in content.Nodes)
                        {
                            foreach (TreeNode r in t.Nodes)
                            {
                                r.ExpandAll();
                            }
                        }
                    }
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(Program.mainPage, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        

        private void updateLoop(object parameters)
        {
            while (isInitialized)
            {
                try
                {
                    int identifierindex = Program.minerList.IndexOf(this);

                    if (!updateMinerData() || !redrawMinerScreen())
                    {
                       isInitialized = false;
                        if(identifierindex >= 0){
                            try { 
                                Program.mainPage.Invoke(new MethodInvoker(delegate ()
                                {
                                    Program.mainPage.maintabcontrol.TabPages.RemoveAt(identifierindex);
                                    Program.minerList[identifierindex].minerThread.Interrupt();
                                    Program.minerList.RemoveAt(identifierindex);
                                    Program.totals.RemoveAt(identifierindex);
                                    Program.highestValues.RemoveAt(identifierindex);
                                    Program.mainPage.background.thread.Interrupt();

                                    if (Program.mainPage.maintabcontrol.Controls.Count == 0)
                                    {
                                        Program.mainPage.removeminerbutton.Visible = false;
                                    }
                                }));
                            }
                            catch (InvalidOperationException)
                            { }
                        }
                    }
                    else
                    {
                        Thread.Sleep(Program.mainPage.delay);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    if (ex.Message.Contains("Invoke or BeginInvoke"))
                    {
                        isInitialized = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }

                }
                catch (ThreadInterruptedException)
                {
                    isInitialized = false;
                    break;

                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(Program.mainPage, ex.Message, "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    break;
                }

            }
        }
        public void startLoop()
        {
            minerThread = new Thread(new ParameterizedThreadStart(updateLoop));
            minerThread.Start();
        }
    }
}
