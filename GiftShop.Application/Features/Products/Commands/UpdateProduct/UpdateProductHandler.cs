using GiftShop.Application.Services;
using MediatR;

namespace GiftShop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productService.Update(request.Id, request.UpdateProductDto);

            return await Task.FromResult(result);
        }
    }
}