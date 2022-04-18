using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DSugerencia
    {

        // Añadir sugerencia
        public void addSugerencia(Sugerencia sugerencia) { 
       

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Sugerencias.Add(sugerencia);
                db.SaveChanges();
            }
        }

        // Eliminar sugerencia
        public void deleteSugerencia(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Sugerencia sugerencia = db.Sugerencias.Find(id); // Si buscamos dugerencia por su id
                
                db.Sugerencias.Remove(sugerencia);
                db.SaveChanges();

            }
        }

        // Actualizar sugerencia
        public void updateSugerencia(Sugerencia sugerencia)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            { 

                db.Entry(sugerencia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar una sugerencia
        public Sugerencia getSugerencia(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Sugerencia sugerencia = db.Sugerencias.Find(id);
                return sugerencia;
            }
        }


        // Mostrar todas las sugerencias
        public ArrayList listSugerencias()
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Sugerencias;
                foreach (var sugerencia in lst)
                {
                    //Console.WriteLine(sugerencia.ToString());
                    list.Add(sugerencia);
                }
            }

            return list;
        }

        // Mostrar todas las sugerencias por usuario que la realiza
        public ArrayList listSugerenciasPorUsuario(int idUsuario)
        {
            ArrayList list = new ArrayList();

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

            return list;
        }

        // Mostrar todas las sugerencias por fecha
        public ArrayList listSugerenciasPorFecha(DateTime fecha)
        {
            ArrayList list = new ArrayList();

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

            return list;
        }

        // Mostrar todas las sugerencias que contengan una palabra en su descripción
        public ArrayList listSugerenciasQueContiene(String palabra)
        {
            ArrayList list = new ArrayList();

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

            return list;
        }

    }
}
