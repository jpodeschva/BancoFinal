using CapaDatos;
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
    public partial class CuentaUsuario : Page
    {
        bool isLoggedIn = false;
        NUsuario nUsuario;
        Usuario usuario;

        public CuentaUsuario(bool isLoggedIn, String username)
        {
            InitializeComponent();
            
            nUsuario = new NUsuario();

            if (isLoggedIn)
            {
                // Busca al usuario logueado por su username
                usuario = nUsuario.cargarCuentaUsuario(username);

                // Carga todos los datos del usuario en la pantalla
                boxNombre.Text = usuario.nombre;
                boxApellido1.Text = usuario.apellido1;
                boxApellido2.Text = usuario.apellido2;
                boxDireccion.Text = usuario.direccion;
                boxCP.Text = usuario.codigoPostal.ToString();
                boxLocalidad.Text = usuario.localidad;
                boxProvincia.Text = usuario.provincia;
                boxEmail.Text = usuario.email;
                boxTelefono.Text = usuario.telefono.ToString();
                boxUsername.Text = usuario.idUsername;
                boxPassword.Text = usuario.idPassword;
            }
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
