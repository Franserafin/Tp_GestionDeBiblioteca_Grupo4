using AccesoDatos.Data;
using AccesoDatos.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            ServiceCollection services = new();
            services.AddDbContext<AplicationDbContext>(options =>
                options.UseSqlite("Data Source=biblioteca.db"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<FormPrincipal>();
            services.AddTransient<FormLibros>();
            services.AddTransient<FormClientes>();
            services.AddTransient<FormAlquileres>();
            services.AddTransient<FormReportes>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<AplicationDbContext>()
                    .Database.EnsureCreated();
            }

            Application.Run(serviceProvider.GetRequiredService<FormPrincipal>());
        }
    }
}