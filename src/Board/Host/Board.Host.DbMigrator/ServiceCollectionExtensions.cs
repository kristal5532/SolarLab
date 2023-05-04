using Microsoft.EntityFrameworkCore;

namespace Board.Host.DbMigrator
{

    public static class ServiceCollectionExtensions
    {

        /// <param name="services">Сервисы.</param>
        /// <param name="configuration">Конфигурация.</param>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbConnections(configuration);
            return services;
        }


        private static IServiceCollection ConfigureDbConnections(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgresBoardDb");
            services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(connectionString));
            return services;
        }
    }
}
