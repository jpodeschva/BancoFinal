using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using System.Collections;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace CapaDatos
{

    public class DUsuario
    {
      

        // Añadir usuario
        public void addUsuario(Usuario usuario)
        {
            //Usuario usuario = new Usuario();

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.Usuarios.Add(usuario);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Usuario añadido correctamente.");
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar registrar al usuario.\n\n" + ex.Message);
                return;
            }

            
        }

        // Eliminar usuario
        public void deleteUsuario(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    Usuario usuario = db.Usuarios.Find(id); // Si buscamos al usuario por su id
                                                            //Usuario usuario = db.Usuarios.Where(u => u.email == usuario.email); // Si queremos buscar por email
                    db.Usuarios.Remove(usuario);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar Usuario.\n\n" + ex.Message);
                return;
            }
            
        }

        // Actualizar usuario
        public void updateUsuario(String username, Usuario usuarioActualizado)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    //Usuario usuario = db.Usuarios.Find(id);
                    Usuario usuario = getUsuarioByUsername(username);

                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;

                    // Modificamos los parámetros
                    usuario.nombre = usuarioActualizado.nombre;
                    usuario.apellido1 = usuarioActualizado.apellido1;
                    usuario.apellido2 = usuarioActualizado.apellido2;
                    usuario.direccion = usuarioActualizado.direccion;
                    usuario.codigoPostal = usuarioActualizado.codigoPostal;
                    usuario.localidad = usuarioActualizado.localidad;
                    usuario.provincia = usuarioActualizado.provincia;
                    usuario.email = usuarioActualizado.email;
                    usuario.telefono = usuarioActualizado.telefono;
                    usuario.idUsername = usuarioActualizado.idUsername;
                    usuario.idPassword = usuarioActualizado.idPassword;

                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    MessageBox.Show("Usuario actualizado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar el Usuario.\n\n" + ex.Message);
                return;
            }
            
        }

        // Mostrar un usuario
        public Usuario getUsuario(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    Usuario usuario = db.Usuarios.Find(id);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Categoría no encontrada.\n\n" + ex.Message);
                return null;
            }
            
        }

        // Buscar un usuario por su username
        public Usuario getUsuarioByUsername(String username)
        {
            Usuario usuarioEncontrado = null;

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Usuarios;
                    foreach (var usuario in lst)
                    {
                        if (usuario.idUsername == username)
                        {
                            usuarioEncontrado = usuario;
                        }
                    }
                    return usuarioEncontrado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario no encontrado.\n\n" + ex.Message);
                return null;
            }

        }


        // Mostrar todos los usuarios
        public ArrayList listUsuarios()
        {
            ArrayList list = new ArrayList();


            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Usuarios;
                foreach (var usuario in lst)
                {
                    //Console.WriteLine(usuario.ToString());
                    list.Add(usuario);
                }
            }

            return list;
        }


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


        // Comprobar password de un usuario dado
        public Boolean checkPassword(String username, String password)
        {
            bool correcto = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Usuarios;
                foreach (var usuario in lst)
                {
                    if (usuario.idUsername == username)
                    {
                        if (usuario.idPassword == password)
                        {
                            correcto = true;
                        }
                    }
                }
            }
            return correcto;
        }


        /*public DataTable MostrarClientes() {
            DConexion dc = new DConexion();
            dc.pruebaConexion();

            SqlDataAdapter da = new SqlDataAdapter("SP_MOSTRARUSUARIOS", DConexion.conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        
        }*/
        


    }
}
