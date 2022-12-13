using GiftShop.Application.Dtos;
using MediatR;

namespace GiftShop.Application.Features.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}