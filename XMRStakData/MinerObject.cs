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

        public MinerObject(Uri u, string us, string p)
        {
            try
            {
                uri = u;
                passwordTemp = p;
                usernameTemp = us;
                uriApi = new Uri(uri.AbsoluteUri.ToString() + "api.json");
                name = uri.Authority;

                if (NetworkGatherer.requiresLogin(uri, this))
                {
                    credentialCache.Add(uri, "Digest", new NetworkCredential(username, CryptographyEngine.DecryptString(password, uriApi.AbsolutePath)));
                }
                else
                {
                    credentialCache.Add(uri, "Digest", new NetworkCredential("", ""));
                }

                netdata = NetworkGatherer.getNetData(uriApi, false, this);
                headerdata = NetworkGatherer.getNetData(uri, true, this)[0];

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
            catch (Exception ex)
            {
                if(!(ex is NullReferenceException))
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
                    netdata = NetworkGatherer.getNetData(uriApi, false, this);
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
                        tree.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }

                    foreach (string q in netdata[1])
                    {
                        tree.Nodes[1].Nodes[i].Nodes.Clear();
                        tree.Nodes[1].Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[2])
                    {
                        tree.Nodes[2].Nodes[i].Nodes.Clear();
                        if(i == 3)
                        {
                            tree.Nodes[2].Nodes[i].Nodes.Add(q + " s");
                        }
                        else
                        {
                            tree.Nodes[2].Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }
                    i = 0;

                    foreach (string q in netdata[3])
                    {
                        tree.Nodes[3].Nodes[i].Nodes.Clear();
                        if (i == 1)
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q + " s");
                        }
                        else if(i == 2)
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q + " ms");
                        }
                        else
                        {
                            tree.Nodes[3].Nodes[i].Nodes.Add(q);
                        }
                        i++;
                    }

                    tree.EndUpdate();
                    tree.Refresh();
                }
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
                    tab.Controls.Add(content);
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

                    //Program.mainPage.tabControl1.Controls.Add(tab);
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
                            if (Program.mainPage.InvokeRequired)
                                Program.mainPage.Invoke(new MethodInvoker(delegate ()
                                {
                                //Program.mainPage.tabControl1.GetControl(identifierindex).Dispose();
                                }));
                                else
                                {
                              //Program.mainPage.tabControl1.GetControl(identifierindex).Dispose();
                                }
                        }
                    }
                    else
                    {
                        //Thread.Sleep(Program.mainPage.delay);
                    }
                }
                catch (InvalidOperationException)
                {
                    continue;

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
