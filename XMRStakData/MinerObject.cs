using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    class MinerObject
    {
        private Uri uri;

        public string name = null;
        private int coreCount = 0;
        private List<float> hashvalues = new List<float>();
        private TreeView tree;
        public float total = 0;
        public float highest = 0;
        public bool isInitialized = false;

        public MinerObject(Uri u)
        {
            try
            {
                uri = u;

                name = uri.Authority;
                hashvalues = getHashvalues(uri);
                if (hashvalues != null)
                {
                    coreCount = hashvalues.Count - 2;
                    total = hashvalues[hashvalues.Count - 2];
                    highest = hashvalues[hashvalues.Count - 1];
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
            if (hashvalues != null)
            {
                try
                {
                    hashvalues = getHashvalues(uri);
                    coreCount = hashvalues.Count - 2;
                    total = hashvalues[hashvalues.Count - 2];
                    highest = hashvalues[hashvalues.Count - 1];
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
                    foreach (float q in hashvalues)
                    {
                        tree.Nodes[0].Nodes[i].Nodes.Clear();
                        tree.Nodes[0].Nodes[i].Nodes.Add(q + " H/s");
                        i++;
                    }
                    tree.EndUpdate();
                    tree.ExpandAll();
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public TreeView createTreeView()
        {
            try
            {
                if (hashvalues.Count != 0)
                {
                    TabPage tab = new TabPage(name);
                    tab.Name = name;
                    TreeView content = new TreeView();
                    tab.Controls.Add(content);

                    content.Nodes.Add("Hash Values");

                    int index = 0;
                    int itemCount = hashvalues.Count - 1;
                    foreach (float hashrate in hashvalues)
                    {
                        if (index <= itemCount - 2)
                        {
                            content.Nodes[0].Nodes.Add("Core " + index);
                            content.Nodes[0].Nodes[index].Nodes.Add(hashrate + " H/s");
                        }
                        else if (index == itemCount - 1)
                        {
                            content.Nodes[0].Nodes.Add("Total ");
                            content.Nodes[0].Nodes[index].Nodes.Add(hashrate + " H/s");
                        }
                        else
                        {
                            content.Nodes[0].Nodes.Add("Highest ");
                            content.Nodes[0].Nodes[index].Nodes.Add(hashrate + " H/s");
                        }
                        index++;
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

        private List<float> getHashvalues(Uri urlAddress)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.Timeout = 10000;
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
                    if (data.Contains("<div class='header'><span style='color: rgb(255, 160, 0)'>XMR</span>-Stak Monero Miner</div>"))
                    {
                        string pat = @"(<td>([^<td>])*<\/td>)";
                        Regex rgx = new Regex(pat);
                        MatchCollection dataIn = rgx.Matches(data);
                        List<float> dataOut = new List<float>();
                        int count = 0;

                        foreach (Match q in dataIn)
                        {
                            if (count % 3 == 0)
                            {
                                if (!q.Value.Equals("<td></td>"))
                                {
                                    dataOut.Add(float.Parse(q.Value.Replace("<td>", string.Empty).Replace("</td>", string.Empty).Replace(" ", string.Empty)));
                                }
                                else
                                {
                                    dataOut.Add(0f);
                                }

                            }
                            count++;
                        }

                        response.Close();
                        readStream.Close();

                        return dataOut;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
