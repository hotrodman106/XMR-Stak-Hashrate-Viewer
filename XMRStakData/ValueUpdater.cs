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
        private NetworkGatherer networkGatherer = new NetworkGatherer();
        private int errorcount = 0;

        public ValueUpdater()
        {
            thread = new Thread(new ParameterizedThreadStart(loop));
            thread.Start();
        }
        private void updateValues()
        {
            try
            {
                Program.mainPage.Invoke(new MethodInvoker(delegate ()
                {
                    Program.mainPage.highesthashratelabel.Text = highestvalue.ToString() + " H/s";
                    Program.mainPage.totalhashratelabel.Text = totalvalue.ToString() + " H/s";
                    Program.mainPage.monerovaluelabel.Text = "$" + moneroprice.ToString("N2");
                    Program.mainPage.weeklyrevenuelabel.Text = "$" + weeklyrevenue.ToString("N2");
                }));
                errorcount = 0;
            }
            catch (InvalidOperationException)
            {
                if(errorcount < 3)
                {
                    errorcount++;
                }
                else
                {
                    thread.Abort();
                }
                
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
                    List<double> monerodata = networkGatherer.getMoneroData(totalvalue, 3);
                    moneroprice = Math.Round(monerodata[0], 2);
                    weeklyrevenue = Math.Round(monerodata[1], 2);

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
                catch (InvalidOperationException)
                {
                    continue;
                }catch (ThreadAbortException)
                {
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
    }
}
