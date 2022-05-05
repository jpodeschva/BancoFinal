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
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class Login : Page
    {
        String username, password;
        bool isLoggedIn = false;

        NLogin nLogin;

        public Login()
        {
            InitializeComponent();
            nLogin = new NLogin();
            
        }

        private void finalLoginBtnClick(object sender, RoutedEventArgs e)
        {
            // Asignamos los valores introducidos por el usuario a las variables
            username = usernameTextBox.textBox.Text;
            password = passwordBox1.Password.ToString();

            // Llamamos al método de la CapaNegocio que validará el usuario y, si es correcto, logueará al usuario
            isLoggedIn = nLogin.login(username, password);

            if (isLoggedIn)
            {
                //TODO: Permite entrar a pantallas, acceder a botones, etc.
                MessageBox.Show("Login correcto!");
            }
            else
            {
                //TODO: Bloquea algo? Mensaje de Registro?
                MessageBox.Show("Error al intentar acceder. Compruebe los datos introducidos o Regístrese.");
            }
        }

    }
}
