using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;
using AutoMapper;

namespace AcoesInvest.Application.Services;

public class AcoesAppService : IAcoesAppService
{
    private readonly IAcoesService _acoesService;
    private readonly IMapper _Mapper;

    public AcoesAppService(IAcoesService acoesService, IMapper mapper)
    {
        _acoesService = acoesService;
        _Mapper = mapper;
    }

    public async Task<IEnumerable<AcoesViewModel>> BuscarAcoes()
    {
        return _Mapper.Map<IEnumerable<AcoesViewModel>>(await _acoesService.BuscarAcoes());
    }
    public async Task<AcoesViewModel> BuscarAcoesId(int Id)
    {
        var acoes = await _acoesService.BuscarAcoesId(Id);
        return _Mapper.Map<AcoesViewModel>(acoes);
    }

    public async Task<IEnumerable<AcoesViewModel>> BuscarAcoesNome(string nome)
    {
        var acoes = await _acoesService.BuscarAcoesNome(nome);
        return _Mapper.Map<IEnumerable<AcoesViewModel>>(acoes);
    }

    public async Task<AcoesViewModel> CadastrarAcoes(NovoAcoesViewModel novoAcoesViewModel)
    {
        var novoAcoes = new Acoes(novoAcoesViewModel.Nome,
            novoAcoesViewModel.Quantidade,
            novoAcoesViewModel.Pm,
            novoAcoesViewModel.PmIr,
            novoAcoesViewModel.Dividendos,
            novoAcoesViewModel.TotalInv);

        var acoesCriadas = await _acoesService.CadastrarAcoes(novoAcoes);
        return _Mapper.Map<AcoesViewModel>(acoesCriadas);
    }

    public async Task<AcoesViewModel> AtualizarAcoes(AtualizarAcoesViewModel atualizarAcoesViewModel)
    {
        var command = new AtualizarAcoesCommand
        {
            Id = atualizarAcoesViewModel.Id,
            Nome = atualizarAcoesViewModel.Nome,
            Quantidade = atualizarAcoesViewModel.Quantidade,
            Pm = atualizarAcoesViewModel.Pm,
            PmIr = atualizarAcoesViewModel.PmIr,
            Dividendos = atualizarAcoesViewModel.Dividendos,
            TotalInv = atualizarAcoesViewModel.TotalInv
        };

        var acoesAtualizadas = await _acoesService.AtualizarAcoes(command);
        return _Mapper.Map<AcoesViewModel>(acoesAtualizadas);
    }

    public async Task<bool> DeletarAcoes(int Id)
    {
        return await _acoesService.DeletarAcoes(Id);
    }

}
