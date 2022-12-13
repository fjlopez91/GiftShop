using GiftShop.Domain.Models;
using System.Linq.Expressions;

namespace GiftShop.Persistence
{
    public interface IRepository<T> where T : class, new()
    {
        Task<T> Get(Guid id);

        Task<T> Find(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task<IEnumerable<T>> GetPage(PageModel pageModel);
    }
}