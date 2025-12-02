using AcoesInvest.Domain.Interfaces.Repositories;
using AcoesInvest.Domain.Models;
using AcoesInvest.Infra.Data.EF;
using AcoesInvest.Infra.Data.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace AcoesInvest.Infra.Data.Repositories;

public class UsuariosRepository : BaseRepository<Usuarios>, IUsuariosRepository
{
    private readonly CadastroContext _context;

    public UsuariosRepository(CadastroContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuarios>> BuscarUsuarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<IEnumerable<Usuarios>> BuscarUsuariosNome(string nome)
    {
        return await _context.Usuarios
            .Where(u => u.Nome.Contains(nome))
            .ToListAsync();
    }


}
