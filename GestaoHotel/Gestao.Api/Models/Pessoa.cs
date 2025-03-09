using Microsoft.AspNetCore.Http.HttpResults;

namespace Gestao.Api.Models;

public class Pessoa
{
    public Pessoa(int id, string nome, string cpf, int idade)
    {
        ValidateId(id);
        ValidateNome(nome);
        ValidateCpf(cpf);
        ValidateIdade(idade);

        Id = id;
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
    }


    public int Id { get; init; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }


    private void ValidateId(int id)
    {
        if (id < 0)
            throw new ArgumentException("Id invalido");
    }

    private void ValidateNome(string nome)
    {
        if (string.IsNullOrEmpty(nome))
            throw new ArgumentException("Nome nao pode ser nulo");

        var arrayCharNome = nome.ToCharArray();
        foreach(var character in arrayCharNome )
        {
            if (!char.IsAsciiLetter(character) && character != ' ')
                throw new ArgumentException("Nome deve conter apenas letras");
        }
    }

    private void ValidateCpf(string cpf)
    {
        if (string.IsNullOrEmpty(cpf))
            throw new ArgumentException("Cpf nao pode ser nulo");

        if (cpf.Length < 11)
            throw new ArgumentException("O valor do cpf contem MENOS que 11 digitos");

        if (cpf.Length > 11)
            throw new ArgumentException("O valor do cpf contem MAIS que 11 digitos");

        var arrayCharCpf = cpf.ToCharArray();
        foreach (var character in arrayCharCpf)
        {
            if (!char.IsDigit(character))
                throw new ArgumentException("Cpf deve conter apenas numeros");
        }
    }

    private void ValidateIdade(int idade)
    {
        if (idade < 0 || idade > 120)
            throw new ArgumentException("Idade invalida");
    }
}