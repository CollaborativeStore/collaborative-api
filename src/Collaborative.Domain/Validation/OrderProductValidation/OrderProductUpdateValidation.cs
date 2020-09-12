using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.OrderProductValidation
{
    public class OrderProductUpdateValidation : AbstractValidator<OrderProduct>
    {
        private IOrderProductRepository _orderProductRepository;

        public OrderProductUpdateValidation(IOrderProductRepository orderProductRepository)
        {
            _orderProductRepository = orderProductRepository;

            RuleFor(x => x.OrderId)
               .NotEmpty()
               .NotNull()
               .WithMessage("OrderId cannot be null or empty");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .NotNull()
                .WithMessage("ProductId cannot be null or empty");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantity cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationOrder)
                .WithMessage("Cannot modify the Id");
        }

        private async Task<bool> ValidationOrder(OrderProduct orderProduct, CancellationToken cancellationToken)
        {
            var order = await _orderProductRepository.GetByIdAsync(orderProduct.Id);

            return order?.Id != orderProduct.Id ? false : true;
        }
    }
}
