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
                    MessageBox.Show("¡Enhorabuena! Se ha introducido la categoria.\n\n");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Entrada duplicada en la Base de Datos. Esa Categoría ya existe.\n\n" + ex.Message);
                return;
            }
            
        }

        // Eliminar categoría
        public void deleteCategoria(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id); // Si buscamos Categoria por su id

                    db.CategoriaDeServicios.Remove(categoriaDeServicio);
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar Categoría.\n\n" + ex.Message);
                return;
            }
            
        }

        // Actualizar categoría
        public void updateCategoria(CategoriaDeServicio categoriaDeServicio)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.Entry(categoriaDeServicio).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar la Categoría.\n\n" + ex.Message);
                return;
            }
            
        }

        public ArrayList listCategoriaPorNombre(string nombreCategoria)
        {
            throw new NotImplementedException();
        }

 

        // Mostrar una categoría
        public CategoriaDeServicio getCategoria(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id);
                    return categoriaDeServicio;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Categoría no encontrada.\n\n" + ex.Message);
                return null;
            }
        }


        // Mostrar todas las categorías
        public ArrayList listCategoriasDeServicio()
        {
            ArrayList list = new ArrayList();
            try {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.CategoriaDeServicios;
                    foreach (var categoriaDeServicio in lst)
                    {
                        //Console.WriteLine(categoriaDeServicio.ToString());
                        list.Add(categoriaDeServicio);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay categorias por mostrar. \n\n" + ex.Message);
                return null;
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
                   if (categoriaDeServicio.nombreCategoria.Contains(palabra))
                    {
                        //Console.WriteLine(anuncio.ToString());
                        list.Add(categoriaDeServicio);
                    }
                }
            }

            return list;
        }


    }
}
