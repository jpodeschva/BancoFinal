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
        
        public bool login(String username, String password)
        {
            DUsuario user = new DUsuario();
            bool correcto = false;
            bool existe = user.checkUsuario(username);
            if (existe)
            {
                correcto = user.checkPassword(username, password);
                if (correcto)
                {
                    //login ok
                    return true;
                }
                else
                {
                    // login fallido
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
