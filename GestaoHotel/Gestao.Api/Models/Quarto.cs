using Gestao.Api.Models.Interfaces;

namespace Gestao.Api.Models;

public class Quarto : IQuarto
{
    private int _id;
    private int _numero;
    private decimal _valorDaDiaria;
    private decimal _valorDaHora;
    private int _andar;
    public bool EstaLivre { get; set; }

    public Quarto(int numero, int andar, decimal valorDaDiaria, decimal valorDaHora) 
    {
        Andar = andar;
        Numero = numero;
        ValorDaDiaria = valorDaDiaria;
        ValorDaHora = valorDaHora;
    }

    public int Id
    {
        get => _id;
        init{
            if (value < 0)
                throw new ArgumentException("Id invalido");

            _id = value;
        }
    }

    public int Numero { 
        get => _numero; 
        set{
            if (value < 0)
                throw new ArgumentException("Numero NAO pode ser negativo");

            _numero = value;
        }
    }

    public decimal ValorDaDiaria { 
        get => _valorDaDiaria;
        set {
            if (value <= 0)
                throw new ArgumentException("O valor da diaria NAO pode ser negativo");

            _valorDaDiaria = value;
        } 
    }

    public decimal ValorDaHora { 
        get => _valorDaHora;
        set{
            if(value <= 0)
                throw new ArgumentException("O valor da hora NAO pode ser negativo");

            _valorDaHora = value; 
        } 
    }

    public int Andar {
        get => _andar; 
        set  {
            if (value < 0)
                throw new ArgumentException("Andar NAO pode ser negativo");

            _andar = value; 
        } 
    }
}