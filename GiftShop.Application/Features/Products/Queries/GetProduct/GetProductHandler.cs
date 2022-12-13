using GiftShop.Application.Dtos;
using GiftShop.Application.Services;
using MediatR;

namespace GiftShop.Application.Features.Products.Queries.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductQuery, ProductDto>
    {
        private IProductService _productService;

        public GetProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductById(request.Id);
        }
    }
}