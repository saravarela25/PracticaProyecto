using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class Metodos_De_PagosAplicacion : IMetodos_De_PagosAplicacion
    {
        private IMetodos_De_PagosRepositorio? iRepositorio = null;

        public Metodos_De_PagosAplicacion(IMetodos_De_PagosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Metodos_De_Pagos Borrar(Metodos_De_Pagos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Metodos_De_Pagos Guardar(Metodos_De_Pagos entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Metodos_De_Pagos> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Metodos_De_Pagos> Buscar(Metodos_De_Pagos entidad, string tipo)
        {
            Expression<Func<Metodos_De_Pagos, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "TIPO_METODO_PAGO":
                    condiciones = x => x.Tipo_Metodo_Pago!.Contains(entidad.Tipo_Metodo_Pago!);
                    break;

                case "COMPLEJA":
                    condiciones = x =>
                        (!string.IsNullOrEmpty(entidad.Tipo_Metodo_Pago) && x.Tipo_Metodo_Pago!.Contains(entidad.Tipo_Metodo_Pago)) ||
                        (entidad.Id > 0 && x.Id == entidad.Id);
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }
            return this.iRepositorio!.Buscar(condiciones);
        }



        public Metodos_De_Pagos Modificar(Metodos_De_Pagos entidad)
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
