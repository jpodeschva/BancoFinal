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
        CapaDatos.DUsuario dUsuario = new CapaDatos.DUsuario();

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

        public int getIdUsuarioFromUsername()
        {
            Usuario usuario = dUsuario.getUsuarioByUsername(SessionManager.Instance.username);
            int idUsuario = usuario.idUsuario;
            return idUsuario;

        }

        public void addAnuncio(String tipoServicio, String descripcion, String localidad, int idCategoria, int idUsuario, DateTime fecha)
        {
            // Crea un nuevo objeto de tipo anuncio
            CapaDatos.Anuncio nuevoAnuncio = new CapaDatos.Anuncio();
            // Le añade los atributos
            nuevoAnuncio.tipoServicio = tipoServicio;
            nuevoAnuncio.descripcion = descripcion;
            nuevoAnuncio.localidad = localidad;
            nuevoAnuncio.idCategoria = idCategoria;
            nuevoAnuncio.idUsuario = idUsuario;
            nuevoAnuncio.fechaPublicacion = fecha;
            // Le asigna también el idUsuario sacado de SessionManager
            nuevoAnuncio.idUsuario = getIdUsuarioFromUsername();

            // Llama al método de la CapaDatos que añadirá el anuncio a la base de datos
            dAnuncios.addAnuncio(nuevoAnuncio);
        }

        public void eliminarAnuncio(int idSeleccion)
        {
            dAnuncios.deleteAnuncio(idSeleccion);
        }

        public ArrayList buscarAnuncioPorId(int idAnuncio)
        {
            ArrayList lista = new ArrayList();
            Anuncio anuncio = dAnuncios.getAnuncio(idAnuncio);
            lista.Add(anuncio);
            return lista;
        }
    }
}
