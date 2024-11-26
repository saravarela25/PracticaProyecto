namespace lib_entidades.Modelos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Clientes
    {

        public Clientes()
        {
            this.Facturas = new HashSet<Facturas>();
            this.Mascotas_Clientes = new HashSet<Mascotas_Clientes>();
        }

        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Numero { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }

        [NotMapped] public virtual ICollection<Facturas> Facturas { get; set; }

        [NotMapped] public virtual ICollection<Mascotas_Clientes> Mascotas_Clientes { get; set; }

        public void Registrar_Cliente()
        {

        }
        public void Buscar_Cliente()
        {

        }
        
        
    }
    
}