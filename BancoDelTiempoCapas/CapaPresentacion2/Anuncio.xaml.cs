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
        NAnuncios nAnuncios;

        String palabraBuscar;

        CapaDatos.Anuncio anuncioSeleccionado;
        int idSeleccion;

        public Anuncio()
        {
            InitializeComponent();
            nAnuncios = new NAnuncios();
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            palabraBuscar = textBoxBuscar.textBox.Text;  // Coge la palabra que el usuario escribe en el TextBox
            //MessageBox.Show(palabraBuscar);

            // Llama al método que analiza la palabra (en CapaNegocio) y lo asigna al DataGridView
            dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);  

        }

        private void addAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            anuncioSeleccionado = (CapaDatos.Anuncio)dataGridAnuncio.SelectedItem;
            idSeleccion = anuncioSeleccionado.idAnuncio;
            // Llama al método de la CapaNegocio que pasará la orden de eliminar el anuncio
            nAnuncios.eliminarAnuncio(idSeleccion);
            // Llama al método que vuelve a listar todos los anuncios
            dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);
        }


        // Muestra todos los anuncios de la base de datos
        /*private void bindDataGrid()
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
        }*/

    }
}
