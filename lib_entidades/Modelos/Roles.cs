using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        [NotMapped] public virtual ICollection<Usuarios>? Usuarios { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;

            return true;
        }
    }
}
