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
    public class DCategoriaDeServicio
    {
        // Añadir categoría
        public void addCategoria(CategoriaDeServicio categoriaDeServicio)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.CategoriaDeServicios.Add(categoriaDeServicio);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Entrada duplicada en la Base de Datos. Esa Categoría ya existe." + ex.Message);
                return;
            }
            
        }

        // Eliminar categoría
        public void deleteCategoria(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id); // Si buscamos Categoria por su id

                db.CategoriaDeServicios.Remove(categoriaDeServicio);
                db.SaveChanges();

            }
        }

        // Actualizar categoría
        public void updateCategoria(CategoriaDeServicio categoriaDeServicio)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {


                db.Entry(categoriaDeServicio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar una categoría
        public CategoriaDeServicio getCategoria(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id);
                return categoriaDeServicio;
            }
        }


        // Mostrar todas las categorías
        public ArrayList listCategoriasDeServicio()
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.CategoriaDeServicios;
                foreach (var categoriaDeServicio in lst)
                {
                    //Console.WriteLine(categoriaDeServicio.ToString());
                    list.Add(categoriaDeServicio);
                }
            }

            return list;
        }


        // Comprobar si existe una categoría con un nombre dado
        public Boolean checkCategoria(String nombreCat)
        {
            bool existe = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.CategoriaDeServicios;
                foreach (var categoriaDeServicio in lst)
                {
                    if (categoriaDeServicio.nombreCategoria == nombreCat)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }


        // Mostrar todas las categorías que contengan una palabra en su descripción
        public ArrayList listCategoriasDeServicioQueContiene(String palabra)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.CategoriaDeServicios;
                foreach (var categoriaDeServicio in lst)
                {
                    if (categoriaDeServicio.descripcion.StartsWith(palabra, System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        //Console.WriteLine(categoriaDeServicio.ToString());
                        list.Add(categoriaDeServicio);
                    }
                }
            }

            return list;
        }


    }
}
