using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using System.Collections;

namespace CapaNegocio
{
    public class NAnuncios
    {
        CapaDatos.DAnuncios dAnuncios = new CapaDatos.DAnuncios();

        public ArrayList buscarSegunPalabra(String palabraBuscar)
        {
            if (palabraBuscar == "")
            {
                return mostrarTodosLosAnuncios();
            }
            else
            {
                return mostrarAnunciosPorLocalidad(palabraBuscar);
            }
        }

        public ArrayList mostrarTodosLosAnuncios()
        {
            return dAnuncios.listAnuncios();
        }

        public ArrayList mostrarAnunciosPorLocalidad(String localidad)
        {
            return dAnuncios.listAnunciosPorLocalidad(localidad);

            /*BancoDelTiempoEntities db = new BancoDelTiempoEntities();

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

            }).ToList();*/

            //dataGridAnuncio.ItemsSource = data.ToList();
        }

        public void eliminarAnuncio(int idSeleccion)
        {
            dAnuncios.deleteAnuncio(idSeleccion);
        }
    }
}
