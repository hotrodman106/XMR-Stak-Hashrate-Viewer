using MetroFramework.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class AddMinerScreen : MetroForm
    {
        private NetworkGatherer networkGatherer = new NetworkGatherer();
        public AddMinerScreen()
        {
            InitializeComponent();
            ActiveControl = ipaddresstextbox;
        }
        private void addminerbutton_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri;
                string url = ipaddresstextbox.Text;
                if (url.Contains("http://"))
                {
                    uri = new Uri(url);
                }
                else
                {
                    uri = new Uri("http://" + url);
                }

                if (minerExists(uri.Authority) == true)
                {
                    MessageBox.Show("Miner already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Miner already exists!");
                }
                else
                {
                    Visible = false;
                    MinerObject miner = new MinerObject(uri, null, null);
                    if (miner.isInitialized)
                        {
                            Program.minerList.Add(miner);
                            miner.startLoop();
                        
                        Dispose();
                    }
                    else
                    {
                        Dispose();
                    }
                }
                Dispose();
            }
            catch (Exception ex)
            {
                if (ex is ThreadAbortException != true)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex.Message);
                }
            }


        }


        private bool minerExists(string name)
        {
            foreach (MinerObject miner in Program.minerList)
            {
                if (miner.name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
