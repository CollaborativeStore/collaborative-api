using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.StockValidation
{
    public class StockInsertValidation : AbstractValidator<Stock>
    {
        private IStockRepository _stockRepository;

        public StockInsertValidation(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidateName)
                .WithMessage("Name is being used");
        }

        private async Task<bool> ValidateName(Stock stock, CancellationToken cancellationToken)
        {
            var valstock = await _stockRepository.GetByNameAsync(stock.Name);

            return valstock?.Name != stock.Name;
        }
    }
}
