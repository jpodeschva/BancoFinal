using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NRegistro

    {
        CapaDatos.Usuario nuevoUsuario;
        CapaDatos.DUsuario dUsuario = new CapaDatos.DUsuario();

        public void guardaRegistro(String nombre, String apellido1, String apellido2, String direccion, String localidad,
                String provincia, String email, String username, String password, int codigoPostal, int telefono)
        {
            // Creamos el nuevo usuario con los datos introducidos
            nuevoUsuario = new CapaDatos.Usuario(nombre, apellido1, apellido2, direccion, localidad, provincia, email,
                username, password, codigoPostal, telefono);

            // Llamamos al método addUsuario() de DUsuario (CapaDatos) y le pasamos el usuario creado
            dUsuario.addUsuario(nuevoUsuario);
        }

        public void actualizaRegistro(String nombre, String apellido1, String apellido2, String direccion, String localidad,
                String provincia, String email, String username, String password, int codigoPostal, int telefono)
        {
            // Recuperamos el usuario a partir de su username
            nuevoUsuario = dUsuario.getUsuarioByUsername(username);

            // Creamos el nuevo usuario con los datos introducidos
            nuevoUsuario = new CapaDatos.Usuario(nombre, apellido1, apellido2, direccion, localidad, provincia, email,
                username, password, codigoPostal, telefono);

            // Llamamos al método updateUsuario() de DUsuario (CapaDatos) y le pasamos el usuario a modificar
            dUsuario.updateUsuario(username, nuevoUsuario);
        }

        public bool comprobarUsername(string username)
        {
            return dUsuario.checkUsuario(username);
        }
    }
}
