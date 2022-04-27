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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new Menu();
        }

        private void loginBtnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Login();
        }

        private void registroBtnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Registro();
        }

        private void menuBtnClick(object sender, RoutedEventArgs e)
        {
            Main.Content = new Menu();
        }

        private void nosotrosBtnClick(object sender, RoutedEventArgs e)
        {

        }

        private void menuBtnCategoria(object sender, RoutedEventArgs e)
        {

        }
    }
}
