using CapaNegocio;
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
        public Anuncio()
        {
            InitializeComponent();
            bindDataGrid();
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void bindDataGrid()
        {
            NAnuncios anuncios = new NAnuncios();
            anuncios.mostrarTodosLosAnuncios();
        }
    }
}
