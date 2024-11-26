using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class Detalles_FacturasAplicacion : IDetalles_FacturasAplicacion
    {
        private IDetalles_FacturasRepositorio? iRepositorio = null;

        public Detalles_FacturasAplicacion(IDetalles_FacturasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Detalles_Facturas Borrar(Detalles_Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Detalles_Facturas Guardar(Detalles_Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Detalles_Facturas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Detalles_Facturas> Buscar(Detalles_Facturas entidad, string tipo)
        {
            Expression<Func<Detalles_Facturas, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "ESTADO": condiciones = x => x.Estado != null && x.Estado.Contains(entidad.Estado!);break;

                case "FECHA": condiciones = x => x.Fecha_Servicio.HasValue &&
                                       x.Fecha_Servicio.Value.Date == entidad.Fecha_Servicio!.Value.Date; break;

                case "PRECIO": condiciones = x => x.Precio_Venta >= entidad.Precio_Venta;break;

                case "COMPLEJA":
                    condiciones = x => (x.Estado != null && x.Estado.Contains(entidad.Estado!)) ||
                                       (x.Fecha_Servicio.HasValue && entidad.Fecha_Servicio.HasValue &&
                                        x.Fecha_Servicio.Value.Date == entidad.Fecha_Servicio.Value.Date) ||
                                       (x.Precio_Venta >= entidad.Precio_Venta);
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }

        public Detalles_Facturas Modificar(Detalles_Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Modificar(entidad);
            return entidad;
        }
    }
}