using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IFacturasRepositorio? iRepositorio = null;

        public FacturasAplicacion(IFacturasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Facturas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Facturas> Buscar(Facturas entidad, string tipo)
        {
           
            Expression<Func<Facturas, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "NUM_FACTURA":condiciones = x => x.Num_Factura == entidad.Num_Factura;
                    break;

                case "IVA":condiciones = x => x.IVA == entidad.IVA;
                    break;

                case "TOTAL":condiciones = x => x.Total == entidad.Total;
                    break;

                case "FECHA":condiciones = x => x.Fecha == entidad.Fecha;
                    break;

                case "COMPLEJA":condiciones = x =>
                        (entidad.Num_Factura > 0 && x.Num_Factura == entidad.Num_Factura) ||
                        (entidad.IVA > 0 && x.IVA == entidad.IVA) ||
                        (entidad.Total > 0 && x.Total == entidad.Total) ||
                        (entidad.Fecha != null && x.Fecha == entidad.Fecha);
                    break;
                default:
                    
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }


        public Facturas Modificar(Facturas entidad)
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