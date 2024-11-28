using lib_entidades.Modelos;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;

namespace mst_pruebas.Repositorios
{
    [TestClass]
    public class Detalles_FacturasPruebaUnitaria
    {
        private IDetalles_FacturasRepositorio? iRepositorio = null;
        private Detalles_Facturas? entidad = null;

        public Detalles_FacturasPruebaUnitaria()
        {
            var conexion = new Conexion();
            conexion.StringConnection = "server=DESKTOP-S2MM97P\\DEV;database=db_TiendaMascotas;Integrated Security=True;TrustServerCertificate=True;";
            iRepositorio = new Detalles_FacturasRepositorio(conexion);
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
            entidad = new Detalles_Facturas()
            {
                Fecha_Servicio = DateTime.Now,
                Estado="En Proceso",
                IVA=18.2m,
                Precio_Venta=1400.0m,
                Factura=2,
                Mascota=3,
                Servicio=4,
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
            entidad!.Estado = "Finalizado";
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
