using GiftShop.Domain.SeedWork;

namespace GiftShop.Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Location { get; set; } = default!;
        public Guid ProductId { get; set; } = default!;
        public virtual Product Product { get; set; } = default!;
    }
}