using lib_entidades.Modelos;

namespace lib_aplicaciones.Interfaces
{
    public interface IMascotasAplicacion
    {
        void Configurar(string string_conexion);
        List<Mascotas> Buscar(Mascotas entidad, string tipo);
        List<Mascotas> Listar();
        Mascotas Guardar(Mascotas entidad);
        Mascotas Modificar(Mascotas entidad);
        Mascotas Borrar(Mascotas entidad);
    }
}