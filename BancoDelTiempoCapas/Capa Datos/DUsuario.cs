using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using System.Collections;


namespace CapaDatos
{

    public class DUsuario
    {
      

        // Añadir usuario
        public void addUsuario(Usuario usuario)
        {
            //Usuario usuario = new Usuario();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        // Eliminar usuario
        public void deleteUsuario(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Usuario usuario = db.Usuarios.Find(id); // Si buscamos al usuario por su id
                //Usuario usuario = db.Usuarios.Where(u => u.email == usuario.email); // Si queremos buscar por email
                db.Usuarios.Remove(usuario);
                db.SaveChanges();

            }
        }

        // Actualizar usuario
        public void updateUsuario(Usuario usuario)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                //Usuario usuario = db.Usuarios.Find(id);

                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar un usuario
        public Usuario getUsuario(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Usuario usuario = db.Usuarios.Find(id);
                return usuario;
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


        public DataTable MostrarClientes() {
            DConexion dc = new DConexion();
            dc.pruebaConexion();

            SqlDataAdapter da = new SqlDataAdapter("SP_MOSTRARUSUARIOS", DConexion.conexion.ToString());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        
        }
        


    }
}
