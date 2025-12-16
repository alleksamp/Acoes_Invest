namespace AcoesInvest.Domain.Models;

public class Usuarios
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; set; }

    public Usuarios(string nome, string email, string senha)
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }

    public void Atualizar(string nome, string email, string senha )
    {
        Nome = nome;
        Email = email;
        Senha = senha;
    }


}
