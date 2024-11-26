using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Mascotas_ClientesRepositorio : IMascotas_ClientesRepositorio
    {
        private Conexion? conexion = null;

        public Mascotas_ClientesRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Mascotas_Clientes> Listar()
        {
            return conexion!.Listar<Mascotas_Clientes>();
        }

        public List<Mascotas_Clientes> Buscar(Expression<Func<Mascotas_Clientes, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Mascotas_Clientes Guardar(Mascotas_Clientes entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Mascotas_Clientes Modificar(Mascotas_Clientes entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Mascotas_Clientes Borrar(Mascotas_Clientes entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}