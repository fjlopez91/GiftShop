using GiftShop.Application.Dtos;
using MediatR;

namespace GiftShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public CreateProductDto CreateProductDto { get; set; } = default!;
    }
}