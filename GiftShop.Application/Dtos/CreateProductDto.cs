using GiftShop.Domain.Entities;

namespace GiftShop.Application.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Company { get; set; } = default!;
        public decimal Price { get; set; }
        public List<Photo> Photos { get; set; } = default!;
    }
}