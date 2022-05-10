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
using System.Windows.Shapes;

namespace CapaPresentacion2
{
    /// <summary>
    /// Lógica de interacción para Add_NewAnuncio.xaml
    /// </summary>
    public partial class Add_NewAnuncio : Window
    {
        NAnuncios nAnuncios;
        String tipoServicio, descripcion, localidad;
        int idCategoria, idUsuario;
        DateTime fecha;

        public Add_NewAnuncio()
        {
            InitializeComponent();
            datePickerAnuncio.SelectedDate = DateTime.Today;
            nAnuncios = new NAnuncios();

            // Asigna automáticamente el idUsuario a partir del username de SessionManager
            idUsuario = getIdUsuarioFromUsernameInSessionManager();
            textBoxIdUsuario.Text = idUsuario.ToString();
        }

        private int getIdUsuarioFromUsernameInSessionManager()
        {
            return nAnuncios.getIdUsuarioFromUsername();
        }

        private void crearAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            // Asigna los atributos introducidos por el usuario a las variables
            tipoServicio = textBoxTipoServicio.Text;
            descripcion = textBoxDescripcion.Text;
            localidad = textBoxLocalidad.Text;
            int indexCategoria = comboBoxCategorias.SelectedIndex;
            idCategoria = getCategoriaSeleccionada(indexCategoria);
            
            //idCategoria = Convert.ToInt32(menuCategoria.Text);
            idUsuario = Convert.ToInt32(textBoxIdUsuario.Text);
            fecha = DateTime.Parse(datePickerAnuncio.Text);

            // Llama al método de la CapaNegocio que pasará la orden de añadir el anuncio
            nAnuncios.addAnuncio(tipoServicio, descripcion, localidad, idCategoria, idUsuario, fecha);
            
            // Cierra la ventana
            this.Close();
        }

        private int getCategoriaSeleccionada(int indexCategoria)
        {
            switch (indexCategoria)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 9;
                case 5:
                    return 10;
                case 6:
                    return 11;
                case 7:
                    return 16;
            }
            return 0;
        }
    }
}
