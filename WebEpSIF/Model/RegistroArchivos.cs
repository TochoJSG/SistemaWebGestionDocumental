//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebEpSIF.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class RegistroArchivos
    {
        public int IdRegistroUnico { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdNivel { get; set; }
        public Nullable<int> IdPeriodo { get; set; }
        public Nullable<int> IdRegistroMatriz { get; set; }
        public string NombreArchivo { get; set; }
        public byte[] Archivo { get; set; }
        public Nullable<System.DateTime> fechacarga { get; set; }
        public Nullable<int> IdConcepto { get; set; }
        public Nullable<int> baja { get; set; }
        public Nullable<int> IdUsuarioweb { get; set; }
        public Nullable<int> idevento { get; set; }
        public Nullable<int> iddocumento { get; set; }
    }
}
