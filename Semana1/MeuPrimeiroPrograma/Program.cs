Console.WriteLine("Hello, World!");

#region Teste de tipos de Dados
    int tipoInteiro;
    Double tipoDouble;
    string tipoString;
    long tipoLong;

    tipoInteiro = int.MaxValue;
    tipoLong = tipoInteiro;
    // tipoInteiro = tipoLong

    tipoString = "100A";
    tipoInteiro = tipoInteiro;

    Console.WriteLine("O máximo de um tipo inteiro é: "+tipoInteiro);
    Console.WriteLine("O máximo de um tipo long é: "+tipoLong);

#endregion