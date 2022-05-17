using Mapster;
using MediatR;
using OnionArchExample.Application.Interfaces.Repository;
using OnionArchExample.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandle : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository _productRepository;

            public CreateProductCommandHandle(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = request.Adapt<Domain.Entities.Product>();
                await _productRepository.Add(product);
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
