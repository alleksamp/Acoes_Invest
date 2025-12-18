using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcoesInvest.Application.ViewModel;

public class LoginViewModel
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
