using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IMetodos_De_PagosAplicacion
    {
        void Configurar(string string_conexion);
        List<Metodos_De_Pagos> Buscar(Metodos_De_Pagos entidad, string tipo);
        List<Metodos_De_Pagos> Listar();
        Metodos_De_Pagos Guardar(Metodos_De_Pagos entidad);
        Metodos_De_Pagos Modificar(Metodos_De_Pagos entidad);
        Metodos_De_Pagos Borrar(Metodos_De_Pagos entidad);
    }
}