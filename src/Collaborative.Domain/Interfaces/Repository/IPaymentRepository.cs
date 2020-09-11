using Collaborative.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Collaborative.Domain.Interfaces.Repository
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetAllPaidAsync();
        Task<Payment> GetByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllByFinancialAccountIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllByOrderIdAsync(int id);
    }
}
