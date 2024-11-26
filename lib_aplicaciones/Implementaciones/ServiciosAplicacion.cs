using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class ServiciosAplicacion : IServiciosAplicacion
    {
        private IServiciosRepositorio? iRepositorio = null;

        public ServiciosAplicacion(IServiciosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Servicios Borrar(Servicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Servicios Guardar(Servicios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Servicios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Servicios> Buscar(Servicios entidad, string tipo)
        {
            Expression<Func<Servicios, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "TIPO_SERVICIO": condiciones = x => x.Tipo_Servicio != null && x.Tipo_Servicio.Contains(entidad.Tipo_Servicio!);break;

                case "DESCRIPCION": condiciones = x => x.Descripcion != null && x.Descripcion.Contains(entidad.Descripcion!); break;

                case "PRECIO": condiciones = x => x.Precio >= entidad.Precio; break;

                case "COMPLEJA":
                    condiciones = x => (x.Tipo_Servicio != null && x.Tipo_Servicio.Contains(entidad.Tipo_Servicio!)) ||
                                       (x.Descripcion != null && x.Descripcion.Contains(entidad.Descripcion!)) ||
                                       (x.Precio >= entidad.Precio);
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }


        public Servicios Modificar(Servicios entidad)
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