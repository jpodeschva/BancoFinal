using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CapaDatos
{
    public class DCategoriaDeServicio
    {

        public void addCategoria(CategoriaDeServicio categoriaDeServicio)
        {


            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.CategoriaDeServicios.Add(categoriaDeServicio);
                db.SaveChanges();
            }
        }

        // Eliminar usuario
        public void deleteCategoria(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id); // Si buscamos Categoria por su id

                db.CategoriaDeServicios.Remove(categoriaDeServicio);
                db.SaveChanges();

            }
        }

        // Actualizar Categoria
        public void updateCategoria(CategoriaDeServicio categoriaDeServicio)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {


                db.Entry(categoriaDeServicio).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar una categoria
        public CategoriaDeServicio getCategoria(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                CategoriaDeServicio categoriaDeServicio = db.CategoriaDeServicios.Find(id);
                return categoriaDeServicio;
            }
        }


        // Mostrar todas las categorias
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


        // Comprobar si existe usuario en la BD con un username dado
        public Boolean checkCategoria(int categoria)
        {
            bool existe = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.CategoriaDeServicios;
                foreach (var categoriaDeServicio in lst)
                {
                    if (categoriaDeServicio.idCategoria == categoria)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }


  


    }
}
