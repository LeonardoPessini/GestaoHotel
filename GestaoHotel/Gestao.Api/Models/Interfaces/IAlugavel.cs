namespace Gestao.Api.Models.Interfaces;

public interface IAlugavel
{
    decimal ValorDaDiaria { get; }
    decimal ValorDaHora { get; }
    bool EstaLivre { get; }
}
