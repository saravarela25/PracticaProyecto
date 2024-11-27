using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace lib_entidades.Modelos
{
    public class Usuarios
    {

        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public int  Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(Contraseña) ||
                   Rol <= 0)
                return false;
            return true;
        }
    }
}
