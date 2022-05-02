using CapaNegocio;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace CapaPresentacion2
{
    /// <summary>
    /// Lógica de interacción para Anuncio.xaml
    /// </summary>
    public partial class Anuncio : Page
    {
        DataGrid dataGrid;
        public Anuncio()
        {
            InitializeComponent();
            
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            bindDataGrid();
            //setUpGrid();
        }

        /*private void setUpGrid()
        {
            CapaDatos.BancoDelTiempoEntities context = new CapaDatos.BancoDelTiempoEntities();
            dataGrid = new DataGrid();
            context.Anuncios.ToList();
            this.DataContext = context.Anuncios.Local;  // set the Window DataContext property
        }*/

        private void bindDataGrid()
        {
            NAnuncios anuncios = new NAnuncios();
            anuncios.mostrarTodosLosAnuncios();
        }


    }
}
