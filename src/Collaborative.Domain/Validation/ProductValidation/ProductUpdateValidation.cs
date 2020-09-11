using Collaborative.Domain.Interfaces.Repository;
using Collaborative.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Collaborative.Domain.Validation.ProductValidation
{
    public class ProductUpdateValidation : AbstractValidator<Product>
    {
        private IProductRepository _productRepository;

        public ProductUpdateValidation(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id cannot be null or empty");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name cannot be null or empty");

            RuleFor(x => x.UnityPrice)
                .NotEmpty()
                .NotNull()
                .WithMessage("Unity price cannot be null or empty");

            RuleFor(x => x)
                .MustAsync(ValidationName)
                .WithMessage("Name is being used");

        }

        private async Task<bool> ValidationName(Product product, CancellationToken cancellationToken)
        {
            var productRepository = await _productRepository.GetByNameAsync(product.Name);

            return productRepository?.Id != product.Id ? false : true;
        }
    }
}