using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Entidades
{
    class EAnuncios
    {

        public int idAnuncio { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaPublicacion { get; set; }
        public string tipoServicio { get; set; }
        public string localidad { get; set; }
        public int idUsuario { get; set; }
        public int idCategoria { get; set; }

   
    }
}
