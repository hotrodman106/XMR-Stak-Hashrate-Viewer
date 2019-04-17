using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public class ValueUpdater
    {
        public bool state = true;
        public Thread thread;
        public int minercount = 0;

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
                    Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + Math.Round(Program.highestValues.Sum(), 1).ToString() + " H/s";
                    Program.mainPage.averageHashrate.Text = "Total Hashrate: " + Math.Round(Program.totals.Sum(), 1).ToString() + " H/s";
                }));
            else
            {
                Program.mainPage.highestHashrate.Text = "Highest Total Hashrate: " + Math.Round(Program.highestValues.Sum(), 1).ToString() + " H/s";
                Program.mainPage.averageHashrate.Text = "Total Hashrate: " + Math.Round(Program.totals.Sum(), 1).ToString() + " H/s";
            }
        }

        private void loop(object parameters)
        {
            while (state)
            {
                try
                {
                    updateValues();
                    Thread.Sleep(Program.mainPage.delay);

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
