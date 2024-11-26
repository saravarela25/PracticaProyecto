using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IMascotas_ClientesRepositorio
    {
        void Configurar(string string_conexion);
        List<Mascotas_Clientes> Listar();
        List<Mascotas_Clientes> Buscar(Expression<Func<Mascotas_Clientes, bool>> condiciones);
        Mascotas_Clientes Guardar(Mascotas_Clientes entidad);
        Mascotas_Clientes Modificar(Mascotas_Clientes entidad);
        Mascotas_Clientes Borrar(Mascotas_Clientes entidad);
    }
}