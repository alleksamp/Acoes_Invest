using System.Text.Json.Serialization;

namespace AcoesInvest.Application.ViewModel;

public class UsuariosViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    [JsonIgnore]
    public string Senha { get; set; }
}
