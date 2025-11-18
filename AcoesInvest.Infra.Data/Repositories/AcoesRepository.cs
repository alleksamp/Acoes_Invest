using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Models;
using AcoesInvest.Infra.Data.EF;
using AcoesInvest.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AcoesInvest.Infra.Data.Repositories;

public class AcoesRepository : BaseRepository<Acoes>, IAcoesRepository
{
    private readonly CadastroContext _context;

    public AcoesRepository(CadastroContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoes()
    {
        return await _context.Acoes.ToListAsync();
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome)
    {
        var result = await _context.Acoes.Where(x => x.Nome.Contains(nome)).ToListAsync();

        return result;
    }
}
