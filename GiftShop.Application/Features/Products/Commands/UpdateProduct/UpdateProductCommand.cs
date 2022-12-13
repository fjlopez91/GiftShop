using GiftShop.Application.Dtos;
using MediatR;

namespace GiftShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public ProductDto UpdateProductDto { get; set; } = default!;

        public Guid Id { get; set; }
    }
}