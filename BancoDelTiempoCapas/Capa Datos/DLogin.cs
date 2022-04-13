using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;

namespace CapaDatos
{
    public class DLogin
    {

        // Comprobar si existe usuario en la BD con un username dado
        public Boolean checkUsuario(String username)
        {
            bool existe = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Usuarios;
                foreach (var usuario in lst)
                {
                    if (usuario.idUsername == username)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }

    }
}
