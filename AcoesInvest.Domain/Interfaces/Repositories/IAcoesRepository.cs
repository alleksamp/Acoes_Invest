using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Interfaces.Repositories;

public interface IAcoesRepository : IBaseRepository<Acoes>
{
    Task<IEnumerable<Acoes>> BuscarAcoes(int usuarioId);
    Task<Acoes> BuscarAcoesId(int Id, int usuarioId);
    Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome, int usuarioId);
    Task CadastrarAcoes(Acoes acoes);
    Task AtualizarAcoes(Acoes acoes);
    Task DeletarAcoes(Acoes acoes);
}
