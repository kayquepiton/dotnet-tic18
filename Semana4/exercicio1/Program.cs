﻿using System;

class Veiculo
{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }
}

class Program
{
    static void Main()
    {
        Veiculo meuCarro = new Veiculo();
        meuCarro.Modelo = "Carro Modelo X";
        meuCarro.Ano = 2022;
        meuCarro.Cor = "Azul";

        Console.WriteLine($"Modelo: {meuCarro.Modelo}, Ano: {meuCarro.Ano}, Cor: {meuCarro.Cor}");
    }
}
