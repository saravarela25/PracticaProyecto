namespace lib_entidades.Modelos
{
    public class Auditorias
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Entidad { get; set; }
        public string? Operacion { get; set; }
        public DateTime Fecha { get; set; }
        public string? Detalles { get; set; }
    }
}
