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

namespace XMR_Stak_Hashrate_Viewer
{
    class MinerObject
    {
        private Uri uri;
        public Uri uriApi;
        public string name = null;
        public string xmrstakversion = null;
        private List<List<string>> netdata = new List<List<string>>();
        private List<string> headerdata = new List<string>();
        private TreeView tree;
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
                name = uri.Authority;
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
                        tree = createTreeView();
                        isInitialized = true;
                    }
                }
                else if (state == 1)
                {
                    MessageBox.Show("Request Timed Out!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        tree = createTreeView();
                        isInitialized = true;
                    }
                    else
                    {
                        isInitialized = false;
                        connectionsuccess = false;
                        MessageBox.Show("Username or Password Incorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Username or Password Incorrect!");
                    }
                }
                else if (state == 3)
                {

                    MessageBox.Show("Invalid XMR-Stak Miner", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Invalid XMR-Stak Miner");
                }
                    }
            catch (Exception ex)
            {
                if (ex is NullReferenceException) {

                } else if (ex is FormatException)
                {
                    MessageBox.Show("Miner is not yet initialized, please try again momentarily!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Miner is not yet initialized, please try again momentarily!");
                } else
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        tree.Nodes[1].Nodes[i].Nodes.Clear();
                        if(q != null)
                        {
                            tree.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        }
                        else
                        {
                            tree.Nodes[1].Nodes[i].Nodes.Add("0 H/s");
                        }
                        
                        i++;
                    }

                    foreach (string q in netdata[1])
                    {
                        tree.Nodes[1].Nodes[i].Nodes.Clear();
                        if (q != null)
                        {
                            tree.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        }
                        else
                        {
                            tree.Nodes[1].Nodes[i].Nodes.Add("0 H/s");
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[2])
                    {
                        tree.Nodes[2].Nodes[i].Nodes.Clear();
                        if(i == 3 && q != null)
                        {
                            tree.Nodes[2].Nodes[i].Nodes.Add(q + " s");
                        }
                        else if(q != null)
                        {
                            tree.Nodes[2].Nodes[i].Nodes.Add(q);
                        }
                        else
                        {
                            tree.Nodes[2].Nodes[i].Nodes.Add("0");
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[3])
                    {
                        tree.Nodes[3].Nodes[i].Nodes.Clear();
                        if (i == 1 && q != null)
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q + " s");
                        }
                        else if(i == 2 && q != null)
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q + " ms");
                        }
                        else if(q != null)
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q);
                        }
                        else
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add("0");
                        }
                        i++;
                    }

                    tree.EndUpdate();
                    tree.Refresh();
                }catch (InvalidOperationException)
            { }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    TabPage tab = new TabPage(name);
                    tab.Name = name;

                    TreeView content = new TreeView();
                    content.BackColor = Program.mainPage.backcolor;
                    content.ForeColor = Program.mainPage.textcolor;
                    
                    int i = 0;

                    content.Nodes.Add("XMR-Stak Version");
                    content.Nodes[0].Nodes.Add(xmrstakversion);
                    content.Nodes.Add("Hashrates");
                    foreach (string header in headerdata)
                    {
                        content.Nodes[1].Nodes.Add(header);
                    }
                    content.Nodes[1].Nodes.Add("Total");
                    content.Nodes[1].Nodes.Add("Highest");
                    content.Nodes.Add("Results");
                    content.Nodes[2].Nodes.Add("Current Difficulty");
                    content.Nodes[2].Nodes.Add("Good Shares");
                    content.Nodes[2].Nodes.Add("Total Shares");
                    content.Nodes[2].Nodes.Add("Average Result Time");
                    content.Nodes[2].Nodes.Add("Pool-Side Hashes");
                    content.Nodes.Add("Connection");
                    content.Nodes[3].Nodes.Add("Pool Address");
                    content.Nodes[3].Nodes.Add("Uptime");
                    content.Nodes[3].Nodes.Add("Ping");

                    content.Nodes[0].ForeColor = Program.mainPage.accentcolor;
                    content.Nodes[0].NodeFont = MetroFramework.MetroFonts.DefaultBold(14);
                    content.Nodes[1].ForeColor = Program.mainPage.accentcolor;
                    content.Nodes[1].NodeFont = MetroFramework.MetroFonts.DefaultBold(14);
                    content.Nodes[2].ForeColor = Program.mainPage.accentcolor;
                    content.Nodes[2].NodeFont = MetroFramework.MetroFonts.DefaultBold(14);
                    content.Nodes[3].ForeColor = Program.mainPage.accentcolor;
                    content.Nodes[3].NodeFont = MetroFramework.MetroFonts.DefaultBold(14);

                    content.Font = MetroFramework.MetroFonts.Default(12);

                    foreach (string q in netdata[0])
                    {
                        content.Nodes[1].Nodes[i].Nodes.Clear();
                        content.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }

                    foreach (string q in netdata[1])
                    {
                        content.Nodes[1].Nodes[i].Nodes.Clear();
                        content.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[2])
                    {
                        content.Nodes[2].Nodes[i].Nodes.Clear();
                        if (i == 3)
                        {
                            content.Nodes[2].Nodes[i].Nodes.Add(q + " s");
                        }
                        else
                        {
                            content.Nodes[2].Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[3])
                    {
                        content.Nodes[3].Nodes[i].Nodes.Clear();
                        if (i == 1)
                        {
                            content.Nodes[3].Nodes[i].Nodes.Add(q + " s");
                        }
                        else if (i == 2)
                        {
                            content.Nodes[3].Nodes[i].Nodes.Add(q + " ms");
                        }
                        else
                        {
                            content.Nodes[3].Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }

                    content.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    content.Size = tab.Size;
                    content.ShowPlusMinus = false;

                    tab.Controls.Add(content);
                    Program.mainPage.maintabcontrol.Controls.Add(tab);
                    content.ExpandAll();
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
