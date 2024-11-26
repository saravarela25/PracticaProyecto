using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IServiciosRepositorio
    {
        void Configurar(string string_conexion);
        List<Servicios> Listar();
        List<Servicios> Buscar(Expression<Func<Servicios, bool>> condiciones);
        Servicios Guardar(Servicios entidad);
        Servicios Modificar(Servicios entidad);
        Servicios Borrar(Servicios entidad);
    }
}