using AcoesInvest.Application.Services.Interfaces;
using AcoesInvest.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Acoes_Invest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AcoesController : Controller
{
    private readonly IAcoesAppService _acoesAppService;
    public AcoesController(IAcoesAppService acoesAppService)
    {
        _acoesAppService = acoesAppService;
    }

    [HttpGet("Listar Ações")]
    public async Task<IActionResult> BuscarAcoes()
    {
        return Ok(await _acoesAppService.BuscarAcoes());
    }

    [HttpGet("Buscar por nome")]
    public async Task<IActionResult> BuscarAcoesNome(string nome)
    {
        var acoes = await _acoesAppService.BuscarAcoesNome(nome);
        if (!acoes.Any()) return NotFound($"Ação {nome} não encontrada.");
        return Ok(acoes);
    }

    [HttpPost("Cadastrar ações")]
    public async Task<IActionResult> CadastrarAcoes([FromBody] NovoAcoesViewModel vm)
    {
        var result = await _acoesAppService.CadastrarAcoes(vm);
        if (result == null) return BadRequest("Não foi possível cadastrar nenhuma Ação");
        return Ok(result);
    }

    [HttpPut("Atualizar ações")]
    public async Task<IActionResult> AtualizarAcoes([FromBody] AtualizarAcoesViewModel vm)
    {
        var result = await _acoesAppService.AtualizarAcoes(vm);
        if (result == null) return BadRequest("Não foi possível atualizar a Ação");
        return Ok(result);
    }

    [HttpDelete("Deletar ações")]
    public async Task<IActionResult> DeletarAcoes(int Id)
    {
        var result = await _acoesAppService.DeletarAcoes(Id);
        if (!result) return BadRequest($"Não foi possível excluir a ação {Id}");
        if (result) return Ok();
        return NotFound();
    }

}

