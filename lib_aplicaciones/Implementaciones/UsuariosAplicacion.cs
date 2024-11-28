using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IUsuariosRepositorio? iRepositorio = null;

        public UsuariosAplicacion(IUsuariosRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Usuarios> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Usuarios> Buscar(Usuarios entidad, string tipo)
        {
            Expression<Func<Usuarios, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "EMAIL":
                    condiciones = x => x.Email != null && x.Email.Contains(entidad.Email!);
                    break;

                case "CONTRASEÑA":
                    condiciones = x => x.Contraseña != null && x.Contraseña.Contains(entidad.Contraseña!);
                    break;

                case "COMPLEJA":
                    condiciones = x => (x.Contraseña != null && x.Contraseña.Contains(entidad.Contraseña!)) ||
                                       (x.Email != null && x.Email.Contains(entidad.Email!));
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }

        public Usuarios Modificar(Usuarios entidad)
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
