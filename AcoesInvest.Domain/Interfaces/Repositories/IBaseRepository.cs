using System.Linq.Expressions;

namespace AcoesInvest.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);

    }
}
