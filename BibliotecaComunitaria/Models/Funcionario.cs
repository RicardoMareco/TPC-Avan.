//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaComunitaria.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Funcionario
    {
        public string NroDocumento { get; set; }
        public int TipoDocmento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public int CiudadID { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
