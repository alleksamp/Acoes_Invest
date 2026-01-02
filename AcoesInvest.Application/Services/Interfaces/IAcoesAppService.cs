using AcoesInvest.Application.ViewModel;

namespace AcoesInvest.Application.Services.Interfaces;

public interface IAcoesAppService
{
    Task<IEnumerable<AcoesViewModel>> BuscarAcoes();
    Task<AcoesViewModel> BuscarAcoesId(int Id);
    Task<IEnumerable<AcoesViewModel>> BuscarAcoesNome(string nome);
    Task<AcoesViewModel> CadastrarAcoes(NovoAcoesViewModel novoAcoesViewModel);
    Task<AcoesViewModel> AtualizarAcoes(AtualizarAcoesViewModel atualizarAcoesViewModel);
    Task<bool> DeletarAcoes(int Id);
}
