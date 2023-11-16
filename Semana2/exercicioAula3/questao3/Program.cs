for (int i = 1; i <= 8; i++){
    for (int j = 1; j <= i; j++){
        int multiplo = i * j;
        Console.Write($"{multiplo} ");
    }

    Console.WriteLine(); // Pular para a próxima linha após imprimir os múltiplos de i
}