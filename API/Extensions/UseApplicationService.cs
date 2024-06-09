using Core.Interfaces;
using Infrastructure.Repository;

namespace API.Extensions
{
    public static class UseApplicationService
    {
        public static IServiceCollection UseApplicationServiceAdd(this IServiceCollection Services)
        {
            Services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            Services.AddScoped<IProductRepository, ProductRepository>();


            return Services;
        }
    }
}
