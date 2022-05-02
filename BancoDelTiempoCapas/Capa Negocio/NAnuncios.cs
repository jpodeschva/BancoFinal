using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;


namespace CapaNegocio
{
    public class NAnuncios
    {
        CapaDatos.DAnuncios anuncios = new CapaDatos.DAnuncios();

        public void mostrarTodosLosAnuncios()
        {
            anuncios.listAnuncios();
        }

        public void mostrarAnunciosPorLocalidad(String localidad)
        {
            BancoDelTiempoEntities db = new BancoDelTiempoEntities();

            // Para mostrar todos los campos de la tabla
            //var data = from d in db.Anuncios select d;

            // Para mostrar sólo determinados campos de la tabla
            var data = db.Anuncios
            .Where(x => x.localidad == localidad)  // Para buscar por alguna propiedad
            .Select(x => new
            {
                IdAnuncio = x.idAnuncio,
                TipoDeServicio = x.tipoServicio,
                Descripcion = x.descripcion,
                FechaDePublicacion = x.fechaPublicacion,
                Localidad = x.localidad,
                IdCategoria = x.idCategoria,
                IdUsuario = x.idUsuario

            }).ToList();

            dataGridAnuncio.ItemsSource = data.ToList();
        }
   
    }
}
