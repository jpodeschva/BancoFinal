using CapaNegocio;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Documents;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections;
using DocumentFormat.OpenXml.Wordprocessing;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using System.Windows.Controls.Primitives;
using MessageBox = System.Windows.MessageBox;

namespace CapaPresentacion2
{
    public partial class Anuncio : Page
    {
        NAnuncios nAnuncios;
        
        String palabraBuscar;

        CapaDatos.Anuncio anuncioSeleccionado;
        int idSeleccion;

        public Anuncio()
        {
            InitializeComponent();
            nAnuncios = new NAnuncios();
        }

        private void buscarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            palabraBuscar = textBoxBuscar.textBox.Text;  // Coge la palabra que el usuario escribe en el TextBox
            //MessageBox.Show(palabraBuscar);

            // Llama al método que analiza la palabra (en CapaNegocio) y lo asigna al DataGridView
            dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);  

        }

        private void addAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            // Sólo se pueden añadir anuncios si se está logueado
            if (SessionManager.Instance.username != "")
            {
                // Muestra ventana con formulario para añadir anuncio
                var window = new Add_NewAnuncio();
                //window.Owner = this;
                window.ShowDialog();

                // Llama al método que vuelve a listar todos los anuncios
                dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);
            }
            else
            {
                MessageBox.Show("Debes estar logueado para poder añadir un anuncio.");
            }
            
        }

        private void eliminarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            anuncioSeleccionado = (CapaDatos.Anuncio)dataGridAnuncio.SelectedItem;
            idSeleccion = anuncioSeleccionado.idAnuncio;
            // Llama al método de la CapaNegocio que pasará la orden de eliminar el anuncio
            nAnuncios.eliminarAnuncio(idSeleccion);
            // Llama al método que vuelve a listar todos los anuncios
            dataGridAnuncio.ItemsSource = nAnuncios.buscarSegunPalabra(palabraBuscar);
        }

        private void exportarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Anuncio";

            dt.Columns.Add("idAnuncio");
            dt.Columns.Add("tipoServicio");
            dt.Columns.Add("descripcion");
            dt.Columns.Add("fechaPublicacion");
            dt.Columns.Add("localidad");
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("idCategoria");

            ds.Tables.Add(dt);

            for (int i = 0; i < (dataGridAnuncio.Items.Count -1); i++)
            {
                DataGridRow r = (DataGridRow)dataGridAnuncio.ItemContainerGenerator.ContainerFromIndex(i);

                CapaDatos.Anuncio anuncio = (CapaDatos.Anuncio)r.Item;
               
                DataRow row = ds.Tables["Anuncio"].NewRow();
                row["idAnuncio"] = anuncio.idAnuncio;
                row["tipoServicio"] = anuncio.tipoServicio;
                row["descripcion"] = anuncio.descripcion;
                row["fechaPublicacion"] = anuncio.fechaPublicacion;
                row["localidad"] = anuncio.localidad;
                row["idUsuario"] = anuncio.idUsuario;
                row["idCategoria"] = anuncio.idCategoria;
                
                ds.Tables["Anuncio"].Rows.Add(row);
            }

            // Abre ventana para elegir dónde guardar el archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";  // Filtra los resultados con extensión .xml
            Nullable<bool> result = sfd.ShowDialog();  // Muestra el dialog box
            // Procesa el resultado del dialog box
            if (result == true)
            {
                // Save document
                try
                {
                    ds.WriteXml(sfd.FileName);
                    System.Windows.MessageBox.Show("EXPORTADO");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    System.Windows.MessageBox.Show("Error\n" + ex);
                }
            }
        }

        private void seleccionarAnuncioBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: hacer excepcion de errores
            anuncioSeleccionado = (CapaDatos.Anuncio)dataGridAnuncio.SelectedItem;

            if(anuncioSeleccionado != null)
            {
                idSeleccion = anuncioSeleccionado.idAnuncio;
                this.NavigationService.Navigate(new Transaccion(idSeleccion));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un anuncio.");
            }
        }


        // Muestra todos los anuncios de la base de datos
        /*private void bindDataGrid()
        {
            BancoDelTiempoEntities db = new BancoDelTiempoEntities();

            // Para mostrar todos los campos de la tabla
            //var data = from d in db.Anuncios select d;

            // Para mostrar sólo determinados campos de la tabla
            var data = db.Anuncios
            //.Where(x => x.idCategoria == 1 && x.localidad == "Madrid")  // Para buscar por alguna propiedad
            .Select(x => new
            {
                IdAnuncio = x.idAnuncio,
                TipoDeServicio = x.tipoServicio,
                Descripcion = x.descripcion,
                FechaDePublicacion = x.fechaPublicacion,
                Localidad = x.localidad,
                IdCategoria = x.idCategoria,
                IdUsuario = x.idUsuario

            }).ToList();

            dataGridAnuncio.ItemsSource = data.ToList();
        }*/

    }

    
}
