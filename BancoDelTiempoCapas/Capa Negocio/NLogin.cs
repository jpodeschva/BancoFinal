using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaNegocio
{
    public class NLogin
    {
        String username;
        String password;

        public void login(String username, String password)
        {
            DUsuario user = new DUsuario();
            bool existe = user.checkUsuario(username);
            if (existe)
            {
                user.checkPassword(username, password);
            }
            else
            {
                MessageBox.Show("No existe ese usuario en la base de datos.");
            }
        }

    }
}
