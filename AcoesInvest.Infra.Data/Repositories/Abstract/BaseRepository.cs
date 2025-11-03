using AcoesInvest.Domain.Interfaces;
using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AcoesInvest.Infra.Data.Repositories.Abstract;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    protected readonly CadastroContext _context;
    public BaseRepository(CadastroContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IUnitOfWork UnitOfWork => _context;

    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().Where(predicate).ToListAsync();
    }
}
