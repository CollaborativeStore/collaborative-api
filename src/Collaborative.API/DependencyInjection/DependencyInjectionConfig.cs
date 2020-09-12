using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using Collaborative.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Collaborative.API.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EntityContext>();

            services.AddScoped<ICollaborativeRepository, CollaborativeRepository>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<IFinancialAccountRepository, FinancialAccountRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            return services;
        }
    }
}
