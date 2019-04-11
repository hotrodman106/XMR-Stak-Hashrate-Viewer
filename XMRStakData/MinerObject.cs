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
                    netdata = getNetData(uriApi, cred, false);
                    headerdata = getNetData(uri, cred, true)[0];
                }
                else
                {
                    netdata = null;
                    headerdata = null;
                }

                if (netdata != null && headerdata != null)
                {
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
                    netdata = getNetData(uriApi, cred, false);
                    if(!netdata[1][0].Equals("")){ total = float.Parse(netdata[1][0]); }
                    if (!netdata[1][1].Equals("")) { highest = float.Parse(netdata[1][1]); }
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
        private List<List<string>> getNetData(Uri urlAddress, CredentialCache cred, bool getHeaderData)
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

                    if (getHeaderData)
                    {
                        string data = readStream.ReadToEnd();
                        Regex headerrgx = new Regex(@"(<th>([^<th>])*<\/th>)");
                        MatchCollection headerdataIn = headerrgx.Matches(data);
                        List<string> dataOut = new List<string>();
                        List<List<string>> output = new List<List<string>>();

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
                        output.Add(dataOut);

                        return output;
                    }
                    else
                    {
                        dynamic json = JsonConvert.DeserializeObject(readStream.ReadToEnd());
                        xmrstakversion = json.version;
                        if (xmrstakversion.Contains("xmr-stak"))
                        {
                            List<List<string>> threadhashrates = new List<List<string>>();

                            for (int i = 0; i != 4; i++)
                            {
                                threadhashrates.Add(new List<string>());
                            }

                            foreach (JProperty hashrates in json.hashrate)
                            {
                                if (hashrates.Name.Equals("threads"))
                                {
                                    foreach (JArray values in hashrates.Value)
                                    {
                                        threadhashrates[0].Add(values.First.ToString());
                                    }
                                }
                                else if (hashrates.Name.Equals("total"))
                                {
                                    threadhashrates[1].Add(hashrates.Value.First.ToString());
                                }
                                else
                                {
                                    threadhashrates[1].Add(hashrates.Value.ToString());
                                }
                            }

                            foreach (JProperty results in json.results)
                            {
                                if (!results.Name.Equals("best"))
                                {
                                    threadhashrates[2].Add(results.First.ToString());
                                }
                                else
                                {
                                    break;
                                }

                            }

                            foreach (JProperty connection in json.connection)
                            {
                                if (!connection.Name.Equals("error_log"))
                                {
                                    threadhashrates[3].Add(connection.First.ToString());
                                }
                                else
                                {
                                    break;
                                }
                            }

                            return threadhashrates;
                        }
                        else
                        {
                            MessageBox.Show("Not a valid XMR-Stak Miner!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Console.WriteLine("Not a valid XMR-Stak Miner!");
                            return null;
                        }
                    }
            } else
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
    }
}
