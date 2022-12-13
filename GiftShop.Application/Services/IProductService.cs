using GiftShop.Application.Dtos;

namespace GiftShop.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();

        Task<ProductDto> GetProductById(Guid productId);

        Task<bool> Add(CreateProductDto model);

        Task<bool> Update(Guid id, ProductDto model);

        Task<bool> Delete(Guid id);
    }
}