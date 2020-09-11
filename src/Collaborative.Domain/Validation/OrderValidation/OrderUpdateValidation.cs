using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.OrderValidation
{
    public class OrderUpdateValidation : AbstractValidator<Order>
    {
        private IOrderRepository _orderRepository;

        public OrderUpdateValidation(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

            RuleFor(x => x.Id)
               .NotNull()
               .NotEmpty()
               .WithMessage("Id cannot be null or empty");

            RuleFor(x => x.Status)
                .Must(x => x.Equals(1) || x.Equals(0))
                .WithMessage("Status invalid");

            RuleFor(x => x.Total)
               .NotNull()
               .NotEmpty()
               .WithMessage("Total cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationId)
                .WithMessage("Invalid Id");
        }

        private async Task<bool> ValidationId(Order order, CancellationToken cancellationToken)
        {
            var orderRepository = await _orderRepository.GetByIdAsync(order.Id);

            return order.Id != orderRepository.Id ? false : true;
        }
    }
}