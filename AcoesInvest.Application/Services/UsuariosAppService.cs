using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using AcoesInvest.Domain.Interfaces.Services;
using AcoesInvest.Domain.Models;
using AcoesInvest.Domain.Models.Command;
using AutoMapper;

namespace AcoesInvest.Application.Services;

public class UsuariosAppService : IUsuariosAppService
{
    private readonly IUsuariosService _usuariosService;
    private readonly IMapper _Mapper;

    public UsuariosAppService(IUsuariosService usuariosService, IMapper mapper)
    {
        _usuariosService = usuariosService;
        _Mapper = mapper;
    }

    public async Task<IEnumerable<UsuariosViewModel>> BuscarUsuarios()
    {
        return _Mapper.Map<IEnumerable<UsuariosViewModel>>(await _usuariosService.BuscarUsuarios());
    }

    public async Task<IEnumerable<UsuariosViewModel>> BuscarUsuariosNome(string nome)
    {
        var usuarios = await _usuariosService.BuscarUsuariosNome(nome);
        return _Mapper.Map<IEnumerable<UsuariosViewModel>>(usuarios);
    }

    public async Task<UsuariosViewModel> CadastrarUsuario(NovoUsuariosViewModel novoUsuariosViewModel)
    {

        if (!Util.Util.ValidarEmail(novoUsuariosViewModel.Email))
        {
            throw new Exception("Email inválido.");
        }

        string senhaHash = BCrypt.Net.BCrypt.HashPassword(novoUsuariosViewModel.Senha);

        var novoUsuarios = new Usuarios(novoUsuariosViewModel.Nome, 
            novoUsuariosViewModel.Email, 
            senhaHash);

        var UsuariosCadastrado = await _usuariosService.CadastrarUsuario(novoUsuarios);
        return _Mapper.Map<UsuariosViewModel>(UsuariosCadastrado);
    }

    public async Task<UsuariosViewModel> AtualizarUsuario(AtualizarUsuariosViewModel atualizarUsuariosViewModel)
    {
        var command = new AtualizarUsuariosCommand
        {
            Id = atualizarUsuariosViewModel.Id,
            Nome = atualizarUsuariosViewModel.Nome,
            Email = atualizarUsuariosViewModel.Email,
            Senha = atualizarUsuariosViewModel.Senha
        };

        if (!Util.Util.ValidarEmail(atualizarUsuariosViewModel.Email))
        {
            throw new Exception("Email inválido.");
        }

        if (!Util.Util.ValidarSenha(atualizarUsuariosViewModel.Senha, out var erro))
        {
            throw new ArgumentException(erro);
        }

        var usuarioAtualizado = await _usuariosService.AtualizarUsuario(command);
        return _Mapper.Map<UsuariosViewModel>(usuarioAtualizado);
    }

    public async Task<bool> DeletarUsuario(int id)
    {
        return await _usuariosService.DeletarUsuario(id);
    }

}
