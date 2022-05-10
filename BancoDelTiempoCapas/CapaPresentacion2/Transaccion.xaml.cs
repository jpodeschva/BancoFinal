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
    /// Lógica de interacción para Transaccion.xaml
    /// </summary>
    public partial class Transaccion : Page
    {
        private int _numValue = 0;

        public Transaccion()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
        }

        public Transaccion(int idAnuncio)
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();

            // Carga los datos del anuncio seleccionado

        }

        public int NumValue
        {
            get { return _numValue; }
            set
            {
                _numValue = value;
                txtNum.Text = value.ToString();
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            NumValue++;
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            NumValue--;
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out _numValue))
                txtNum.Text = _numValue.ToString();
        }

        private void pagarTransaccionBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
