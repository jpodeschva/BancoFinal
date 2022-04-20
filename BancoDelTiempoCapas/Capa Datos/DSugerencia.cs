using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DSugerencia
    {

        // Añadir sugerencia
        public void addSugerencia(Sugerencia sugerencia) {

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.Sugerencias.Add(sugerencia);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido agregar la sugerencia.\n\n" + ex.Message);
                return;
            }
        }

        // Eliminar sugerencia
        public void deleteSugerencia(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    Sugerencia sugerencia = db.Sugerencias.Find(id); // Si buscamos dugerencia por su id

                    db.Sugerencias.Remove(sugerencia);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido eliminar la sugerencia.\n\n" + ex.Message);
                return;
            }
        }

        // Actualizar sugerencia
        public void updateSugerencia(Sugerencia sugerencia)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {

                    db.Entry(sugerencia).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La sugerencia no se ha actualizado.\n\n" + ex.Message);
                return;
            }
        }

        // Mostrar una sugerencia
        public Sugerencia getSugerencia(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    Sugerencia sugerencia = db.Sugerencias.Find(id);
                    return sugerencia;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha encontrado ninguna sugerencia con esta id.\n\n" + ex.Message);
                return null;
            }
        }


        // Mostrar todas las sugerencias
        public ArrayList listSugerencias()
        {
            ArrayList list = new ArrayList();

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Sugerencias;
                    foreach (var sugerencia in lst)
                    {
                        //Console.WriteLine(sugerencia.ToString());
                        list.Add(sugerencia);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("no hay sugerencias.\n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todas las sugerencias por usuario que la realiza
        public ArrayList listSugerenciasPorUsuario(int idUsuario)
        {
            ArrayList list = new ArrayList();
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Sugerencias;
                    foreach (var sugerencia in lst)
                    {
                        if (sugerencia.idUsuario == idUsuario)
                        {
                            //Console.WriteLine(sugerencia.ToString());
                            list.Add(sugerencia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen sugerencias para este usuario.\n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todas las sugerencias por fecha
        public ArrayList listSugerenciasPorFecha(DateTime fecha)
        {
            ArrayList list = new ArrayList();

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Sugerencias;
                    foreach (var sugerencia in lst)
                    {
                        if (sugerencia.fechaHora == fecha)
                        {
                            //Console.WriteLine(sugerencia.ToString());
                            list.Add(sugerencia);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("No hay sugerencias en estas fechas.\n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todas las sugerencias que contengan una palabra en su descripción
        public ArrayList listSugerenciasQueContiene(String palabra)
        {
            ArrayList list = new ArrayList();

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Sugerencias;
                    foreach (var sugerencia in lst)
                    {
                        if (sugerencia.descripcion.StartsWith(palabra, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Console.WriteLine(sugerencia.ToString());
                            list.Add(sugerencia);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay sugerencias con esta palabra.\n\n" + ex.Message);
                return null;
            }

            return list;
        }

    }
}
