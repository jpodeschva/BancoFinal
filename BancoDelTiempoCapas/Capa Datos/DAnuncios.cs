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

        // Metodo insertar anuncio

        public string InsertarAnuncio(EAnuncios anuncios, ref SqlConnection conexion, ref SqlTransaction transaccion);
     
   
    }
}
