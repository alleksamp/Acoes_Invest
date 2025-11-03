

namespace AcoesInvest.Domain.Interfaces
{
     public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
