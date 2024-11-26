using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IClientesRepositorio
    {
        void Configurar(string string_conexion);
        List<Clientes> Listar();
        List<Clientes> Buscar(Expression<Func<Clientes, bool>> condiciones);
        Clientes Guardar(Clientes entidad);
        Clientes Modificar(Clientes entidad);
        Clientes Borrar(Clientes entidad);

    }
}
