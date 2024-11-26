using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IServiciosPresentacion
    {
        Task<List<Servicios>> Listar();
        Task<List<Servicios>> Buscar(Servicios entidad, string tipo);
        Task<Servicios> Guardar(Servicios entidad);
        Task<Servicios> Modificar(Servicios entidad);
        Task<Servicios> Borrar(Servicios entidad);
    }
}