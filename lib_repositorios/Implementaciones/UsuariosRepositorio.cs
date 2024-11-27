using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private Conexion? conexion = null;
        private AuditoriasRepositorio? auditoria = null;

        public UsuariosRepositorio(Conexion conexion, AuditoriasRepositorio? auditoria)
        {
            this.conexion = conexion;
            this.auditoria = auditoria;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }
        public List<Usuarios> Listar()
        {
            auditoria!.Guardar(
                "Usuarios - Prueba",
                "Usuarios",
                "Select * from Usuarios",
                "Se listaron todos los Usuarios."
            );
            return Buscar(x => x != null);
        }
 
        public List<Usuarios> Buscar(Expression<Func<Usuarios, bool>> condiciones)
        {
            auditoria!.Guardar(
                "Usuarios - Prueba",
                "Usuarios",
                "Select",
                $"Se lista en base a las condiciones: {condiciones}"
            );
            return conexion!.Buscar(condiciones);
        }
        public Usuarios Guardar(Usuarios entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuarios - Prueba",
                "Usuarios",
                "Insert",
                $"Se agregó un nuevo usuario con email: {entidad.Email} (Id: {entidad.Id})"
            );
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuarios - Prueba",
                "Usuarios",
                "Update",
                $"Se actualizó el usuario con Id: {entidad.Id}"
            );
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuarios - Prueba",
                "Usuarios",
                "Delete",
                $"Se eliminó la mascota con Id: {entidad.Id}"
            );
            return entidad;
        }
    }
}
