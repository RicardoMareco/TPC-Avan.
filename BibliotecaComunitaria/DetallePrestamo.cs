//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BibliotecaComunitaria
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePrestamo
    {
        public int PrestamoID { get; set; }
        public int DetallePrestamoID { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public int CantidadEjemplares { get; set; }
        public int LibroID { get; set; }
        public bool Estado { get; set; }
    
        public virtual Libro Libro { get; set; }
        public virtual Prestamo Prestamo { get; set; }
    }
}