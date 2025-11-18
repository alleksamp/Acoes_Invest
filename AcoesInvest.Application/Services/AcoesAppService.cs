using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using AcoesInvest.Domain.Interfaces.Services;
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

    public async Task<IEnumerable<AcoesViewModel>> BuscarAcoesNome(string nome)
    {
        var acoes = await _acoesService.BuscarAcoesNome(nome);
        return _Mapper.Map<IEnumerable<AcoesViewModel>>(acoes);
    }
}
