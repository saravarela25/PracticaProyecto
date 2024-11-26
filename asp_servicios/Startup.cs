using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IMascotasRepositorio, MascotasRepositorio>();
            services.AddScoped<IDetalles_FacturasRepositorio, Detalles_FacturasRepositorio>();
            services.AddScoped<IFacturasRepositorio, FacturasRepositorio>();
            services.AddScoped<IMascotas_ClientesRepositorio, Mascotas_ClientesRepositorio>();
            services.AddScoped<IServiciosRepositorio, ServiciosRepositorio>();
            services.AddScoped<IClientesRepositorio, ClientesRepositorio>();
            services.AddScoped<IMetodos_De_PagosRepositorio, Metodos_De_PagosRepositorio>();

            //services.AddScoped<ITiposRepositorio, TiposRepositorio>();
            // Aplicaciones
            services.AddScoped<IDetalles_FacturasAplicacion, Detalles_FacturasAplicacion>();
            services.AddScoped<IMascotasAplicacion, MascotasAplicacion>();
            services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
            services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
            services.AddScoped<IMascotas_ClientesAplicacion, Mascotas_ClientesAplicacion>();
            services.AddScoped<IMetodos_De_PagosAplicacion, Metodos_De_PagosAplicacion>();
            services.AddScoped<IServiciosAplicacion, ServiciosAplicacion>();
            //services.AddScoped<ITiposAplicacion, TiposAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}