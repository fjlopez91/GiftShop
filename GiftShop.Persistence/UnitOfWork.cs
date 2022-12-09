using GiftShop.Persistence.Contexts;

namespace GiftShop.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyAppDbContext _context { get; set; }

        private readonly Dictionary<string, object> repositories = new();

        public UnitOfWork(MyAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
            repositories.Clear();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            string typeName = typeof(T).Name;
            if (repositories.Keys.Contains(typeName))
            {
                return repositories[typeName] as IRepository<T> ?? default!;
            }
            IRepository<T> newRepository = new Repository<T>(_context);

            repositories.Add(typeName, newRepository);
            return newRepository;
        }
    }
}