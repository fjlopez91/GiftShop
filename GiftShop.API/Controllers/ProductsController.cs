using GiftShop.API.Authorization;
using GiftShop.Application.Dtos;
using GiftShop.Application.Features.Products.Commands.CreateProduct;
using GiftShop.Application.Features.Products.Commands.DeleteProduct;
using GiftShop.Application.Features.Products.Commands.UpdateProduct;
using GiftShop.Application.Features.Products.Queries.GetProduct;
using GiftShop.Application.Features.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiftShop.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]        
        public async Task<IActionResult> GetProducts()
        {
            var results = await _mediator.Send(new GetProductsQuery());

            return Ok(results);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var result = await _mediator.Send(new GetProductQuery
            {
                Id = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var result = await _mediator.Send(new CreateProductCommand
            {
                CreateProductDto = createProductDto
            });

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto updatePostDto)
        {
            var result = await _mediator.Send(new UpdateProductCommand
            {
                UpdateProductDto = updatePostDto,
                Id = id
            });

            if (!result)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand
            {
                Id = id
            });

            return Ok(result);
        }
    }
}