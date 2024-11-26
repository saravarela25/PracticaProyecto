using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IDetalles_FacturasAplicacion
    {
        void Configurar(string string_conexion);
        List<Detalles_Facturas> Buscar(Detalles_Facturas entidad, string tipo);
        List<Detalles_Facturas> Listar();
        Detalles_Facturas Guardar(Detalles_Facturas entidad);
        Detalles_Facturas Modificar(Detalles_Facturas entidad);
        Detalles_Facturas Borrar(Detalles_Facturas entidad);
    }
}