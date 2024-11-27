using lib_entidades.Modelos;
namespace lib_repositorios.Implementaciones
{
    public class AuditoriasRepositorio
    {
        private Conexion? conexion = null;
        public AuditoriasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }
        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public Auditorias Guardar(string usuario, string entidad, string operacion, string detalles)
        {
            var auditoria = new Auditorias
            {
                Usuario = usuario,
                Entidad = entidad,
                Operacion = operacion,
                Fecha = DateTime.Now,
                Detalles = detalles
            };
            conexion!.Guardar(auditoria);
            conexion!.GuardarCambios();
            return auditoria;
        }
    }
}
