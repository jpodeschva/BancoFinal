using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using CapaEntidades;

namespace CapaDatos
{
    public class DAnuncios
    {

        public string PublicarAnuncios(EAnuncios anuncios, ref SqlConnection conexion, ref SqlTransaction transaccion)
        {
            string respuesta;

            try
            {
                SqlCommand comando = new SqlCommand("spinsertar_anuncios", conexion)
                {

                    CommandType = CommandType.StoredProcedure,
                    Transaction = transaccion

                };
                comando.Parameters.AddWithValue();
            }
            catch (Exception) {

                throw;
            }

        }
    }
}
