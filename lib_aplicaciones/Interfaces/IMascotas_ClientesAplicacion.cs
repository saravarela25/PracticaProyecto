using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IMascotas_ClientesAplicacion
    {
        void Configurar(string string_conexion);
        List<Mascotas_Clientes> Buscar(Mascotas_Clientes entidad, string tipo);
        List<Mascotas_Clientes> Listar();
        Mascotas_Clientes Guardar(Mascotas_Clientes entidad);
        Mascotas_Clientes Modificar(Mascotas_Clientes entidad);
        Mascotas_Clientes Borrar(Mascotas_Clientes entidad);
    }
}