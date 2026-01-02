using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Interfaces.Repositories;

public interface IAcoesRepository : IBaseRepository<Acoes>
{
    Task<IEnumerable<Acoes>> BuscarAcoes();
    Task<Acoes> BuscarAcoesId(int Id);
    Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome);
    Task CadastrarAcoes(Acoes acoes);
    Task AtualizarAcoes(Acoes acoes);
    Task DeletarAcoes(Acoes acoes);
}
