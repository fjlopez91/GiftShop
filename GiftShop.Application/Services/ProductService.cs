using AutoMapper;
using GiftShop.Application.Dtos;
using GiftShop.Application.Validators;
using GiftShop.Domain.Entities;
using GiftShop.Persistence;

namespace GiftShop.Application.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var entities = await _unitOfWork.ProductRepository.GetAll();

            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<ProductDto> GetProductById(Guid productId)
        {
            var validator = new GuidValidator();
            var validationIdResult = await validator.ValidateAsync(productId);

            if (validationIdResult.IsValid == true)
            {
                var entity = GetProduct(productId);

                return _mapper.Map<ProductDto>(entity);
            }

            return default!;
        }

        public async Task<bool> Add(CreateProductDto model)
        {
            var validator = new CreateProductDtoValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (validationResult.IsValid == true)
            {
                var entity = _mapper.Map(model, new Product());

                _unitOfWork.ProductRepository.Add(entity);
                return await _unitOfWork.Complete();
            }
            else
            {
                return default!;
            }
        }

        public async Task<bool> Update(Guid id, ProductDto model)
        {
            var idValidator = new GuidValidator();
            var validationIdResult = await idValidator.ValidateAsync(id);

            var productValidator = new ProductDtoValidator();
            var validationModelResult = await productValidator.ValidateAsync(model);

            if (validationIdResult.IsValid && validationModelResult.IsValid)
            {
                var product = await GetProduct(id);

                _mapper.Map(model, product);
                _unitOfWork.ProductRepository.Update(product);
                return await _unitOfWork.Complete();
            }
            else
            {
                return default;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            var validator = new GuidValidator();
            var validationResult = await validator.ValidateAsync(id);

            if (validationResult.IsValid == true)
            {
                var entity = await GetProduct(id);
                _unitOfWork.ProductRepository.Delete(entity);
                return await _unitOfWork.Complete();
            }
            else
            {
                return default!;
            }
        }

        private Task<Product> GetProduct(Guid id)
        {
            var product = _unitOfWork.ProductRepository.Get(id);
            if (product == null) throw new KeyNotFoundException(AppResource.ProductNotFound);
            return product;
        }
    }
}