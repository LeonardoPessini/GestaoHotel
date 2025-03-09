namespace Gestao.Api.Models.Interfaces;

public interface IQuarto : IAlugavel, IEntity
{
    int Numero { get; }
    int Andar { get; set; }
}
