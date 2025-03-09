namespace Gestao.Api.Models.Interfaces;

public interface IAluguel
{
    Pessoa Responsavel { get; }
    DateTime InicioDoAluguel { get; }
    DateTime? FimDoAluguel { get; }
    decimal ValorTotalDoAluguel();
}
