using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;
using System.Collections;
using System.ComponentModel;

namespace CapaNegocio
{
    public class NCategoriaDeServicio
    {
        CapaDatos.DCategoriaDeServicio dCategoriaDeServicio = new CapaDatos.DCategoriaDeServicio();

        public BindingList<CategoriaDeServicio> listarCategorias()
        {

            try
            {
                using (BancoDelTiempoEntities bd = new BancoDelTiempoEntities())
                {
                    var Query = (from n in bd.CategoriaDeServicios
                                 select new CategoriaDeServicio
                                 {

                                     idCategoria = n.idCategoria,
                                     nombreCategoria = n.nombreCategoria,
                                     descripcion = n.descripcion

                                 }).ToList();
                    BindingList<CategoriaDeServicio> Result = new BindingList<CategoriaDeServicio>(Query);
                    return Result;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public ArrayList buscarSegunPalabra(String palabra)
        {
            if (palabra == "")
            {
                return mostrarTodasLasCategorias();
            }
            else
            {
                return mostrarCategoriaPorNombre(palabra);
            }
        }
        public ArrayList mostrarTodasLasCategorias()
        {
            return dCategoriaDeServicio.listCategoriasDeServicio();
        }

        public ArrayList mostrarCategoriaPorNombre(String palabra)
        {
            return dCategoriaDeServicio.listCategoriasDeServicioQueContiene(palabra);
        }
        }
}
