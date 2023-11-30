using System;
using System.Collections.Generic;

class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

class Agenda
{
    private List<Contato> contatos = new List<Contato>();

    public Contato this[int index]
    {
        get { return contatos[index]; }
        set { contatos[index] = value; }
    }

    public void AdicionarContato(Contato contato)
    {
        contatos.Add(contato);
    }
}

class Program
{
    static void Main()
    {
        Agenda minhaAgenda = new Agenda();

        minhaAgenda.AdicionarContato(new Contato { Nome = "João", Telefone = "123456789" });
        minhaAgenda.AdicionarContato(new Contato { Nome = "Maria", Telefone = "987654321" });

        Console.WriteLine($"Contato 1: {minhaAgenda[0].Nome}, Telefone: {minhaAgenda[0].Telefone}");
        Console.WriteLine($"Contato 2: {minhaAgenda[1].Nome}, Telefone: {minhaAgenda[1].Telefone}");
    }
}
