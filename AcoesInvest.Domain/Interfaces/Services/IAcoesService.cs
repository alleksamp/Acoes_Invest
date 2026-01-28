using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;

namespace AcoesInvest.Domain.Interfaces.Services;

public interface IAcoesService
{
    Task<IEnumerable<Acoes>> BuscarAcoes(int usuarioId);
    Task<Acoes> BuscarAcoesId(int Id, int usuarioId);
    Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome, int usuarioId);
    Task<Acoes> CadastrarAcoes(Acoes acoes);
    Task<Acoes> AtualizarAcoes(AtualizarAcoesCommand command);
    Task<bool> DeletarAcoes(int Id, int usuarioId);
}
