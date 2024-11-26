using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Metodos_De_Pagos
    {
        public Metodos_De_Pagos()
        {
            Facturas = new HashSet<Facturas>();
        }

        [Key] public int Id { get; set; }
        public string? Tipo_Metodo_Pago { get; set; }

        [NotMapped] public virtual ICollection<Facturas> Facturas { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Tipo_Metodo_Pago))
                return false;
            return true;
        }
    }
    
}
