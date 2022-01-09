using Microsoft.Extensions.DependencyInjection;
using ShopsRUs.Application.Repository;
using ShopsRUs.Persistence.Repository;

namespace ShopsRUs.Persistence
{
    public static class RepositoryExtention
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IInvoiceRepository, InvoiceRepository>();

        }
    }
}
