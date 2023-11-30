using System;

class ContaBancaria
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo não pode ser negativo");
            }
            else
            {
                saldo = value;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ContaBancaria minhaConta = new ContaBancaria();

        try
        {
            minhaConta.Saldo = -500; // Isso deve lançar a exceção
            Console.WriteLine($"Saldo atual: {minhaConta.Saldo}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
