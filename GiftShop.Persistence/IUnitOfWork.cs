namespace GiftShop.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : class;

        void Commit();
    }
}