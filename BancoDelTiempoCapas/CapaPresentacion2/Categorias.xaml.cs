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
        NCategoriaDeServicio nCategoria = new NCategoriaDeServicio();
        BancoDelTiempoEntities bancoDB = new BancoDelTiempoEntities();
        String buscar;

        CapaDatos.CategoriaDeServicio categoriaSeleccionada;
        int idSelCategoria;
        
        public Categorias()
        {
            InitializeComponent();
            nCategoria = new NCategoriaDeServicio();
            
        }

        
        private void Buscar_TextChanged(object sender, TextChangedEventArgs e)
        {



        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Buscar.DataContext = nCategoria.listarCategorias();

        }
    }
}
