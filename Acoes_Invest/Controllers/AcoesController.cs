using Microsoft.AspNetCore.Mvc;

namespace Acoes_Invest.Controllers;

public class AcoesController : Controller
{

    [HttpGet("api/acoes/listar")]
    public IActionResult BuscarAcoes()
    {
        var acoes = new[]
        {
        new { Id = 1, Nome = "Ação A", Preco = 100.50 },
        new { Id = 2, Nome = "Ação B", Preco = 200.75 },
        new { Id = 3, Nome = "Ação C", Preco = 150.30 }
    };
        return Ok(acoes);
    }

}

