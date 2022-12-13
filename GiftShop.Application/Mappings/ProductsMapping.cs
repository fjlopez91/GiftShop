using AutoMapper;
using GiftShop.Application.Dtos;
using GiftShop.Domain.Entities;

namespace GiftShop.Application.Mappings
{
    public sealed class ProductsMapping : Profile
    {
        public ProductsMapping()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(x => x.Id, e => e.Ignore())
                .ReverseMap();

            CreateMap<ProductDto, Product>()
                .ReverseMap();
        }
    }
}