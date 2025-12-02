using AcoesInvest.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acoes_Invest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IUsuariosAppService _usuariosAppService;
    public UsuariosController(IUsuariosAppService usuariosAppService)
    {
        _usuariosAppService = usuariosAppService;
    }


    [HttpGet("Listar Usuários")]
    public async Task<IActionResult> BuscarUsuarios()
    {
        return Ok(await _usuariosAppService.BuscarUsuarios());
    }

    [HttpGet("Buscar Usuário por nome")]
    public async Task<IActionResult> BuscarUsuariosNome(string nome)
    {
        var usuarios = await _usuariosAppService.BuscarUsuariosNome(nome);
        if (!usuarios.Any()) return NotFound($"Usuário {nome} não encontrado.");
        return Ok(await _usuariosAppService.BuscarUsuariosNome(nome));
    }


}
