using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AcoesInvest.Application.ViewModel;

public class NovoUsuariosViewModel
{
    public string Nome { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    [DataType(DataType.Password)]
    public string Senha { get; set; }
}
