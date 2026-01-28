using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Acoes_Invest.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AcoesController : Controller
{
    private readonly IAcoesAppService _acoesAppService;
    public AcoesController(IAcoesAppService acoesAppService)
    {
        _acoesAppService = acoesAppService;
    }

    private int UsuarioLogadoId
    {
        get
        {            
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                          ?? User.FindFirst("id")?.Value;

            if (string.IsNullOrEmpty(claimValue))
            {
                throw new UnauthorizedAccessException("ID do usuário não encontrado no Token.");
            }

            return int.Parse(claimValue);
        }
    }

    [HttpGet("Listar")]
    public async Task<IActionResult> BuscarAcoes()
    {
        return Ok(await _acoesAppService.BuscarAcoes(UsuarioLogadoId));
    }

    [HttpGet("BuscarId")]
    public async Task<IActionResult> BuscarAcoesId(int Id)
    {
        var acoes = await _acoesAppService.BuscarAcoesId(Id, UsuarioLogadoId);
        if (acoes == null) return NotFound($"Ação {Id} não encontrada.");
        return Ok(acoes);
    }

    [HttpGet("BuscarNome")]
    public async Task<IActionResult> BuscarAcoesNome(string nome)
    {
        var acoes = await _acoesAppService.BuscarAcoesNome(nome, UsuarioLogadoId);
        if (!acoes.Any()) return NotFound($"Ação {nome} não encontrada.");
        return Ok(acoes);
    }

    [HttpPost("Cadastrar")]
    public async Task<IActionResult> CadastrarAcoes([FromBody] NovoAcoesViewModel vm)
    {
        var result = await _acoesAppService.CadastrarAcoes(vm, UsuarioLogadoId);
        if (result == null) return BadRequest("Não foi possível cadastrar nenhuma Ação");
        return Ok(result);
    }

    [HttpPut("Atualizar")]
    public async Task<IActionResult> AtualizarAcoes([FromBody] AtualizarAcoesViewModel vm)
    {
        var result = await _acoesAppService.AtualizarAcoes(vm, UsuarioLogadoId);
        if (result == null) return BadRequest("Não foi possível atualizar a Ação");
        return Ok(result);
    }

    [HttpDelete("Deletar")]
    public async Task<IActionResult> DeletarAcoes(int Id)
    {
        var result = await _acoesAppService.DeletarAcoes(Id, UsuarioLogadoId);
        if (!result) return BadRequest($"Não foi possível excluir a ação {Id}");
        if (result) return Ok();
        return NotFound();
    }

}

