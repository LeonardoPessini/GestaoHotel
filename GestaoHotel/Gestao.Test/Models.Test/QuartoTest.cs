using Bogus;
using Gestao.Api.Models;
using Gestao.Test.Builds;
using Gestao.Test.Utils;

namespace Gestao.Test.Models.Test;
public class QuartoTest
{
    public QuartoTest()
    { 
        
    }

    [Fact]
    public void DeveCriarQuartoComTodosOsAtributos()
    {
        var faker = new Faker();

        var id = faker.Random.Int(1, int.MaxValue);
        var numero = faker.Random.Int(1, int.MaxValue);
        var andar = faker.Random.Int(1, int.MaxValue);
        var valorDaDiaria = faker.Finance.Amount();
        var valorDaHora = faker.Finance.Amount();
        var estaLivre = faker.Random.Bool();

        var quarto = new Quarto(numero, andar, valorDaDiaria, valorDaHora)
        {
            Id = id,
            EstaLivre = estaLivre
        };

        Assert.Equal(id, quarto.Id);
        Assert.Equal(andar, quarto.Andar);
        Assert.Equal(numero, quarto.Numero);
        Assert.Equal(valorDaDiaria, quarto.ValorDaDiaria);
        Assert.Equal(valorDaHora, quarto.ValorDaHora);
        Assert.Equal(estaLivre,quarto.EstaLivre);
    }

    [Fact]
    public void DeveCriarQuartoApenasComAtributosObrigaatorios()
    {
        var faker = new Faker();

        var numero = faker.Random.Int(1, int.MaxValue);
        var andar = faker.Random.Int(1, int.MaxValue);
        var valorDaDiaria = faker.Finance.Amount();
        var valorDaHora = faker.Finance.Amount();

        var quarto = new Quarto(numero, andar, valorDaDiaria, valorDaHora);

        Assert.Equal(0, quarto.Id);
        Assert.Equal(andar, quarto.Andar);
        Assert.Equal(numero, quarto.Numero);
        Assert.Equal(valorDaDiaria, quarto.ValorDaDiaria);
        Assert.Equal(valorDaHora, quarto.ValorDaHora);
        Assert.False(quarto.EstaLivre);
    }


    [Fact]
    public void NaoDeveCriarQuartoComIdInvalido()
    {
        Assert.Throws<ArgumentException>(() =>
                QuartoBuild.Create().WithId(-1).Build())
            .WithMessage("Id invalido");
    }

    [Fact]
    public void NaoDeveCriarQuartoComNumeroInvalido()
    {
        Assert.Throws<ArgumentException>(() =>
                QuartoBuild.Create().WithNumero(-1).Build())
            .WithMessage("Numero NAO pode ser negativo");
    }

    [Fact]
    public void NaoDeveCriarQuartoComAndarInvalido()
    {
        Assert.Throws<ArgumentException>(() =>
                QuartoBuild.Create().WithAndar(-1).Build())
            .WithMessage("Andar NAO pode ser negativo");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void NaoDeveCriarQuartoComValorDiariainvalido(decimal valorInvalido)
    {
        Assert.Throws<ArgumentException>(() =>
                QuartoBuild.Create().WithValorDaDiaria(valorInvalido).Build())
            .WithMessage("O valor da diaria NAO pode ser negativo");
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void NaoDeveCriarQuartoComValorHorainvalido(decimal valorInvalido)
    {
        Assert.Throws<ArgumentException>(() =>
                QuartoBuild.Create().WithValorDaHora(valorInvalido).Build())
            .WithMessage("O valor da hora NAO pode ser negativo");
    }
}
