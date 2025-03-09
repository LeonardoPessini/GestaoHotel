namespace Gestao.Api.Models.Interfaces;

public interface IHospedagem : IAluguel, IEntity
{
    IQuarto Quarto { get; }
    List<Pessoa> Hospedes { get; }
    TimeSpan TempoDePermanencia { get; }
}
