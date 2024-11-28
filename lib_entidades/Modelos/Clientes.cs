using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Clientes
    {
       

        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Numero { get; set; }
        public string? Cedula { get; set; }
        public string? Email { get; set; }

        [NotMapped]
        public virtual ICollection<Facturas> Facturas { get; set; }

        [NotMapped]
        public virtual ICollection<Mascotas_Clientes> Mascotas_Clientes { get; set; }

        public void Registrar_Cliente()
        {

        }

        public void Buscar_Cliente()
        {

        }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre) ||
                    string.IsNullOrEmpty(Numero) ||
                string.IsNullOrEmpty(Cedula) ||
                string.IsNullOrEmpty(Email))
                return false;

            return true;
        }
    }
}
