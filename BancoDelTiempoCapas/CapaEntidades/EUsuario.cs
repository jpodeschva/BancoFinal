using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaEntidades
{
    public class EUsuario
    { 
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string direccion { get; set; }
        public int codigoPostal { get; set; }
        public string localidad { get; set; }
        public string provincia { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public string idUsername { get; set; }
        public string idPassword { get; set; }
    }
}
