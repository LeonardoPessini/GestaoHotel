using Bogus;
using Gestao.Api.Models;
using Gestao.Api.Models.Interfaces;

namespace Gestao.Test.Builds;
internal class QuartoBuild
{
    private int _id;
    private int _numero;
    private decimal _valorDaDiaria;
    private decimal _valorDaHora;
    private int _andar;
    private bool _estaLivre;

    private QuartoBuild(int id, int numero, decimal valorDaDiaria, decimal valorDaHora, int andar, bool estaLivre)
    {
        _id = id;
        _numero = numero;
        _valorDaDiaria = valorDaDiaria;
        _valorDaHora = valorDaHora;
        _andar = andar;
        _estaLivre = estaLivre;
    }

    public static QuartoBuild Create()
    {
        var faker = new Faker();

        var id = faker.Random.Int(1,int.MaxValue);
        var numero = faker.Random.Int(1, int.MaxValue);
        var andar = faker.Random.Int(1, int.MaxValue);
        var valorDaDiaria = faker.Finance.Amount();
        var valorDaHora = faker.Finance.Amount();
        var estaLivre = faker.Random.Bool();

        return new QuartoBuild(id, numero, valorDaDiaria, valorDaHora, andar, estaLivre);
    }

    public IQuarto Build()
    {
        return new Quarto(_numero, _andar, _valorDaDiaria, _valorDaHora)
        {
            Id = _id,
            EstaLivre = _estaLivre
        };
    }

    public QuartoBuild WithId(int id)
    {
        _id = id;
        return this;
    }

    public QuartoBuild WithNumero(int numero)
    {
        _numero = numero;
        return this;
    }

    public QuartoBuild WithValorDaDiaria(decimal valorDaDiara)
    {
        _valorDaDiaria = valorDaDiara;
        return this;
    }
    public QuartoBuild WithValorDaHora(decimal valorDaHora)
    {
        _valorDaHora = valorDaHora;
        return this;
    }

    public QuartoBuild WithAndar(int andar)
    {
        _andar = andar;
        return this;
    }
}
