using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IMetodos_De_PagosRepositorio
    {
        void Configurar(string string_conexion);
        List<Metodos_De_Pagos> Listar();
        List<Metodos_De_Pagos> Buscar(Expression<Func<Metodos_De_Pagos, bool>> condiciones);
        Metodos_De_Pagos Guardar(Metodos_De_Pagos entidad);
        Metodos_De_Pagos Modificar(Metodos_De_Pagos entidad);
        Metodos_De_Pagos Borrar(Metodos_De_Pagos entidad);
    }
}