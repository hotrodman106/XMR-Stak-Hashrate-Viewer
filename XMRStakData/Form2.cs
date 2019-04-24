using System;
using System.Threading;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class Settings : Form
    {

        public Settings()
        {
            InitializeComponent();
            ActiveControl = textBox1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            try
            {
                Uri uri;
                string url = textBox1.Text;
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
                    MinerObject miner = new MinerObject(uri, null, null);
                    if (miner.isInitialized)
                    {
                        Program.minerList.Add(miner);
                        miner.startLoop();
                        //Form4.background.thread.Interrupt();
                    }
                }
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
