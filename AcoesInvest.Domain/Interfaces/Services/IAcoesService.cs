using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Interfaces.Services;

public interface IAcoesService
{
    Task<IEnumerable<Acoes>> BuscarAcoes();
    Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome);
}
