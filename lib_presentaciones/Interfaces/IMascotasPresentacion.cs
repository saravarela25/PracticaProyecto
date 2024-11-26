using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IMascotasPresentacion
    {
        Task<List<Mascotas>> Listar();
        Task<List<Mascotas>> Buscar(Mascotas entidad, string tipo);
        Task<Mascotas> Guardar(Mascotas entidad);
        Task<Mascotas> Modificar(Mascotas entidad);
        Task<Mascotas> Borrar(Mascotas entidad);
    }
}