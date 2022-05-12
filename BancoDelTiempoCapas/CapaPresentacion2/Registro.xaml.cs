using CapaDatos;
using CapaNegocio;
using CapaPresentacion2.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;


namespace CapaPresentacion2
{
    public partial class Registro : Page
    {
        NRegistro nRegistro;

        // Variables para los atributos del Registro
        String nombre, apellido1, apellido2, direccion, localidad, provincia, email, username, password;
        int codigoPostal, telefono;

        public Registro()
        {
            InitializeComponent();
            nRegistro = new NRegistro();
        }

        public Registro(String username)
        {
            InitializeComponent();
            nRegistro = new NRegistro();
            this.username = username;

            cargarDatosUsuario(username);
        }

        private void cargarDatosUsuario(String username)
        {
            NUsuario nUsuario = new NUsuario();
            Usuario usuario = new Usuario();
            usuario = nUsuario.cargarCuentaUsuario(username);

            // Carga datos del usuario en los TextBox
            textBoxNombre.textBox.Text = usuario.nombre;
            textBoxApellido1.textBox.Text = usuario.apellido1;
            textBoxApellido2.textBox.Text = usuario.apellido2;
            textBoxDireccion.textBox.Text = usuario.direccion;
            textBoxCP.textBox.Text = usuario.codigoPostal.ToString();
            textBoxLocalidad.textBox.Text = usuario.localidad;
            textBoxProvincia.textBox.Text = usuario.provincia;
            textBoxEmail.textBox.Text = usuario.email;
            textBoxTelefono.textBox.Text = usuario.telefono.ToString();
            textBoxUsername.textBox.Text = usuario.idUsername;
            textBoxPassword.textBox.Text = usuario.idPassword;
        }

        // Cancelar Registro Btn
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Limpiar formulario
            textBoxNombre.textBox.Text = String.Empty;
            textBoxApellido1.textBox.Text = String.Empty;
            textBoxApellido2.textBox.Text = String.Empty;
            textBoxDireccion.textBox.Text = String.Empty;
            textBoxCP.textBox.Text = String.Empty;
            textBoxLocalidad.textBox.Text = String.Empty;
            textBoxProvincia.textBox.Text = String.Empty;
            textBoxEmail.textBox.Text = String.Empty;
            textBoxTelefono.textBox.Text = String.Empty;
            textBoxUsername.textBox.Text = String.Empty;
            textBoxPassword.textBox.Text = String.Empty;

        }

        // Guardar Registro Btn
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Asigna los datos introducidos por el usuario a las variables
            nombre = textBoxNombre.textBox.Text;
            apellido1 = textBoxApellido1.textBox.Text;
            apellido2 = textBoxApellido2.textBox.Text;
            direccion = textBoxDireccion.textBox.Text;
            localidad = textBoxLocalidad.textBox.Text;
            provincia = textBoxProvincia.textBox.Text;
            email = textBoxEmail.textBox.Text;
            username = textBoxUsername.textBox.Text;
            password = textBoxPassword.textBox.Text;
            codigoPostal = int.Parse(textBoxCP.textBox.Text);
            telefono = int.Parse(textBoxTelefono.textBox.Text);

            // Comprueba si el username ya existe o es un nuevo usuario
            bool existe = nRegistro.comprobarUsername(username);
            if (!existe)  // Nuevo usuario
            {
                // Llama al método de la CapaNegocio que guarda el registro del usuario y le pasa los datos
                nRegistro.guardaRegistro(nombre, apellido1, apellido2, direccion, localidad, provincia, email,
                    username, password, codigoPostal, telefono);
                this.NavigationService.Navigate(new Login());
            }
            else  // Actualiza usuario
            {
                // Llama al método de la CapaNegocio que actualiza el usuario y le pasa los datos
                nRegistro.actualizaRegistro(nombre, apellido1, apellido2, direccion, localidad, provincia, email,
                    username, password, codigoPostal, telefono);
                // Lleva a la página del Menú
                this.NavigationService.Navigate(new Menu());
            }

        }

    }
}
