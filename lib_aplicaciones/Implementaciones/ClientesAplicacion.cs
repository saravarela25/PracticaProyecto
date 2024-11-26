using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IClientesRepositorio? iRepositorio = null;

        public ClientesAplicacion(IClientesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Clientes Guardar(Clientes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Clientes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Clientes> Buscar(Clientes entidad, string tipo)
        {
            Expression<Func<Clientes, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "NOMBRE":
                    condiciones = x => x.Nombre != null && x.Nombre.Contains(entidad.Nombre!);
                    break;

                case "NUMERO":
                    condiciones = x => x.Numero != null && x.Numero.Contains(entidad.Numero!);
                    break;

                case "CEDULA":
                    condiciones = x => x.Cedula != null && x.Cedula.Contains(entidad.Cedula!);
                    break;

                case "EMAIL":
                    condiciones = x => x.Email != null && x.Email.Contains(entidad.Email!);
                    break;

                case "COMPLEJA":
                    condiciones = x => (x.Nombre != null && x.Nombre.Contains(entidad.Nombre!)) ||
                                       (x.Numero != null && x.Numero.Contains(entidad.Numero!)) ||
                                       (x.Cedula != null && x.Cedula.Contains(entidad.Cedula!)) ||
                                       (x.Email != null && x.Email.Contains(entidad.Email!));
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }

        public Clientes Modificar(Clientes entidad)
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
