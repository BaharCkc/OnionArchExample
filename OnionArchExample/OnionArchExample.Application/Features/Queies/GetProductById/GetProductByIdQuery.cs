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

namespace OnionArchExample.Application.Features.Queies.GetProductById
{
    public class GetProductByIdQuery : IRequest<ServiceResponse<GetProductByIdDto>>
    {
        public Guid Id { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdDto>>
        {
            private readonly IProductRepository _productRepository;

            public GetProductByIdQueryHandler(IProductRepository productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<ServiceResponse<GetProductByIdDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetById(request.Id);
                var map = product.Adapt<GetProductByIdDto>();
                return new ServiceResponse<GetProductByIdDto>(map);
            }
        }
    }
}
