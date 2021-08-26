//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cuota
    {
        public int IdCuota { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [DataType(DataType.Date), Required]
        public System.DateTime Fecha { get; set; }
        [Required]
        public double Mora { get; set; }
        [Required]
        public int IdPago { get; set; }
        [Required]
        public int IdEstado { get; set; }
        [Required]
        public double MontoTotal { get; set; }
        public Nullable<int> EstadoIdEstado { get; set; }
        public Nullable<int> PagoIdPago { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual Pago Pago { get; set; }
    }
}