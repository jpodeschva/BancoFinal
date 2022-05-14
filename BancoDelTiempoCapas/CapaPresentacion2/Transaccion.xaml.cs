using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
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
    
    public partial class Transaccion : Page
    {
        private int _numValue = 0;
        int idAnuncioSeleccionado;
        NAnuncios nAnuncios;
        NTransaccion nTransaccion;

        public Transaccion()
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
            nAnuncios = new CapaNegocio.NAnuncios();
        }

        public Transaccion(int idAnuncio)
        {
            InitializeComponent();
            txtNum.Text = _numValue.ToString();
            nAnuncios = new CapaNegocio.NAnuncios();
            nTransaccion = new NTransaccion();
            idAnuncioSeleccionado = idAnuncio;

            // Carga los datos del anuncio seleccionado
            dataGridAnuncioSeleccionado.ItemsSource = (System.Collections.IEnumerable)nAnuncios.buscarAnuncioPorId(idAnuncio);
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
            DateTime now = DateTime.Now;  // Asigna la fecha y hora actual a la variable now

            CapaDatos.Anuncio anuncio = (CapaDatos.Anuncio)nAnuncios.buscarAnuncioPorId(idAnuncioSeleccionado)[0];
            // Asigna los valores correspondientes en cada TextBox
            boxIdAnuncio.Text = idAnuncioSeleccionado.ToString();
            boxTipoServicio.Text = anuncio.tipoServicio;
            boxHorasPagadas.Text = this.NumValue.ToString();
            boxFechaSolicitud.Text = now.ToString();

            // TODO: Restar el número de horas seleccionadas del balance de horas del usuario
            int horasPagadas = Int32.Parse(boxHorasPagadas.Text);
            String username = SessionManager.Instance.username;
            //MessageBox.Show("Usuario: " + username);
            nTransaccion.restarHorasDelBalance(username, horasPagadas);

            
            /*try
            {
                BancoDelTiempoEntities db = new BancoDelTiempoEntities();
                var data = db.Anuncios
                .Where(x => x.idAnuncio == idAnuncioSeleccionado)
                .Select(x => new
                {
                    IdAnuncio = 1,//x.idAnuncio,
                    Actividad = "Piano",//x.tipoServicio,
                    HorasPagadas = 0,
                    FechaSolicitud = now,

                }).ToList();

                dataGridAnuncioPagado.ItemsSource = data.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/

            /*DataRowView rowView = (dataGridAnuncioPagado.Items[0] as DataRowView); //Get RowView
            rowView.BeginEdit();
            rowView[2] = now;
            rowView.EndEdit();
            dataGridAnuncioPagado.Items.Refresh(); // Refresh table*/

            //dataGridAnuncioPagado.ItemsSource = null;
        }
    }
}
