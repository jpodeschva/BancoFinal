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

namespace CapaPresentacion2
{
    public partial class Anuncio : Page
    {
        public Anuncio()
        {
            InitializeComponent();
            bindDataGrid();
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        // Muestra todos los anuncios de la base de datos al entrar a Anuncio
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
