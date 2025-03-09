using Gestao.Test.Utils;
using Bogus;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestao.Api.Models;

namespace Gestao.Test.Models.Test;
public class PessoaTest
{
    private readonly Faker _faker;
    public PessoaTest() 
    {
        _faker = new Faker();
    }

    [Fact]
    public void DeveCriarPessoa()
    {
        var id = _faker.Random.Int(1, int.MaxValue);
        var nome = _faker.Person.FullName;
        var cpf = RandomCpf();
        var idade = _faker.Random.Int(18, 100);

        var pessoa = new Pessoa(nome, cpf, idade) { Id = id };

        Assert.Equal(id, pessoa.Id);
        Assert.Equal(nome, pessoa.Nome);
        Assert.Equal(cpf, pessoa.Cpf);
        Assert.Equal(idade, pessoa.Idade);
    }

    private string RandomCpf() => _faker.Person.Cpf().Replace(".", "").Replace("-", "");

    [Fact]
    public void NaoDeveCriarPessoaComIdInvalido()
    {
        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithId(-1).Build())
            .WithMessage("Id invalido");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void NaoDeveCriarPessoaComNomeNuloOuVazio(string nomeInvalido)
    {
        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithName(nomeInvalido).Build())
            .WithMessage("Nome nao pode ser nulo");
    }

    [Fact]
    public void NaoDeveCriarPessoaComNumeroOuCaracatereEspecialNoNome() 
    {
        var nome = _faker.Person.FullName;
        var nomeInvalido = ReplaceARandomChar(nome, "1234567890!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray());

        Assert.Throws<ArgumentException>(() => 
                PessoaBuild.Create().WithName(nomeInvalido).Build())
            .WithMessage("Nome deve conter apenas letras");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void NaoDeveCriarPessoaComCpfNuloOuVazio(string cpfInvalido)
    {
        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithCpf(cpfInvalido).Build())
            .WithMessage("Cpf nao pode ser nulo");
    }

    [Fact]
    public void NaoDeveCriarPessoaComCpfMenorQue11Digitos()
    {
        var cpf10Digitos = RandomCpf().Remove(1, 1);

        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithCpf(cpf10Digitos).Build())
        .WithMessage("O valor do cpf contem MENOS que 11 digitos");
    }

    [Fact]
    public void NaoDeveCriarPessoaComCpfMaiorQue11Digitos()
    {
        var cpf12Digitos = RandomCpf() + "1";

        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithCpf(cpf12Digitos).Build())
            .WithMessage("O valor do cpf contem MAIS que 11 digitos");
    }

    [Fact]
    public void NaoDeveCriarPessoaComCpfComCaractereNaoNumerico()
    {
        var cpf = RandomCpf();
        var caracteresNaoNumericos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~".ToCharArray();
        var cpfInvalido = ReplaceARandomChar(cpf, caracteresNaoNumericos);

        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithCpf(cpfInvalido).Build())
            .WithMessage("Cpf deve conter apenas numeros");
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(121)]
    public void NaoDeveCriarPessoaComIdadeInvalida(int idadeInvalida)
    {
        Assert.Throws<ArgumentException>(() =>
                PessoaBuild.Create().WithIdade(idadeInvalida).Build())
            .WithMessage("Idade invalida");
    }

    private string ReplaceARandomChar(string stringBase, char[] possibleChars)
    {
        if (string.IsNullOrEmpty(stringBase))
            return stringBase;

        var charArray = stringBase.ToCharArray();
        var randomPositionInArray = Random.Shared.Next(0, charArray.Length);

        charArray[randomPositionInArray] = new Faker().PickRandom(possibleChars);
        var resultString = new string(charArray);

        return resultString;
    }

}


