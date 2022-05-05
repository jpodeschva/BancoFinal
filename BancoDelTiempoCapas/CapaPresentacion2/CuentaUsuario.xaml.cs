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
    public partial class CuentaUsuario : Page
    {
        //MainWindow main;
        public CuentaUsuario()
        {
            InitializeComponent();
            //main = new MainWindow();
        }

        // Botón Editar cuenta
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Carga la vista de Registro
            this.NavigationService.Navigate(new Uri("Registro.xaml", UriKind.Relative));

            //TODO: Carga los datos en los TextBox ?? O se crea página nueva?
        }

        // Botón Eliminar cuenta
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Elimina Usuario de la base de datos
        }
    }
}
