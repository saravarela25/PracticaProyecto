using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class MascotasRepositorio : IMascotasRepositorio
    {
        private Conexion? conexion = null;

        public MascotasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Mascotas> Listar()
        {
            return conexion!.Listar<Mascotas>();
        }

        public List<Mascotas> Buscar(Expression<Func<Mascotas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Mascotas Guardar(Mascotas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Mascotas Modificar(Mascotas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Mascotas Borrar(Mascotas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}