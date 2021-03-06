using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DRegistro
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
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido registrar el usuario.\n\n" + ex.Message);
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
                MessageBox.Show("No se ha podido eliminar el registro.\n\n" + ex.Message);
                return;
            }
        }

        // Actualizar usuario
        public void updateUsuario(Usuario usuario)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    //Usuario usuario = db.Usuarios.Find(id);

                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El registro no se ha actualizado.\n\n" + ex.Message);
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
                MessageBox.Show("No se puede mostrar el usuario.\n\n" + ex.Message);
                return null;
            }
        }


        // Mostrar todos los usuarios
        public ArrayList listUsuarios()
        {
            ArrayList list = new ArrayList();
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Usuarios;
                    foreach (var usuario in lst)
                    {
                        //Console.WriteLine(usuario.ToString());
                        list.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay usuarios por mostrar.\n\n" + ex.Message);
                return null;
            }

            return list;
        }


        // Comprobar si existe usuario en la BD con un username dado
        public Boolean checkUsuario(String username)
        {
            bool existe = false;
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("no existe el usuario.\n\n" + ex.Message);
                return false;
            }
            return existe;
        }


        // Comprobar password de un usuario dado
        public Boolean checkPassword(String username, String password)
        {
            bool correcto = false;
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(" No hemos podido comprobar la contraseña.\n\n" + ex.Message);
                return false;
            }

            return correcto;
        }



    }
}
