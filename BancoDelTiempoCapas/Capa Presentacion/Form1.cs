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
            dataGridView1.DataSource = us.MostrarClientes();
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

            ds.WriteXml(@"C:\Users\jordi\OneDrive\Escritorio\DAM\BaseDeDatosXML.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("EXPORTADO");

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
    }
}
