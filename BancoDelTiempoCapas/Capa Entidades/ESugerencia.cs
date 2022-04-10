using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Entidades
{
    class ESugerencia
    {
        public int idSugerencia { get; set; }
        public string descripcion { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public Nullable<int> idUsuario { get; set; }
    }
}
