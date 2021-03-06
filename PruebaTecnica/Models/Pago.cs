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

    public partial class Pago
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pago()
        {
            this.Cuotas = new HashSet<Cuota>();
        }
    
        [Required]
        public int IdPago { get; set; }
        [Required]
        public double Monto { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdEstado { get; set; }
        [DataType(DataType.Date), Required]
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<int> ClienteIdCliente { get; set; }
        public Nullable<int> EstadoIdEstado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cuota> Cuotas { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
