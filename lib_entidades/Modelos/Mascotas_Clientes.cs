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
        public int Cliente { get; set; }
        public int Mascota { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

        [ForeignKey("Mascota")] public Mascotas? _Mascota { get; set; }

        

        public bool Validar()
        {
            if (Mascota == 0 ||
                Cliente == 0)
                return false;
            return true;
        }
    }
}