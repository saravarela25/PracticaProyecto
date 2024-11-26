using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IMascotas_ClientesPresentacion
    {
        Task<List<Mascotas_Clientes>> Listar();
        Task<List<Mascotas_Clientes>> Buscar(Mascotas_Clientes entidad, string tipo);
        Task<Mascotas_Clientes> Guardar(Mascotas_Clientes entidad);
        Task<Mascotas_Clientes> Modificar(Mascotas_Clientes entidad);
        Task<Mascotas_Clientes> Borrar(Mascotas_Clientes entidad);
    }
}