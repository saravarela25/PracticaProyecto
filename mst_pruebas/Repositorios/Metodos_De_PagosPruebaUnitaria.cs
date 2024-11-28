using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class Metodos_De_PagosPruebaUnitaria
    {
        private IMetodos_De_PagosRepositorio? iRepositorio = null;
        private Metodos_De_Pagos? entidad = null;

        public Metodos_De_PagosPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-S2MM97P\\DEV;database=db_TiendaMascotas;Integrated Security=True;TrustServerCertificate=True;";
            iRepositorio = new Metodos_De_PagosRepositorio(conexion);
        }

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Listar();
            Buscar();
            Modificar();
            Borrar();


        }

        private void Guardar()
        {
            entidad = new Metodos_De_Pagos()
            {
               Tipo_Metodo_Pago="efectivo",

            };
            entidad = iRepositorio!.Guardar(entidad);
            Assert.IsTrue(entidad.Id != 0);
        }

        private void Listar()
        {
            var lista = iRepositorio!.Listar();
            Assert.IsTrue(lista.Count > 0);
        }
        public void Buscar()
        {
            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }
        private void Modificar()
        {
            entidad!.Tipo_Metodo_Pago = "tarjeta";
            entidad = iRepositorio!.Modificar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count > 0);
        }

        private void Borrar()
        {
            entidad = iRepositorio!.Borrar(entidad!);

            var lista = iRepositorio!.Buscar(x => x.Id == entidad!.Id);
            Assert.IsTrue(lista.Count == 0);
        }

    }
    
}
