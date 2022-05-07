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

namespace CapaPresentacion2
{
    public partial class Anuncio : Page
    {
        NAnuncios nAnuncios;

        String palabraBuscar;

        CapaDatos.Anuncio anuncioSeleccionado;
        int idSeleccion;

        public Anuncio(bool isLoggedIn)
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

            ArrayList rowList = new ArrayList();

            for (int i = 0; i < dataGridAnuncio.Items.Count; i++)
            {
                DataGridRow r = (DataGridRow)dataGridAnuncio.ItemContainerGenerator.ContainerFromIndex(i);

                rowList.Add(r);
            }

            foreach (DataGridRow r in rowList)
            {
                /*DataRow row = ds.Tables["Anuncio"].NewRow();
                row["idAnuncio"] = r.Cells[0].Value;
                row["tipoServicio"] = r.Cells[1].Value;
                row["descripcion"] = r.Cells[2].Value;
                row["fechaPublicacion"] = r.Cells[3].Value;
                row["localidad"] = r.Cells[4].Value;
                row["idUsuario"] = r.Cells[5].Value;
                row["idCategoria"] = r.Cells[6].Value;
                
                ds.Tables["Anuncio"].Rows.Add(row);*/
            }

            // Abre ventana para elegir dónde guardar el archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog().Equals(DialogResult.OK)) 
            {
                try
                {
                    ds.WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            System.Windows.MessageBox.Show("EXPORTADO");

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
