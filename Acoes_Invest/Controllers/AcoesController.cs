using AcoesInvest.Application.Services.Interfaces;
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


}

