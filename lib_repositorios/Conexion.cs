using lib_entidades.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace lib_repositorios
{
    public class Conexion : DbContext
    {
        public string? StringConnection { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConnection!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected DbSet<Mascotas>? Mascotas { get; set; }
        protected DbSet<Clientes>? Clientes { get; set; }
        protected DbSet<Detalles_Facturas>? Detalles_Facturas { get; set; }
        protected DbSet<Facturas>? Facturas { get; set; }
        protected DbSet<Mascotas_Clientes>? Mascotas_Clientes { get; set; }
        protected DbSet<Metodos_De_Pagos>? Metodos_De_Pagos { get; set; }

        protected DbSet<Servicios>? Servicios { get; set; }


        public virtual DbSet<T> ObtenerSet<T>() where T : class, new()
        {
            return this.Set<T>();
        }

        public virtual List<T> Listar<T>() where T : class, new()
        {
            return this.Set<T>().ToList();
        }

        public virtual List<T> Buscar<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Where(condiciones).ToList();
        }
        public virtual List<Detalles_Facturas> Buscar(Expression<Func<Detalles_Facturas, bool>> condiciones)
        {
            return this.Set<Detalles_Facturas>()
                .Include(x => x._Factura)
                .Include(x => x._Mascota)
                .Include(x => x._Servicio)
                .Where(condiciones)
                .ToList();
        }

        public virtual bool Existe<T>(Expression<Func<T, bool>> condiciones) where T : class, new()
        {
            return this.Set<T>().Any(condiciones);
        }

        public virtual void Guardar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Add(entidad);
        }

        public virtual void Modificar<T>(T entidad) where T : class
        {
            var entry = this.Entry(entidad);
            entry.State = EntityState.Modified;
        }

        public virtual void Borrar<T>(T entidad) where T : class, new()
        {
            this.Set<T>().Remove(entidad);
        }

        public virtual void Separadar<T>(T entidad) where T : class, new()
        {
            this.Entry(entidad).State = EntityState.Detached;
        }

        public virtual void GuardarCambios()
        {
            this.SaveChanges();
        }
    }
}
