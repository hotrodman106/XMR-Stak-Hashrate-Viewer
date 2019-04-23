using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;

namespace XMR_Stak_Hashrate_Viewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static MainPage mainPage;
        public static List<MinerObject> minerList = new List<MinerObject>();
        public static List<float> totals = new List<float>();
        public static List<float> highestValues = new List<float>();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //mainPage = new MainPage();
            //Application.Run(mainPage);
            Application.Run(new Form4());

        }

        static void ListEmbeddedResourceNames()
        {
            Trace.WriteLine("Listing Embedded Resource Names");

            foreach (var resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
                Trace.WriteLine("Resource: " + resource);
        }




    }
 }