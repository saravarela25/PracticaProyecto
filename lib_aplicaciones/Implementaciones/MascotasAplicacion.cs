using lib_entidades;
using lib_aplicaciones.Interfaces;
using lib_repositorios.Interfaces;
using System.Linq.Expressions;
using lib_entidades.Modelos;

namespace lib_aplicaciones.Implementaciones
{
    public class MascotasAplicacion : IMascotasAplicacion
    {
        private IMascotasRepositorio? iRepositorio = null;

        public MascotasAplicacion(IMascotasRepositorio iRepositorio)
        {
            this.iRepositorio = iRepositorio;
        }

        public void Configurar(string string_conexion)
        {
            this.iRepositorio!.Configurar(string_conexion);
        }

        public Mascotas Borrar(Mascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id == 0)
                throw new Exception("lbNoSeGuardo");

            entidad = iRepositorio!.Borrar(entidad);
            return entidad;
        }

        public Mascotas Guardar(Mascotas entidad)
        {
            if (entidad == null || !entidad.Validar())
                throw new Exception("lbFaltaInformacion");

            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");

            entidad = iRepositorio!.Guardar(entidad);
            return entidad;
        }

        public List<Mascotas> Listar()
        {
            return iRepositorio!.Listar();
        }

        public List<Mascotas> Buscar(Mascotas entidad, string tipo)
        {
            Expression<Func<Mascotas, bool>>? condiciones = null;

            switch (tipo.ToUpper())
            {
                case "Cod_Mascota": condiciones = x => x.Cod_Mascota != null && x.Cod_Mascota.Contains(entidad.Cod_Mascota!); break;

                case "NOMBRE": condiciones = x => x.Nombre != null && x.Nombre.Contains(entidad.Nombre!); break;

                case "EDAD": condiciones = x => x.Edad >= entidad.Edad; break;

                case "COMPLEJA":
                    condiciones = x => (x.Cod_Mascota != null && x.Cod_Mascota.Contains(entidad.Cod_Mascota!)) ||
                                       (x.Nombre != null && x.Nombre.Contains(entidad.Nombre!)) ||
                                       (x.Edad >= entidad.Edad);
                    break;

                default:
                    condiciones = x => x.Id == entidad.Id;
                    break;
            }

            return this.iRepositorio!.Buscar(condiciones);
        }


        public Mascotas Modificar(Mascotas entidad)
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