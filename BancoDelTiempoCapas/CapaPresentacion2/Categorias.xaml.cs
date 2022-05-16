using CapaDatos;
using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CapaPresentacion2
{
    /// <summary>
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Page
    {
        NCategoriaDeServicio nCategoria;
        BancoDelTiempoEntities bancoDB = new BancoDelTiempoEntities();
        String buscar, nombre, descripcion;

        CapaDatos.CategoriaDeServicio categoriaSeleccionada;
        int idSelCategoria;
        
        public Categorias()
        {
            InitializeComponent();
            nCategoria = new NCategoriaDeServicio();
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            buscar = txtBuscar.Text;

            dataGridCategorias.ItemsSource = nCategoria.buscarSegunPalabra(buscar);
        }

        private void btnAñadir_Click(object sender, RoutedEventArgs e)
        {
            nombre = txtNombre.Text;
            descripcion = txtDescripcion.Text;

            nCategoria.guardarCategoria(nombre, descripcion);

        }

        private void txtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {

        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
           

        }
    }
}
