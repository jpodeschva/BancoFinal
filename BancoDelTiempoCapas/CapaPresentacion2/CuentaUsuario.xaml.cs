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
        bool isLoggedIn;
        String username = "";
        NUsuario nUsuario;
        Usuario usuario;

        public CuentaUsuario()
        {
            InitializeComponent();

            nUsuario = new NUsuario();
            usuario = new Usuario();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.username = SessionManager.Instance.username;
            this.isLoggedIn = SessionManager.Instance.isLoggedIn;
            //MessageBox.Show("Loaded");
            loadUsuario(isLoggedIn, username);
        }

        private void loadUsuario(bool isLoggedIn, string username)
        {
            if (isLoggedIn)
            {
                // Busca al usuario logueado por su username
                usuario = nUsuario.cargarCuentaUsuario(username);
                //MessageBox.Show(usuario.ToString());

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
                boxHorasDisponibles.Text = usuario.balanceDeHoras.ToString();
            }
        }

        // Botón Editar cuenta
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Carga la vista de Registro
            //this.NavigationService.Navigate(new Uri("Registro.xaml", UriKind.Relative));
            if (username != "")
            {
                this.NavigationService.Navigate(new Registro(username));
            }
            else
            {
                this.NavigationService.Navigate(new Registro());
            }
            


            //TODO: Carga los datos en los TextBox ?? O se crea página nueva?
        }

        // Botón Eliminar cuenta
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Elimina Usuario de la base de datos
        }
    }
}
