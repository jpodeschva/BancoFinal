using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NCategoriaDeServicio
    {


        public List<CategoriaDeServicio> listarCategorias()
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

                    return Query;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
