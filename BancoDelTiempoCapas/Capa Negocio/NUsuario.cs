using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class NUsuario
    {
        DUsuario dUsuario = new DUsuario();
        Usuario usuarioEncontrado;

        public Usuario cargarCuentaUsuario(String username)
        {
            // Recupera los datos del usuario de la base de datos
            usuarioEncontrado = dUsuario.getUsuarioByUsername(username);
            return usuarioEncontrado;
        }
    }


}
