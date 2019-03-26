using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class Login : Form
    {
        public string username;
        public string password;

        public Login()
        {
            InitializeComponent();
            ActiveControl = usernameTextbox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = usernameTextbox.Text;
            password = passwordTextBox.Text;
            if (username.Equals(""))
            {
                MessageBox.Show("Username cannot be left blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Username cannot be left blank!");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Password cannot be left blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Password cannot be left blank!");
            }
            else
            {
                Visible = false;
            }


        }
    }
}
