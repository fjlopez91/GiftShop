using GiftShop.Application.Services;
using MediatR;

namespace GiftShop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private IProductService _productService;

        public CreateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.Add(request.CreateProductDto);

            return await Task.FromResult(result);
        }
    }
}