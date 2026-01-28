

namespace AcoesInvest.Application.ViewModel;

public class AcoesViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Pm { get; set; }
    public decimal PmIr { get; set; }
    public decimal Dividendos { get; set; }
    public decimal TotalInv { get; set; }
    public int UsuarioId { get; set; }

}
