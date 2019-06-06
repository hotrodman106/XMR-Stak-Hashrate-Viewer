using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;
using System.Threading;
using MetroFramework;

namespace XMR_Stak_Hashrate_Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static string appGuid = "c0a76b5a-12ab-45c5-b9d9-d693faa6e7b9";
        public static MainPage mainPage;
        public static List<MinerObject> minerList = new List<MinerObject>();
        public static List<float> totals = new List<float>();
        public static List<float> highestValues = new List<float>();
        public static Assembly assembly = Assembly.GetCallingAssembly();
        public static Mutex mutex;
        [STAThread]
        static void Main()
        {
            using (mutex = new Mutex(false, "Global\\" + appGuid))
            {
                
                if (!mutex.WaitOne(0, false))
                {
                    MetroMessageBox.Show(mainPage,"Cannot run more than one instance! Please close all other instances first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                mainPage = new MainPage();
                Application.Run(mainPage);
            }
        }
        }
    }