namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class Mascotas_Clientes
    {
        [Key] public int Id { get; set; }

        [ForeignKey("Cliente")] public int Cliente { get; set; }

        [ForeignKey("Mascota")] public int Mascota { get; set; }

        [NotMapped] public virtual Clientes? _Cliente { get; set; }
        [NotMapped] public virtual Mascotas? _Mascota { get; set; }

        public bool Validar()
        {
            if (Mascota == 0 ||
                Cliente == 0)
                return false;
            return true;
        }
    }
}