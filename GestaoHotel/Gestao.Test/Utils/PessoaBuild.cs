using Bogus;
using Bogus.Extensions.Brazil;
using Gestao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Test.Utils;
internal class PessoaBuild
{
    private int _id;
    private string _nome;
    private string _cpf;
    private int _idade;


    private PessoaBuild(int id, string nome, string cpf, int idade)
    {
        _id = id;
        _nome = nome;
        _cpf = cpf;
        _idade = idade;
    }

    public static PessoaBuild Create()
    {
        var faker = new Faker();

        var id = faker.Random.Int(1, int.MaxValue);
        var nome = faker.Person.FullName;
        var cpf = faker.Person.Cpf().Replace(".", "").Replace("-", "");
        var idade = faker.Random.Int(18, 100);

        return new PessoaBuild(id,nome,cpf,idade);
    }

    public Pessoa Build(){
        return new Pessoa(nome: _nome, cpf: _cpf, idade: _idade) { Id = _id };
    }

    public PessoaBuild WithId(int id){ 
        _id = id; 
        return this; 
    }

    public PessoaBuild WithName(string name) {
        _nome = name; 
        return this; 
    }

    public PessoaBuild WithCpf(string cpf)
    {
        _cpf = cpf;
        return this;
    }

    public PessoaBuild WithIdade(int idade)
    {
        _idade = idade;
        return this;
    }
}
