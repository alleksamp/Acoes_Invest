using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;

namespace AcoesInvest.Domain.Services;

public class AcoesService : IAcoesService
{
    private readonly IAcoesRepository _acoesRepository;
    public AcoesService(IAcoesRepository acoesRepository)
    {
        _acoesRepository = acoesRepository;
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoes(int usuarioId)
    {
        return await _acoesRepository.BuscarAcoes(usuarioId);
    }
    public async Task<Acoes> BuscarAcoesId(int Id, int usuarioId)
    {
        return await _acoesRepository.BuscarAcoesId(Id, usuarioId);
    }

    public async Task<IEnumerable<Acoes>> BuscarAcoesNome(string nome, int usuarioId)
    {
        return await _acoesRepository.BuscarAcoesNome(nome, usuarioId);
    }

    public async Task<Acoes> CadastrarAcoes(Acoes acoes)
    {
        await _acoesRepository.CadastrarAcoes(acoes);
        await _acoesRepository.UnitOfWork.SaveChangesAsync();

        return (acoes);
    }

    public async Task<Acoes> AtualizarAcoes(AtualizarAcoesCommand command)
    {
        var acoes = await _acoesRepository.Get(x => x.Id == command.Id && x.UsuarioId == command.UsuarioId);
        if (acoes == null) return null;

        acoes.Atualizar(command.Nome,
            command.Quantidade,
            command.Pm,
            command.PmIr,
            command.Dividendos,
            command.TotalInv);

        await _acoesRepository.AtualizarAcoes(acoes);
        await _acoesRepository.UnitOfWork.SaveChangesAsync();
        return acoes;
    }

    public async Task<bool> DeletarAcoes(int Id, int usuarioId)
    {
        var acoes = await _acoesRepository.Get(x => x.Id == Id && x.UsuarioId == usuarioId);
        if (acoes == null) return false;

        await _acoesRepository.DeletarAcoes(acoes);
        await _acoesRepository.UnitOfWork.SaveChangesAsync();

        return true;
    }

}
