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
    
    public partial class Transaccion
    {
        public int idTransaccion { get; set; }
        public Nullable<System.DateTime> fechaSolicitud { get; set; }
        public Nullable<System.DateTime> fechaRealizacion { get; set; }
        public int idUsuarioSolicita { get; set; }
        public int idUsuarioProporciona { get; set; }
        public int numeroHoras { get; set; }
        public int idAnuncio { get; set; }
    
        public virtual Anuncio Anuncio { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
