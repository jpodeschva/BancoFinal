using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Entidades
{
    class ETransaccion
    {
        public int idTransaccion { get; set; }
        public Nullable<System.DateTime> fechaSolicitud { get; set; }
        public Nullable<System.DateTime> fechaRealizacion { get; set; }
        public Nullable<int> idUsuarioSolicita { get; set; }
        public Nullable<int> idUsuarioProporciona { get; set; }
        public Nullable<int> numeroHoras { get; set; }
        public Nullable<int> idAnuncio { get; set; }
    }
}
