//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contacto
    {
        public int idMensaje { get; set; }
        public Nullable<int> idEmisor { get; set; }
        public Nullable<int> idReceptor { get; set; }
        public string mensaje { get; set; }
        public Nullable<System.DateTime> fechaHora { get; set; }
        public Nullable<int> idAnuncio { get; set; }
    
        public virtual Anuncio Anuncio { get; set; }
    }
}
