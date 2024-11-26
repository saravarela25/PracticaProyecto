using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Facturas
    {
        public Facturas()
        {
            Detalles_Facturas = new HashSet<Detalles_Facturas>();
        }

        [Key] public int Id { get; set; }
        public int Num_Factura { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public DateTime? Fecha { get; set; }
        
        [ForeignKey("Cliente")] public int Cliente { get; set; }
        [ForeignKey("Metodo_De_Pago")] public int Metodo_De_Pago { get; set; }

        [NotMapped] public virtual Clientes? _Cliente { get; set; }

        [NotMapped] public virtual ICollection<Detalles_Facturas> Detalles_Facturas { get; set; }
       
        [NotMapped] public virtual Metodos_De_Pagos? _Metodos_De_Pago { get; set; }
        public bool Validar()
        {
            if  (Num_Factura<0 ||
                IVA <0  ||
                Total <0 )
                return false;
            if  (Fecha== null)
                return false;
            return true;
        }
    }
    
}
