using AutoMapper;
using Colegio.Infraestructura.Database.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Colegio.Configuracion.Configuracion
{
    public class Register
    {
        public static void Configuracion(IServiceCollection services,IConfiguration configuration)
        {
            #region[Configuracion de AUTO Mapper]
            var configMapper = new MapperConfiguration(cfg => cfg.AddProfile(new PerfilAutoMapper()));
            var mapper = configMapper.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region [Inicializar Conexion con Base de Datos]
            services.AddTransient<ApplicationContext, ApplicationContext>();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddSingleton<IConfiguration>(configuration);
            #endregion

            #region [Registro Inyección de Dependencias]
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.Load("Colegio.Dominio"),
                Assembly.Load("Colegio.Infraestructura"),
                Assembly.Load("Colegio.Comunes"),
            };
            
            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Repository") ||
                       c.Name.EndsWith("Service") ||
                       c.Name.EndsWith("Resource"))
                .AsPublicImplementedInterfaces();
            #endregion
        }
    }
}
