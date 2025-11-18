using AcoesInvest.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoesInvest.Application.Services.Interfaces;

public interface IAcoesAppService
{
    Task<IEnumerable<AcoesViewModel>> BuscarAcoes();
    Task<IEnumerable<AcoesViewModel>> BuscarAcoesNome(string nome);
}
