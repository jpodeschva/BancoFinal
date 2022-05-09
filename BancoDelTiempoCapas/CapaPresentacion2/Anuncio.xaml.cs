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
                //string value = anuncio.localidad;
                //System.Windows.MessageBox.Show("Value: " + value);

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
            sfd.Filter = "XML|*.xml";
            // Show save file dialog box
            Nullable<bool> result = sfd.ShowDialog();
            // Process save file dialog box results
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
