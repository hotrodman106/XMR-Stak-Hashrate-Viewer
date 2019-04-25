using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace XMR_Stak_Hashrate_Viewer
{
    public partial class LoginScreen : MetroForm
    {
        public string username;
        public string password;

        public LoginScreen()
        {
            InitializeComponent();
            ActiveControl = usernametextbox;
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            username = usernametextbox.Text;
            password = passwordtextbox.Text;
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
                Dispose();
            }


        }
    }
}
