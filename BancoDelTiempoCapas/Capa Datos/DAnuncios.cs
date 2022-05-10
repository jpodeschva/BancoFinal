using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

//ponemos las librerias necesarias
using System.Data;
using System.Data.SqlClient;

//enlazamos con CapaEntidades
using CapaEntidades;
using System.Collections;
using System.Windows.Forms;
using System.Data.Entity.Validation;

namespace CapaDatos
{


    public class DAnuncios
    {
        // Añadir anuncio
        public void addAnuncio(Anuncio anuncio)
        {

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.Anuncios.Add(anuncio);
                    try
                    {
                        db.SaveChanges();
                        MessageBox.Show("Anuncio añadido correctamente.");
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
                MessageBox.Show("No se ha podido añadir el anuncio. \n\n" + ex.Message);
                return;
            }
        }

        // Eliminar anuncio
        public void deleteAnuncio(int id)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Anuncio anuncio = db.Anuncios.Find(id); // Si buscamos el anuncio por su id

                db.Anuncios.Remove(anuncio);
                db.SaveChanges();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido borrar el anuncio. \n\n" + ex.Message);
                return;
            }
        }

        // Actualizar anuncio
        public void updateAnuncio(Anuncio anuncio)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {


                db.Entry(anuncio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar el anuncio. \n\n" + ex.Message);
                return;
            }
        }

        // Mostrar un anuncio
        public Anuncio getAnuncio(int id)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Anuncio anuncio = db.Anuncios.Find(id);
                return anuncio;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar el anuncio. \n\n" + ex.Message);
                return null;
            }
        }


        // Mostrar todos los anuncios
        public ArrayList listAnuncios()
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    //Console.WriteLine(anuncio.ToString());
                    list.Add(anuncio);
                }
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("No hay anuncios por mostrar. \n\n" + ex.Message);
                return null;
            }

            return list;
        }


        // Mostrar todos los anuncios de una categoría concreta
        public ArrayList listAnunciosPorCategoria(int idCategoria)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    if (anuncio.idCategoria.Equals(idCategoria))
                    {
                        //Console.WriteLine(anuncio.ToString());
                        list.Add(anuncio);
                    }
                    
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar el anuncio por esta categoria. \n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todos los anuncios de una localidad concreta
        public ArrayList listAnunciosPorLocalidad(String localidad)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    if (anuncio.localidad.Equals(localidad))
                    {
                        //Console.WriteLine(anuncio.ToString());
                        list.Add(anuncio);
                    }

                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay anuncios por mostrar. \n\n" + ex.Message);
                return null;
            }
            return list;
        }

        // Mostrar todos los anuncios de un usuario concreto
        public ArrayList listAnunciosPorUsuario(int idUsuario)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    if (anuncio.idUsuario == idUsuario)
                    {
                        //Console.WriteLine(anuncio.ToString());
                        list.Add(anuncio);
                    }

                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar anuncios. \n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Comprobar si existe un anuncio en la BD con la id dada
        public Boolean checkAnuncio(int idAnuncio)
        {
            bool existe = false;
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    if (anuncio.idAnuncio == idAnuncio)
                    {
                        existe = true;
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar anuncio con su id. \n\n" + ex.Message);
                return false;
            }
            return existe;
        }

        // Mostrar todos los anuncios dentro de unas fechas determinadas
        public ArrayList listAnunciosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Anuncios;
                foreach (var anuncio in lst)
                {
                    if (anuncio.fechaPublicacion > fechaInicio && anuncio.fechaPublicacion < fechaFin)
                    {
                        //Console.WriteLine(anuncio.ToString());
                        list.Add(anuncio);
                    }

                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido mostrar el anuncio por estas fechas. \n\n" + ex.Message);
                return null;
            }

            return list;
        }


        /*
        public class DAnuncios
        {
            //creamos un metodo tipo string para insertar anuncios
            //tiene 3 parametros. 1 Entidad. 2 referenciamos cadena de conexion. 3 refenciamos transaccion de sql
            public string PublicarAnuncios(EAnuncios anuncios, ref SqlConnection conexion, ref SqlTransaction transaccion)
            {
                //variable de tipo string para recibir respuesta
                string respuesta;

                try
                {
                    //instanciamos command con nombre de procedimiento almacenado
                    SqlCommand comando = new SqlCommand("spinsertar_anuncios", conexion)
                    {
                        //tipo de comando procedimiento almacenado
                        CommandType = CommandType.StoredProcedure,
                        //enviamos la transaccion
                        Transaction = transaccion

                    };

                    //añadimos valores a los parametros para luego enviar
                    comando.Parameters.AddWithValue("@idAnuncio", anuncios.idAnuncio);
                    comando.Parameters.AddWithValue("@descripcion", anuncios.descripcion);
                    comando.Parameters.AddWithValue("@fechaPublicacion", anuncios.fechaPublicacion);
                    comando.Parameters.AddWithValue("@tipoServicio", anuncios.tipoServicio);
                    comando.Parameters.AddWithValue("@localidad", anuncios.localidad);
                    comando.Parameters.AddWithValue("@idUsuario", anuncios.idUsuario);
                    comando.Parameters.AddWithValue("@idCategoria", anuncios.idCategoria);

                    //ejecutamos comando en la variable respuesta
                    respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el anuncio";
                }
                catch (Exception ex) {

                    respuesta = ex.Message;

                }
                return respuesta;
            }
        }*/
    }
}