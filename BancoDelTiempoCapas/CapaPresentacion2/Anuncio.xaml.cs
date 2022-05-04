using CapaNegocio;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;

namespace CapaPresentacion2
{
    public partial class Anuncio : Page
    {
        String palabraBuscar;
        NAnuncios nAnuncios;

        public Anuncio()
        {
            InitializeComponent();
            nAnuncios = new NAnuncios();

            // TODO: Cargar imagen o texto ¿¿¿¿¿¿¿¿¿¿??????????????
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            palabraBuscar = textBoxBuscar.textBox.Text;  // Coge la palabra que el usuario escribe en el TextBox
            //MessageBox.Show(palabraBuscar);

            // Llama al método que analiza la palabra (en CapaNegocio) y lo asigna al DataGridView
            dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);  



            //nAnuncios.mostrarTodosLosAnuncios();

            // Se asigna la palabra que el usuario busca a una variable
            /*palabraBuscar = (string)textBoxBuscar.Hint;

            if (palabraBuscar == null)
            {
                bindDataGrid();
            }
            else
            {
                // TODO: Buscar anuncios según la palabra

                // Pruebas buscar por localidad
                //nAnuncios.mostrarAnunciosPorLocalidad(palabraBuscar);
                BancoDelTiempoEntities db = new BancoDelTiempoEntities();

                // Para mostrar todos los campos de la tabla
                //var data = from d in db.Anuncios select d;

                // Para mostrar sólo determinados campos de la tabla
                var data = db.Anuncios
                .Where(x => x.localidad == palabraBuscar)  // Para buscar por alguna propiedad
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
            }*/
        }

        // Muestra todos los anuncios de la base de datos
        private void bindDataGrid()
        {
            BancoDelTiempoEntities db = new BancoDelTiempoEntities();

            // Para mostrar todos los campos de la tabla
            //var data = from d in db.Anuncios select d;

            // Para mostrar sólo determinados campos de la tabla
            var data = db.Anuncios
            //.Where(x => x.idCategoria == 1 && x.localidad == "Madrid")  // Para buscar por alguna propiedad
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
