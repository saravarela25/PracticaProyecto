using lib_entidades.Modelos;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;

namespace lib_repositorios.Implementaciones
{
    public class Detalles_FacturasRepositorio : IDetalles_FacturasRepositorio
    {
        private Conexion? conexion = null;

        public Detalles_FacturasRepositorio(Conexion conexion)
        {
            this.conexion = conexion;
        }

        public void Configurar(string string_conexion)
        {
            this.conexion!.StringConnection = string_conexion;
        }

        public List<Detalles_Facturas> Listar()
        {
            return Buscar(x => x != null);

        }

        public List<Detalles_Facturas> Buscar(Expression<Func<Detalles_Facturas, bool>> condiciones)
        {
            return conexion!.Buscar(condiciones);
        }

        public Detalles_Facturas Guardar(Detalles_Facturas entidad)
        {
            conexion!.Guardar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Detalles_Facturas Modificar(Detalles_Facturas entidad)
        {
            conexion!.Modificar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }

        public Detalles_Facturas Borrar(Detalles_Facturas entidad)
        {
            conexion!.Borrar(entidad);
            conexion!.GuardarCambios();
            return entidad;
        }
    }
}