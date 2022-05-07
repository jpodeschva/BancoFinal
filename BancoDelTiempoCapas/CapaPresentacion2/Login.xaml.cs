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
    public partial class Login : Page
    {
        String username, password;
        bool isLoggedIn = false;

        NLogin nLogin;
        MainWindow mainWindow;

        public Login()
        {
            InitializeComponent();
            mainWindow = new MainWindow();
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

                // Entra a la pantalla CuentaUsuario
                //this.mainWindow.Content = new CuentaUsuario(isLoggedIn, username);

                this.NavigationService.Navigate(new CuentaUsuario(isLoggedIn, username));

                //mainWindow = new MainWindow(isLoggedIn, username);
                //mainWindow.Show();

                //this.mainWindow.Close();
                //mainWindow.Main.Content = new CuentaUsuario(isLoggedIn, username);

                // Entra a la pantalla Anuncios
                //mainWindow.Main.Content = new Anuncio(isLoggedIn);
            }
            else
            {
                //TODO: Bloquea algo? Mensaje de Registro?
                MessageBox.Show("Error al intentar acceder. Compruebe los datos introducidos o Regístrese.");
            }
        }

    }
}
