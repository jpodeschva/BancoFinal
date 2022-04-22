using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String username = textBox_username.Text;
            String password = textBox_password.Text;

            NLogin login = new NLogin();
            login.login(username, password);
        }
    }
}
