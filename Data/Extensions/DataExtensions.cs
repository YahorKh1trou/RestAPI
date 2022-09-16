using Data.Constants;
using Data.Data.EF;
using Data.Data.Repositories;
using Data.Data.Repositories.Contracts;
using Data.Repositories;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IBooksRepository, BooksRepository>()
               .AddScoped<IPeopleRepository, PeopleRepository>()
               .AddScoped<IOrderItemRepository, OrderItemRepository>()
               .AddScoped<IOrderRepository, OrderRepository>()
               .AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetSection(EFConstants.DatabaseConnectionName).Value));
    }
}
