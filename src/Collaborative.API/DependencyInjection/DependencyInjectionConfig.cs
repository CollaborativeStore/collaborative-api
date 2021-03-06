﻿using Collaborative.API.Services;
using Collaborative.API.Services.Interfaces;
using Collaborative.API.ViewModels.Collaborative;
using Collaborative.API.ViewModels.Collaborator;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Interfaces.UoW;
using Collaborative.Infra.Context;
using Collaborative.Infra.Repository;
using Collaborative.Infra.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Collaborative.API.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<EntityContext>();
            services.AddHttpContextAccessor();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICollaborativeRepository, CollaborativeRepository>();
            services.AddScoped<ICollaboratorRepository, CollaboratorRepository>();
            services.AddScoped<IFinancialAccountRepository, FinancialAccountRepository>();
            services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockRepository, StockRepository>();

            services.AddScoped<ICollaborativeService, CollaborativeService>();
            services.AddScoped<ICollaboratorService, CollaboratorService>();

            services.AddScoped<IUserService<CollaborativeInsertViewModel>, UserService<CollaborativeInsertViewModel>>();
            services.AddScoped<IUserService<CollaboratorInsertViewModel>, UserService<CollaboratorInsertViewModel>>();

            services.AddScoped<ISessionService, SessionService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
