using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DConexion
    {

        public static string conexion = Properties.Settings.Default.Conexion;

        // Prueba conexión funcionamiento BD con capas
        public void pruebaConexion()
        {
            SqlConnection conexionSqlConnection = new SqlConnection(conexion);

            try
            {
                conexionSqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la Base de Datos" + ex.Message);
                return;
            }

            MessageBox.Show("Conectado!");

        }

    }
}
