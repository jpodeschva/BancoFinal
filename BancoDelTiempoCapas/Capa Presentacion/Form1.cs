using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using CapaNegocio;
using CapaDatos;

namespace Capa_Presentacion
{
    public partial class Form1 : Form
    {
        DataSet ds = new DataSet();


        NLogin nLogin = new NLogin();

        public Form1()
        {
            InitializeComponent();

        }

        DUsuario us = new DUsuario();
        private void Form1_Load(object sender, EventArgs e)
        {
            //instanciamos clase cliente
            //dataGridView1.DataSource = us.MostrarClientes();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlReader xmlFile = XmlReader.Create(ofd.FileName, new XmlReaderSettings());
                    ds.ReadXml(xmlFile);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {

            //ds.WriteXml(@"C:\Users\jordi\OneDrive\Escritorio\DAM\BaseDeDatosXML.xml", XmlWriteMode.WriteSchema);
            //MessageBox.Show("EXPORTADO");

           SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ds.Tables[0].WriteXml(sfd.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            /*using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                CategoriaDeServicio categ1 = new CategoriaDeServicio();
                categ1.nombreCategoria = "Música";
                categ1.descripcion = "Clases de música.";

                db.CategoriaDeServicios.Add(categ1);
                db.SaveChanges();


                // Prueba Add
                Usuario user1 = new Usuario();
                user1.nombre = "Alfredo";
                user1.apellido1 = "Vélez";
                user1.apellido2 = "Rico";
                user1.direccion = "C/ La Paz, 5";
                user1.codigoPostal = 28048;
                user1.localidad = "Madrid";
                user1.provincia = "Madrid";
                user1.email = "alfredovr@gmail.com";
                user1.telefono = 635215487;
                user1.idUsername = "avelez";
                user1.idPassword = "1234";

                db.Usuarios.Add(user1);
                db.SaveChanges();

                // Prueba Update
                //Persona persona = db.Persona.Find(4);
                //persona.edad = 32;

                //db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                //db.SaveChanges();


                // Prueba Select
                //var lst = db.Persona;
                //foreach (var oPersona in lst)
                //{
                //    Console.WriteLine(oPersona.nombre);
                //}


                Console.Read();
            }*/

            CategoriaDeServicio categ1 = new CategoriaDeServicio();
            categ1.nombreCategoria = "Deporte";
            categ1.descripcion = "Servicios deportivos";

            DCategoriaDeServicio categoria = new DCategoriaDeServicio();
            categoria.addCategoria(categ1);

        }
    }
}
