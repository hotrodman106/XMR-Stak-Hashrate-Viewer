using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using XMR_Stak_Hashrate_Viewer;

namespace XMR_Stak_Hashrate_Viewer
{
    public class ValueUpdater
    {
        public bool state = true;
        public Thread thread;
        public int minercount = 0;
        private double highestvalue;
        private double totalvalue;
        private double moneroprice;
        private double weeklyrevenue;

        public ValueUpdater()
        {
            thread = new Thread(new ParameterizedThreadStart(loop));
            thread.Start();
        }
        private void updateValues()
        {
            if (Program.mainPage.InvokeRequired)
                Program.mainPage.Invoke(new MethodInvoker(delegate ()
                {
                    Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + highestvalue.ToString() + " H/s";
                    Program.mainPage.averageHashrate.Text = "Total Hashrate: " + totalvalue.ToString() + " H/s";
                    Program.mainPage.moneropricetext.Text = "Current Monero Value: $" + moneroprice.ToString("N2");
                    Program.mainPage.weeklyrevenuetext.Text = "Estimated Weekly Revenue: $" + weeklyrevenue.ToString("N2");
                }));
            else
            {
                Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + highestvalue.ToString() + " H/s";
                Program.mainPage.averageHashrate.Text = "Total Hashrate: " + totalvalue.ToString() + " H/s";
                Program.mainPage.moneropricetext.Text = "Current Monero Value: $" + moneroprice.ToString("N2");
                Program.mainPage.weeklyrevenuetext.Text = "Estimated Weekly Revenue: $" + weeklyrevenue.ToString("N2");
            }
        }

        private void loop(object parameters)
        {
            while (state)
            {
                try
                {
                    highestvalue = Math.Round(Program.highestValues.Sum(), 1);
                    totalvalue = Math.Round(Program.totals.Sum(), 1);
                    List<double> monerodata = NetworkGatherer.getMoneroData(totalvalue);
                    moneroprice = Math.Round(monerodata[0], 2);
                    weeklyrevenue = Math.Round(monerodata[1], 2);

                    updateValues();
                    
                    if(Program.mainPage.delay == 1000)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(Program.mainPage.delay);
                    }
                    
                }
                catch (ThreadInterruptedException)
                {
                    if(Program.minerList.Count != minercount || Program.minerList.Count == 0)
                    {
                        minercount = Program.minerList.Count;
                        continue;
                    }
                    else
                    {
                        state = false;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                    break;
                }
                
            }
        }
    }
}
