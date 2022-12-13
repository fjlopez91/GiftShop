using GiftShop.Application.Dtos;
using MediatR;

namespace GiftShop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
    }
}