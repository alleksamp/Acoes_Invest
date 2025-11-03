using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Models;
using AcoesInvest.Infra.Data.EF;
using AcoesInvest.Infra.Data.Repositories.Abstract;

namespace AcoesInvest.Infra.Data.Repositories;

public class AcoesRepository : BaseRepository<Acoes>, IAcoesRepository
{
    private readonly CadastroContext _context;

    public AcoesRepository(CadastroContext context) : base(context)
    {
        _context = context;
    }

}
