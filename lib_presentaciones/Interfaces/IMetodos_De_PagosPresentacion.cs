using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IMetodos_De_PagosPresentacion
    {
        Task<List<Metodos_De_Pagos>> Listar();
        Task<List<Metodos_De_Pagos>> Buscar(Metodos_De_Pagos entidad, string tipo);
        Task<Metodos_De_Pagos> Guardar(Metodos_De_Pagos entidad);
        Task<Metodos_De_Pagos> Modificar(Metodos_De_Pagos entidad);
        Task<Metodos_De_Pagos> Borrar(Metodos_De_Pagos entidad);
    }
}