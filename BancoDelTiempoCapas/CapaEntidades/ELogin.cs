using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaEntidades
{
    public class ELogin
    {
        public string idUsername { get; set; }
        public string idPassword { get; set; }
        public Nullable<int> idUsuario { get; set; }
    }
}
