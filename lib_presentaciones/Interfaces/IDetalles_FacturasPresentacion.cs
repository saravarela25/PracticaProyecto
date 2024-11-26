using lib_entidades.Modelos;

namespace lib_presentaciones.Interfaces
{
    public interface IDetalles_FacturasPresentacion
    {
        Task<List<Detalles_Facturas>> Listar();
        Task<List<Detalles_Facturas>> Buscar(Detalles_Facturas entidad, string tipo);
        Task<Detalles_Facturas> Guardar(Detalles_Facturas entidad);
        Task<Detalles_Facturas> Modificar(Detalles_Facturas entidad);
        Task<Detalles_Facturas> Borrar(Detalles_Facturas entidad);
    }
}