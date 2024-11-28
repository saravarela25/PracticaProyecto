using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Facturas
    {
     

        [Key] public int Id { get; set; }
        public string? Num_Factura { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Cliente { get; set; }
        public int? Metodo_De_Pago { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }
        [ForeignKey("Metodo_De_Pago")] public Metodos_De_Pagos? _Metodo_De_Pago { get; set; }

        [NotMapped] public virtual ICollection<Detalles_Facturas>? Detalles_Facturas { get; set; }

        public bool Validar()
        {
            if  (string.IsNullOrEmpty(Num_Factura)  ||
                IVA <0  ||
                Total <0 )
                return false;
            if  (Fecha== null)
                return false;
            return true;
        }
    }
    
}
