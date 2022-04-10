using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaEntidades
{
    public class ECategoriaDeServicio
    {
        public int idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string descripcion { get; set; }
    }
}
