using Collaborative.Domain.Models;
using Collaborative.Infra.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Collab = Collaborative.Domain.Models.Collaborative;

namespace Collaborative.Infra.Context
{
    public class EntityContext : IdentityDbContext
    {
        public DbSet<Collab> Collaboratives { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<OrderProduct> orderProducts { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) 
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityContext).Assembly);

            modelBuilder.ApplyConfiguration(new CollaborativeMap());
            modelBuilder.ApplyConfiguration(new CollaboratorMap());
            modelBuilder.ApplyConfiguration(new FinancialAccountMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new StockMap());
            modelBuilder.ApplyConfiguration(new OrderProductMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
