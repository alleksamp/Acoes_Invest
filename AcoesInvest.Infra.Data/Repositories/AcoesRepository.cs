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

    public async Task<IEnumerable<Acoes>> BuscarAcoes(int usuarioId)
    {
        return await _context.Acoes
        .Where(x => x.UsuarioId == usuarioId)
        .ToListAsync();
    }
    public async Task<Acoes> BuscarAcoesId(int Id, int usuarioId)
    {
        var result = await _context.Acoes
                .FirstOrDefaultAsync(x => x.Id == Id && x.UsuarioId == usuarioId);
        return result;
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome, int usuarioId)
    {
        var result = await _context.Acoes
        .Where(x => x.Nome.Contains(nome) && x.UsuarioId == usuarioId)
        .ToListAsync();
        return result;
    }

    public async Task CadastrarAcoes(Acoes acoes)
    {
        await _context.Acoes.AddAsync(acoes);
    }

    public async Task AtualizarAcoes(Acoes acoes)
    {
        await Task.FromResult(_context.Acoes.Update(acoes));
    }

    public async Task DeletarAcoes(Acoes acoes)
    {
        await Task.FromResult(_context.Remove(acoes));
    }

}
