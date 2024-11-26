using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class Mascotas_ClientesAplicacion : IMascotas_ClientesAplicacion
    {
        private IMascotas_ClientesRepositorio? iRepositorio = null;

        public Mascotas_ClientesAplicacion(IMascotas_ClientesRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Mascotas_Clientes Borrar(Mascotas_Clientes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Mascotas_Clientes Guardar(Mascotas_Clientes entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Mascotas_Clientes> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Mascotas_Clientes> Buscar(Mascotas_Clientes entidad, string tipo)
        {
            Expression<Func<Mascotas_Clientes, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                
                case "CLIENTE": condiciones = x => x.Cliente >= entidad.Cliente; break;

                case "MASCOTA": condiciones = x => x.Mascota >= entidad.Mascota; break;

                case "COMPLEJA":
                    condiciones = x => (x.Cliente >= entidad.Cliente) ||
                                       (x.Mascota >= entidad.Mascota);
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }


        public Mascotas_Clientes Modificar(Mascotas_Clientes entidad)
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