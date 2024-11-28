using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class RolesRepositorio : IRolesRepositorio
    {
        private Conexion? conexion = null;
        private AuditoriasRepositorio? auditoria = null;

        public RolesRepositorio(Conexion conexion, AuditoriasRepositorio? auditoria)
        {
            this.conexion = conexion;
            this.auditoria = auditoria;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Roles> Listar()
        {
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Roles",
                "Select * from Roles",
                "Se listaron todos los Roles."
            );
            return conexion!.Listar<Roles>();
        }
        public List<Roles> Buscar(Expression<Func<Roles, bool>> condiciones)
        {
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Roles",
                "Select",
                $"Se lista en base a las condiciones: {condiciones}"
            );
            return conexion!.Buscar(condiciones);
        }
        public Roles Guardar(Roles entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Roles",
                "Insert",
                $"Se agregó un nuevo rol: {entidad.Nombre} (Id: {entidad.Id})"
            );
            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Roles",
                "Update",
                $"Se actualizó el rol con Id: {entidad.Id}"
            );
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            auditoria!.Guardar(
                "Usuario - Prueba",
                "Roles",
                "Delete",
                $"Se eliminó la mascota con Id: {entidad.Id}"
            );
            return entidad;
        }
    }
}
