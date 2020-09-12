using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.StockValidation
{
    public class StockUpdateValidation : AbstractValidator<Stock>
    {
        private IStockRepository _stockRepository;

        public StockUpdateValidation(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidateName)
                .WithMessage("Name is being used");

            RuleFor(x => x)
                .MustAsync(ValidateId)
                .WithMessage("Invalid Id");
        }

        private async Task<bool> ValidateName(Stock stock, CancellationToken cancellationToken)
        {
            var valstock = await _stockRepository.GetByNameAsync(stock.Name);

            return valstock?.Name != stock.Name;
        }

        private async Task<bool> ValidateId(Stock stock, CancellationToken cancellationToken)
        {
            var valstock = await _stockRepository.GetByNameAsync(stock.Name);

            return valstock?.Id != stock.Id ? false : true;
        }
    }
}
