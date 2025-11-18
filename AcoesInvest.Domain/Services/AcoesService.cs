using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Models;

namespace AcoesInvest.Domain.Services;

public class AcoesService : IAcoesService
{
    private readonly IAcoesRepository _acoesRepository;
    public AcoesService(IAcoesRepository acoesRepository)
    {
        _acoesRepository = acoesRepository;
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoes()
    {
        return await _acoesRepository.BuscarAcoes();
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome)
    {
        return await _acoesRepository.BuscarAcoesNome(nome);
    }
}
