using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IDetalles_FacturasRepositorio
    {
        void Configurar(string string_conexion);
        List<Detalles_Facturas> Listar();
        List<Detalles_Facturas> Buscar(Expression<Func<Detalles_Facturas, bool>> condiciones);
        Detalles_Facturas Guardar(Detalles_Facturas entidad);
        Detalles_Facturas Modificar(Detalles_Facturas entidad);
        Detalles_Facturas Borrar(Detalles_Facturas entidad);
    }
}