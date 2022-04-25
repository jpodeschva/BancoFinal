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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            // Ir al Login Form
            Login login = new Login();
            login.Show();
        }

        private void registrarseMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: IR AL REGISTRO FORM
            Registro registro = new Registro();
            registro.Show();
        }
    }
}
