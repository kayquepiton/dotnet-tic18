int limite = 100;
int primeiroTermo = 0;
int segundoTermo = 1;

Console.WriteLine($"Sequência de Fibonacci até {limite}:");
Console.Write($"{primeiroTermo} {segundoTermo}");

while (segundoTermo + primeiroTermo <= limite){
    int proximoTermo = primeiroTermo + segundoTermo;
    Console.Write($" {proximoTermo}");
    primeiroTermo = segundoTermo;
    segundoTermo = proximoTermo;
}
