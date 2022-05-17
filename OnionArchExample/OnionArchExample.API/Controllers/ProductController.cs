using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchExample.Application.Features.Commands.CreateProduct;
using OnionArchExample.Application.Features.Queies.GetAllProducts;
using OnionArchExample.Application.Features.Queies.GetProductById;
using OnionArchExample.Application.Interfaces.Repository;

namespace OnionArchExample.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductsQuery();
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id };
            return Ok(await _mediator.Send(query));
        }
    }
}
