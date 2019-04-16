using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XMR_Stak_Hashrate_Viewer;

namespace XMR_Stak_Hashrate_Viewer
{
    class BackgroundThread
    {
        public bool state = true;
        private List<MinerObject> tempMinerList = new List<MinerObject>();

        public BackgroundThread()
        {
            Thread t = new Thread(new ParameterizedThreadStart(loop));
            t.Start();
        }

        private void loop(object parameters)
        {
            while (state)
            {
                try
                {
                    if (Program.minerList.Count != 0)
                    {
                        Program.totals.Clear();
                        Program.highestValues.Clear();
                        tempMinerList = Program.minerList;

                        foreach (MinerObject miner in Program.minerList)
                        {
                            if (!miner.updateMinerData() || !miner.redrawMinerScreen())
                            {
                                miner.isInitialized = false;

                                if (Program.mainPage.InvokeRequired)
                                    Program.mainPage.Invoke(new MethodInvoker(delegate ()
                                    {
                                        Program.mainPage.tabControl1.GetControl(tempMinerList.IndexOf(miner)).Dispose();
                                    }));
                                else
                                {
                                    Program.mainPage.tabControl1.GetControl(tempMinerList.IndexOf(miner)).Dispose();
                                }

                                tempMinerList.Remove(miner);
                            }
                            Program.totals.Add(miner.total);
                            Program.highestValues.Add(miner.highest);
                        }
                        if (Program.mainPage.InvokeRequired)
                            Program.mainPage.Invoke(new MethodInvoker(delegate ()
                            {
                                Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + Math.Round(Program.highestValues.Sum(), 1).ToString() + " H/s";
                                Program.mainPage.averageHashrate.Text = "Total Hashrate: " + Math.Round(Program.totals.Sum(), 1).ToString() + " H/s";
                            }));
                        else
                        {
                            Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + Math.Round(Program.highestValues.Sum(), 1).ToString() + " H/s";
                            Program.mainPage.averageHashrate.Text = "Total Hashrate: " + Math.Round(Program.totals.Sum(), 1).ToString() + " H/s";
                        }

                        Program.minerList = tempMinerList;

                        Thread.Sleep(Program.mainPage.delay);

                    }
                }catch(InvalidOperationException)
                {
                    continue;
                    
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    break;
                }
                
            }
        }
    }
}
