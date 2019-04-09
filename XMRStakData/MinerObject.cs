using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace XMR_Stak_Hashrate_Viewer
{
    class MinerObject
    {
        private Uri uri;
        private Uri uriApi;
        public string name = null;
        public string xmrstakversion = null;
        private int coreCount = 0;
        private List<List<string>> netdata = new List<List<string>>();
        private List<string> headerdata = new List<string>();
        private TreeView tree;
        public float total = 0;
        public float highest = 0;
        public bool isInitialized = false;
        public CredentialCache cred;

        public MinerObject(Uri u)
        {
            try
            {
                uri = u;
                uriApi = new Uri(u.AbsoluteUri.ToString() + "api.json");
                name = uri.Authority;
                cred = requiresLogin(uri);
                if (cred != null)
                {
                    netdata = getNetData(uriApi, cred);
                    headerdata = getHeaderData(uri, cred);
                }
                else
                {
                    netdata = null;
                    headerdata = null;
                }

                if (netdata != null && headerdata != null)
                {
                    coreCount = netdata[0].Count;
                    total = float.Parse(netdata[1][0]);
                    highest = float.Parse(netdata[1][1]);
                    tree = createTreeView();
                    isInitialized = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool updateMinerData()
        {
            if (netdata != null && headerdata != null)
            {
                try
                {
                    netdata = getNetData(uriApi, cred);
                    coreCount = netdata[0].Count;
                    total = float.Parse(netdata[1][0].ToString());
                    highest = float.Parse(netdata[1][1].ToString());
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
                        tree.Nodes[1].Nodes[i].Nodes.Add(netdata[0][i] + " H/s");
                        i++;
                    }
                    tree.Nodes[1].Nodes[i].Nodes.Clear();
                    tree.Nodes[1].Nodes[i].Nodes.Add(netdata[1][0] + " H/s");
                    i++;
                    tree.Nodes[1].Nodes[i].Nodes.Clear();
                    tree.Nodes[1].Nodes[i].Nodes.Add(netdata[1][1] + " H/s");

                    i = 0;
                    tree.Nodes[2].Nodes[0].Nodes.Clear();
                    tree.Nodes[2].Nodes[0].Nodes.Add(netdata[2][0]);
                    tree.Nodes[2].Nodes[1].Nodes.Clear();
                    tree.Nodes[2].Nodes[1].Nodes.Add(netdata[2][1]);
                    tree.Nodes[2].Nodes[2].Nodes.Clear();
                    tree.Nodes[2].Nodes[2].Nodes.Add(netdata[2][2]);
                    tree.Nodes[2].Nodes[3].Nodes.Clear();
                    tree.Nodes[2].Nodes[3].Nodes.Add(netdata[2][3] + " s");
                    tree.Nodes[2].Nodes[4].Nodes.Clear();
                    tree.Nodes[2].Nodes[4].Nodes.Add(netdata[2][4]);

                    tree.Nodes[3].Nodes[0].Nodes.Clear();
                    tree.Nodes[3].Nodes[0].Nodes.Add(netdata[3][0]);
                    tree.Nodes[3].Nodes[1].Nodes.Clear();
                    tree.Nodes[3].Nodes[1].Nodes.Add(netdata[3][1] + " s");
                    tree.Nodes[3].Nodes[2].Nodes.Clear();
                    tree.Nodes[3].Nodes[2].Nodes.Add(netdata[3][2] + " ms");

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
            catch (Exception ex)
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
                    content.Nodes.Add("XMR-Stak Version");
                    content.Nodes[0].Nodes.Add(xmrstakversion);
                    content.Nodes.Add("Hashrates");

                    int index = 0;
                    foreach (string header in headerdata)
                    {
                        content.Nodes[1].Nodes.Add(header);
                        content.Nodes[1].Nodes[index].Nodes.Add(netdata[0][index] + " H/s");
                        index++;
                    }
                    content.Nodes[1].Nodes.Add("Total");
                    content.Nodes[1].Nodes[index].Nodes.Add(netdata[1][0] + " H/s");
                    index++;
                    content.Nodes[1].Nodes.Add("Highest");
                    content.Nodes[1].Nodes[index].Nodes.Add(netdata[1][1] + " H/s");

                    content.Nodes.Add("Results");
                    content.Nodes[2].Nodes.Add("Current Difficulty");
                    content.Nodes[2].Nodes[0].Nodes.Add(netdata[2][0]);
                    content.Nodes[2].Nodes.Add("Good Shares");
                    content.Nodes[2].Nodes[1].Nodes.Add(netdata[2][1]);
                    content.Nodes[2].Nodes.Add("Total Shares");
                    content.Nodes[2].Nodes[2].Nodes.Add(netdata[2][2]);
                    content.Nodes[2].Nodes.Add("Average Result Time");
                    content.Nodes[2].Nodes[3].Nodes.Add(netdata[2][3] + " s");
                    content.Nodes[2].Nodes.Add("Pool-Side Hashes");
                    content.Nodes[2].Nodes[4].Nodes.Add(netdata[2][4]);

                    content.Nodes.Add("Connection");
                    content.Nodes[3].Nodes.Add("Pool Address");
                    content.Nodes[3].Nodes[0].Nodes.Add(netdata[3][0]);
                    content.Nodes[3].Nodes.Add("Uptime");
                    content.Nodes[3].Nodes[1].Nodes.Add(netdata[3][1] + " s");
                    content.Nodes[3].Nodes.Add("Ping");
                    content.Nodes[3].Nodes[2].Nodes.Add(netdata[3][2] + " ms");

                    content.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    content.Size = tab.Size;

                    Program.mainPage.tabControl1.Controls.Add(tab);

                    content.ExpandAll();

                    Program.highestValues.Add(highest);
                    Program.totals.Add(total);

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

        private CredentialCache requiresLogin(Uri urlAddress)
        {
            CredentialCache cache = new CredentialCache();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    cache.Add(uri, "Digest", new NetworkCredential("", ""));
                    return cache;
                }
                else
                {
                    throw new Exception("Request Error");
                }

            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("401"))
                {

                    Program.mainPage.Invoke((MethodInvoker)delegate
                    {
                        Login l = new Login();
                        l.Text = "Connect to: " + urlAddress;
                        l.ShowDialog();
                        cache.Add(uri, "Digest", new NetworkCredential(l.username, l.password));
                    });

                    return cache;
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        private List<List<string>> getNetData(Uri urlAddress, CredentialCache cred)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                if (cred != null)
                {
                    request.Credentials = cred;
                }
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));
                    }
                    dynamic json = JsonConvert.DeserializeObject(readStream.ReadToEnd());
                    xmrstakversion = json.version;
                    if (xmrstakversion.Contains("xmr-stak"))
                    {
                        List<List<string>> threadhashrates = new List<List<string>>();
                        threadhashrates.Add(new List<string>());
                        threadhashrates.Add(new List<string>());
                        threadhashrates.Add(new List<string>());
                        threadhashrates.Add(new List<string>());

                        foreach (JArray hashrate in json.hashrate.threads)
                        {
                            threadhashrates[0].Add(hashrate[0].ToString());
                        }
                        threadhashrates[1].Add(json.hashrate.total[0].ToString());
                        threadhashrates[1].Add(json.hashrate.highest.ToString());

                        threadhashrates[2].Add(json.results.diff_current.ToString());
                        threadhashrates[2].Add(json.results.shares_good.ToString());
                        threadhashrates[2].Add(json.results.shares_total.ToString());
                        threadhashrates[2].Add(json.results.avg_time.ToString());
                        threadhashrates[2].Add(json.results.hashes_total.ToString());

                        threadhashrates[3].Add(json.connection.pool.ToString());
                        threadhashrates[3].Add(json.connection.uptime.ToString());
                        threadhashrates[3].Add(json.connection.ping.ToString());

                        return threadhashrates;
                    }
                    else
                    {
                        MessageBox.Show("Not a valid XMR-Stak Miner!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Console.WriteLine("Not a valid XMR-Stak Miner!");
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                {
                    MessageBox.Show("Username or password incorrect, please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Username or password incorrect, please try again!");
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }
        private List<string>getHeaderData(Uri urlAddress, CredentialCache cred)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                if (cred != null)
                {
                    request.Credentials = cred;
                }
                request.Timeout = 5000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, System.Text.Encoding.GetEncoding(response.CharacterSet));
                    }

                        string data = readStream.ReadToEnd();
                        Regex headerrgx = new Regex(@"(<th>([^<th>])*<\/th>)");
                        MatchCollection headerdataIn = headerrgx.Matches(data);
                        List<string> dataOut = new List<string>();
                        int count = 0;

                        foreach (Match q in headerdataIn)
                        {
                            if (!q.Value.Equals("<th></th>") && !q.Value.Contains("10s") && !q.Value.Contains("60s") && !q.Value.Contains("15m"))
                            {
                                string parsedString = q.Value.Replace("<th>", string.Empty).Replace("</th>", string.Empty).Replace(" ", string.Empty);
                                dataOut.Add(parsedString.Remove(parsedString.IndexOf(":")));
                            }
                            count++;
                        }

                        response.Close();
                        readStream.Close();

                        return dataOut;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("401"))
                { }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }

                return null;
            }
        }
    }
 }
