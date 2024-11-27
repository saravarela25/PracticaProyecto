using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_entidades.Modelos
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                return false;

            return true;
        }
    }
}
