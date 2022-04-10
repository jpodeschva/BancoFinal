using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Entidades
{
    class EContacto
    {
        public int idMensaje { get; set; }
        public Nullable<int> idEmisor { get; set; }
        public Nullable<int> idReceptor { get; set; }
        public string mensaje { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public Nullable<int> idAnuncio { get; set; }

    }
}
