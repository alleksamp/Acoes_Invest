using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acoes_Invest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly ILogger<UsuariosController> _logger;

    public UsuariosController(ILogger<UsuariosController> logger)
    {
        _logger = logger;
    }




}
