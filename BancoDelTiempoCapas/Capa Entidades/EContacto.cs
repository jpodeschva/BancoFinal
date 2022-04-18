using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaEntidades
{
    public class EContacto
    {
        public int idMensaje { get; set; }
        public int idEmisor { get; set; }
        public int idReceptor { get; set; }
        public string mensaje { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public int idAnuncio { get; set; }

    }
}
