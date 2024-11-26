using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Mascotas
    {
        public Mascotas()
        {
            this.Detalles_Facturas = new HashSet<Detalles_Facturas>();
            this.Mascotas_Clientes = new HashSet<Mascotas_Clientes>();
        }

        [Key] public int Id { get; set; }
        public string? Cod_Mascota { get; set; }
        public string? Nombre { get; set; }
        public string? Tipo_Mascota { get; set; }
        public string? Raza { get; set; }
        public int? Edad { get; set; }


        [NotMapped] public virtual ICollection<Detalles_Facturas> Detalles_Facturas { get; set; }

        [NotMapped] public virtual ICollection<Mascotas_Clientes> Mascotas_Clientes { get; set; }
        public void Registrar_Mascota()
        {

        }
        public void Buscar_Mascota()
        {

        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                string.IsNullOrEmpty(Cod_Mascota) ||
                string.IsNullOrEmpty(Raza) ||
                Edad == null)
                return false;
            return true;
        }
    }
}
