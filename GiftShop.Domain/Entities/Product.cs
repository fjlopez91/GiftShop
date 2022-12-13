using GiftShop.Domain.SeedWork;

namespace GiftShop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Company { get; set; } = default!;
        public decimal Price { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } = default!;
    }
}