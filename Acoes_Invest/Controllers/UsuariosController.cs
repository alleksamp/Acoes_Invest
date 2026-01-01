using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpGet("Listar")]
    public async Task<IActionResult> BuscarUsuarios()
    {
        return Ok(await _usuariosAppService.BuscarUsuarios());
    }

    [Authorize]
    [HttpGet("BuscarUsuárioNome")]
    public async Task<IActionResult> BuscarUsuariosNome(string nome)
    {
        var usuarios = await _usuariosAppService.BuscarUsuariosNome(nome);
        if (!usuarios.Any()) return NotFound($"Usuário {nome} não encontrado.");
        return Ok(await _usuariosAppService.BuscarUsuariosNome(nome));
    }

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> CadastrarUsuario([FromBody] NovoUsuariosViewModel vm)
    {
        var result = await _usuariosAppService.CadastrarUsuario(vm);
        if (result == null) return BadRequest("Não foi possível cadastrar o usuário");
        return Ok(result);
    }

    [Authorize]
    [HttpPut("Atualizar")]
    public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuariosViewModel vm)
    {
        var result = await _usuariosAppService.AtualizarUsuario(vm);
        if (result == null) return BadRequest("Não foi possível atualizar o usuário");
        return Ok(result);
    }

    [Authorize]
    [HttpDelete("Deletar")]
    public async Task<IActionResult> DeletarUsuario(int id)
    {
        var result = await _usuariosAppService.DeletarUsuario(id);
        if (!result) return BadRequest("Não foi possível deletar o usuário");
        return Ok("Usuário deletado com sucesso");
    }


}
