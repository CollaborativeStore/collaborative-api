using Collaborative.Domain.Models;
using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Collaborative.Infra.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private EntityContext _entityContext;

        public PaymentRepository(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            var payments = _entityContext.Payments
                .Where(x => x.Paid.Equals(null))
                .Include(x => x.FinancialAccount)
                .Include(x => x.Order)
                .ToListAsync();

            return await payments;
        }

        public async Task<IEnumerable<Payment>> GetAllByFinancialAccountIdAsync(int id)
        {
            var payments = _entityContext.Payments
                .Where(x => x.Paid.Equals(null) && x.FinancialAccountId.Equals(id))
                .Include(x => x.FinancialAccount)
                .Include(x => x.Order)
                .ToListAsync();

            return await payments;
        }

        public async Task<IEnumerable<Payment>> GetAllByOrderIdAsync(int id)
        {
            var payments = _entityContext.Payments
                .Where(x => x.Paid.Equals(null) && x.OrderId.Equals(id))
                .Include(x => x.FinancialAccount)
                .Include(x => x.Order)
                .ToListAsync();

            return await payments;
        }

        public async Task<IEnumerable<Payment>> GetAllPaidAsync()
        {
            var payments = _entityContext.Payments
                .Where(x => x.Paid != null)
                .Include(x => x.FinancialAccount)
                .Include(x => x.Order)
                .ToListAsync();

            return await payments;
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
            var payment = _entityContext.Payments
                .Where(x => x.Paid.Equals(null) && x.Id.Equals(id))
                .Include(x => x.FinancialAccount)
                .Include(x => x.Order)
                .FirstOrDefaultAsync();

            return await payment;
        }
    }
}
