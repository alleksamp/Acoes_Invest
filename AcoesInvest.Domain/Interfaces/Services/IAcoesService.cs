using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;

namespace AcoesInvest.Domain.Interfaces.Services;

public interface IAcoesService
{
    Task<IEnumerable<Acoes>> BuscarAcoes();
    Task<Acoes> BuscarAcoesId(int Id);
    Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome);
    Task<Acoes> CadastrarAcoes(Acoes acoes);
    Task<Acoes> AtualizarAcoes(AtualizarAcoesCommand command);
    Task<bool> DeletarAcoes(int Id);
}
