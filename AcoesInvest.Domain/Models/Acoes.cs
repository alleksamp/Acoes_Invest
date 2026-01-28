namespace AcoesInvest.Domain.Models;

public class Acoes
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }
    public decimal Pm { get; private set; }
    public decimal PmIr { get; private set; }
    public decimal Dividendos { get; private set; }
    public decimal TotalInv { get; private set; }
    public int UsuarioId { get; private set; }

    public Acoes(string nome, int quantidade, decimal pm, decimal pmIr, decimal dividendos, decimal totalInv, int usuarioId)
    {

        Nome = nome;
        Quantidade = quantidade;
        Pm = pm;
        PmIr = pmIr;
        Dividendos = dividendos;
        TotalInv = totalInv;
        UsuarioId = usuarioId;

    }

    public void Atualizar(string nome, int quantidade, decimal pm, decimal pmIr, decimal dividendos, decimal totalInv)
    {
        Nome = nome;
        Quantidade = quantidade;
        Pm = pm;
        PmIr = pmIr;
        Dividendos = dividendos;
        TotalInv = totalInv;

    }

}
