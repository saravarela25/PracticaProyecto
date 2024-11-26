using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Servicios
    {

        public Servicios()
        {
            Detalles_Facturas = new HashSet<Detalles_Facturas>();
        }

        [Key] public int Id { get; set; }
        public decimal? Precio { get; set; }
        public string? Tipo_Servicio { get; set; }
        public string? Descripcion { get; set; }

        [NotMapped] public virtual ICollection<Detalles_Facturas> Detalles_Facturas { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Tipo_Servicio) ||
                string.IsNullOrEmpty(Descripcion) ||
                Precio <= 0)
                return false;
            return true;
        }
    }
}
