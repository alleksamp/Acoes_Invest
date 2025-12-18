using AcoesInvest.Application.Services;
using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using AcoesInvest.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Acoes_Invest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuariosRepository _usuariosRepository;
    private readonly ITokenService _tokenService;

    public LoginController(IUsuariosRepository usuariosRepository, ITokenService tokenService)
    {
        _usuariosRepository = usuariosRepository;
        _tokenService = tokenService;
    }


    [HttpPost("login")]
    public async Task<ActionResult<object>> Authenticate([FromBody] LoginViewModel model) // Crie este ViewModel
    {
        // 1. Lógica de Validação (Exemplo Simplificado - Substitua pela sua validação de hash!)
        var usuario = await _usuariosRepository.Get(x => x.Email == model.Email);

        if (usuario == null)
        {
            return Unauthorized(new { message = "Usuário inválido." });
        }

        bool senhaValida = BCrypt.Net.BCrypt.Verify(model.Senha, usuario.Senha.Trim());
        if (!senhaValida)
        {
            return Unauthorized(new { message = "Senha inválida." });
        }

        // 2. Geração do Token
        var token = _tokenService.GenerateToken(usuario);

        // 3. Retorno
        return Ok(new
        {
            user = usuario.Email,
            token = token
        });
    }
}
