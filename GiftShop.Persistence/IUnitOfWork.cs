using GiftShop.Domain.Entities;
using GiftShop.Domain.Entities.Identity;

namespace GiftShop.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<User> UserRepository { get; }

        Task<bool> Complete();
    }
}