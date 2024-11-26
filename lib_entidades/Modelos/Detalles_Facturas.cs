using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Detalles_Facturas
    {
        [Key] public int Id { get; set; }
        public DateTime? Fecha_Servicio { get; set; }
        public string? Estado { get; set; }
        public decimal IVA { get; set; }
        public decimal Precio_Venta { get; set; }
        public int Factura { get; set; }
        public int Mascota { get; set; }
        public int Servicio { get; set; }

        [ForeignKey("Factura")] public Facturas? _Factura { get; set; }
        [ForeignKey("Mascota")] public Mascotas? _Mascota { get; set; }
        [ForeignKey("Servicio")] public Servicios? _Servicio { get; set; }


        public bool Validar()
        {
            if (Fecha_Servicio == null ||
                string.IsNullOrEmpty(Estado) ||
                IVA <= 0 ||
                Precio_Venta <= 0 ||
                Factura <= 0 ||
                Mascota <= 0 ||
                Servicio <= 0)
                return false;
            return true;
        }
    }

}
