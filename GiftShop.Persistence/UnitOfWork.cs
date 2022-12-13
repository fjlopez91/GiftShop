using GiftShop.Domain.Entities;
using GiftShop.Domain.Entities.Identity;
using GiftShop.Persistence.Contexts;

namespace GiftShop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppDbContext _context;

        public UnitOfWork(MyAppDbContext context)
        {
            _context = context;
        }

        #region repositories

        private readonly IRepository<Product> productRepository = default!;        
        public IRepository<Product> ProductRepository => productRepository ?? new Repository<Product>(_context);

        private readonly IRepository<User> userRepository = default!;
        public IRepository<User> UserRepository => userRepository ?? new Repository<User>(_context);

        #endregion

        public async Task<bool> Complete()
            => await _context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            _context.Dispose();
        }        
    }
}