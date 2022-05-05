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

        // Cancelar Registro Btn
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Limpiar formulario
            textBoxNombre.textBox.Text = String.Empty;
            //foreach (TextBox textBox in UserControls.OfType<MyTextBox>()) // TODO: foreach para limpiar todos???????
              //  textBox.Text = "";
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

            // Llama al método de la CapaNegocio que guarda el registro del usuario y le pasa los datos
            nRegistro.guardaRegistro(nombre, apellido1, apellido2, direccion, localidad, provincia, email, 
                username, password, codigoPostal, telefono);
        }

    }
}
