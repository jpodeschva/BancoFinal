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
using System.Data.SqlClient;

namespace Capa_Presentacion
{
    public partial class Form1 : Form
    {
        BancoDelTiempoEntities db = new BancoDelTiempoEntities();
        
        DataSet ds = new DataSet();

        //NLogin nLogin = new NLogin();

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
            // Import data from Database
            dataGridView1.DataSource = db.Usuarios.ToList();

            // Import from XML file
            /*OpenFileDialog ofd = new OpenFileDialog();
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
            }*/

            // Import data from Database
            /*SqlDataAdapter sda = new SqlDataAdapter();
            String nombreTabla = "usuario";

            DataSet ds = new DataSet();
            sda.Fill(ds, nombreTabla);
            dataGridView1.DataSource = ds.Tables[nombreTabla];*/

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {

           // ds.WriteXml(@"C:\Users\jordi\OneDrive\Escritorio\DAM\BaseDeDatosXML.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("EXPORTADO");

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "usuario";
            dt.Columns.Add("idUsuario");
            dt.Columns.Add("nombre");
            dt.Columns.Add("apellido1");
            dt.Columns.Add("apellido2");
            dt.Columns.Add("direccion");
            dt.Columns.Add("codigoPostal");
            dt.Columns.Add("localidad");
            dt.Columns.Add("provincia");
            dt.Columns.Add("email");
            dt.Columns.Add("telefono");
            dt.Columns.Add("idUsername");
            dt.Columns.Add("idPassword");
            ds.Tables.Add(dt);

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row = ds.Tables["usuario"].NewRow();
                row["idUsuario"] = r.Cells[0].Value;
                row["nombre"] = r.Cells[1].Value;
                row["apellido1"] = r.Cells[2].Value;
                row["apellido2"] = r.Cells[2].Value;
                row["direccion"] = r.Cells[3].Value;
                row["codigoPostal"] = r.Cells[2].Value;
                row["localidad"] = r.Cells[2].Value;
                row["provincia"] = r.Cells[2].Value;
                row["email"] = r.Cells[2].Value;
                row["telefono"] = r.Cells[2].Value;
                row["idUsername"] = r.Cells[2].Value;
                row["idPassword"] = r.Cells[2].Value;
                ds.Tables["usuario"].Rows.Add(row);
            }
            //ds.WriteXml("C:\\Users\\lauri\\Downloads\\xmlexported.xml");

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
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


            /*SaveFileDialog sfd = new SaveFileDialog();

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
            }*/
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

            /*CategoriaDeServicio categ1 = new CategoriaDeServicio();
            categ1.nombreCategoria = "Deporte";
            categ1.descripcion = "Servicios deportivos";

            DCategoriaDeServicio categoria = new DCategoriaDeServicio();
            categoria.addCategoria(categ1);
            //categoria.deleteCategoria(4);*/


            /*Usuario user2 = new Usuario();
            user2.nombre = "Lorenzo";
            user2.apellido1 = "Vélez";
            user2.apellido2 = "Rico";
            user2.direccion = "C/ La Paz, 5";
            user2.codigoPostal = 28048;
            user2.localidad = "Madrid";
            user2.provincia = "Madrid";
            user2.email = "alfredovr@gmail.com";
            user2.telefono = 635215487;
            user2.idUsername = "lvelez";
            user2.idPassword = "1234";

            DUsuario user = new DUsuario();
            user.addUsuario(user2);*/


        }
    }
}
