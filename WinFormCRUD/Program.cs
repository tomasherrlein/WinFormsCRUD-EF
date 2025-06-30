using ApplicationBusiness;
using Data;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WinFormCRUD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            
            ServiceProvider servicesProvider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            FormMain mainForm = servicesProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .Build();

            services.AddDbContext<AsistenciaInvestigadoresDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB")));

            services.AddTransient<FormMain>();
            services.AddTransient<IRepository<Investigador>, InvestigadorRepository>();
        }
    }
}