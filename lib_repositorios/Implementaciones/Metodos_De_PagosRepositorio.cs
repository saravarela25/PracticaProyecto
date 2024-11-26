using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Metodos_De_PagosRepositorio : IMetodos_De_PagosRepositorio
    {
        private Conexion? conexion = null;

        public Metodos_De_PagosRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Metodos_De_Pagos> Listar()
        {
            return conexion!.Listar<Metodos_De_Pagos>();
        }

        public List<Metodos_De_Pagos> Buscar(Expression<Func<Metodos_De_Pagos, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Metodos_De_Pagos Guardar(Metodos_De_Pagos entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Metodos_De_Pagos Modificar(Metodos_De_Pagos entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Metodos_De_Pagos Borrar(Metodos_De_Pagos entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}