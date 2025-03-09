using Microsoft.AspNetCore.Http.HttpResults;
using System.Reflection.Metadata.Ecma335;

namespace Gestao.Api.Models;

public class Pessoa
{
    private int _id;
    private string _nome;
    private string _cpf;
    private int _idade;

    public Pessoa(string nome, string cpf, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
    }


    public int Id { 
        get => _id; 
        init
        {
            if (value < 0)
                throw new ArgumentException("Id invalido");

            _id = value;
        } 
    }

    public string Nome {
        get => _nome;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Nome nao pode ser nulo");

            var arrayCharNome = value.ToCharArray();
            foreach (var character in arrayCharNome)
            {
                if (!char.IsAsciiLetter(character) && character != ' ')
                    throw new ArgumentException("Nome deve conter apenas letras");
            }

            _nome = value;
        } 
    }

    public string Cpf { 
        get => _cpf; 
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Cpf nao pode ser nulo");

            if (value.Length < 11)
                throw new ArgumentException("O valor do cpf contem MENOS que 11 digitos");

            if (value.Length > 11)
                throw new ArgumentException("O valor do cpf contem MAIS que 11 digitos");

            var arrayCharCpf = value.ToCharArray();
            foreach (var character in arrayCharCpf)
            {
                if (!char.IsDigit(character))
                    throw new ArgumentException("Cpf deve conter apenas numeros");
            }

            _cpf = value;
        }
    }

    public int Idade { 
        get => _idade; 
        set
        {
            if (value < 0 || value > 120)
                throw new ArgumentException("Idade invalida");

            _idade = value;
        }
    }
}