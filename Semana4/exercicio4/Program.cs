using System;

class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno()
    {
        // Valores padrão
        Nome = "Sem Nome";
        Idade = 0;
    }
}

class Program
{
    static void Main()
    {
        Aluno meuAluno = new Aluno();

        Console.WriteLine($"Nome: {meuAluno.Nome}, Idade: {meuAluno.Idade}");
    }
}
