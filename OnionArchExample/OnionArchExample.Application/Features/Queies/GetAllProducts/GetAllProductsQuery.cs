using Mapster;
using MediatR;
using OnionArchExample.Application.DTOs;
using OnionArchExample.Application.Interfaces.Repository;
using OnionArchExample.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchExample.Application.Features.Queies.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ServiceResponse<List<ProductViewDto>>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository _productRepository;

            public GetAllProductsQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAll();

                //return products.Select(b => new ProductViewDto()
                //{
                //    Id = b.Id,
                //    Name = b.Name
                //}).ToList();
                var map = products.Select(b => b.Adapt<ProductViewDto>()).ToList();

                return new ServiceResponse<List<ProductViewDto>>(map);
            }
        }
    }
}
