.NET - P001 - Atividades de Programação em C#
Discente: Kayque Almeida Piton

Descrição:
Este projeto prático .NET - P001 está estruturado em regiões distintas, cada uma correspondendo a uma pergunta específica. O arquivo README.md detalha a configuração do ambiente .NET, tipos de dados numéricos, conversão de tipos, operadores aritméticos, operadores de comparação, operadores de igualdade, operadores lógicos e apresenta um desafio de mistura de operadores. Cada resposta está claramente separada em sua própria região, facilitando a navegação e a compreensão do conteúdo.

#region 1. Configuração do Ambiente

// Verificar a versão do .NET SDK instalado:
dotnet --version

// Atualizar o .NET SDK:
dotnet --version               // Verificar a versão atual
dotnet --list-sdks             // Listar as versões instaladas
dotnet --list-runtimes         // Listar runtimes instalados
dotnet --info                  // Exibir informações detalhadas
dotnet --install-sdk <version>  // Instalar uma versão específica

// Remover o .NET SDK:
dotnet --uninstall-sdk <version>

#endregion

#region 2. Tipos de Dados Numéricos Inteiros no .NET

// No .NET, os tipos de dados numéricos inteiros incluem:
sbyte
byte
short
ushort
int
uint
long
ulong

// Exemplos de uso:
int intValue = 10;
byte byteValue = 255;
short shortValue = -30000;
ushort ushortValue = 60000;
long longValue = 1234567890123456789;
ulong ulongValue = 9876543210987654321;

#endregion

#region 3. Conversão de Tipos de Dados

double doubleValue = 15.75;
int intValue = (int)doubleValue; // Conversão de double para int
Console.WriteLine("Valor convertido: " + intValue);

// Se a parte fracionária não puder ser convertida, a mesma será truncada.

#endregion

#region 4. Operadores Aritméticos

int x = 10;
int y = 3;
Console.WriteLine("Adição: " + (x + y));
Console.WriteLine("Subtração: " + (x - y));
Console.WriteLine("Multiplicação: " + (x * y));
Console.WriteLine("Divisão: " + (x / y));

#endregion

#region 5. Operadores de Comparação

int a = 5;
int b = 8;
if (a > b){
    Console.WriteLine("a é maior que b.");
}
else{
    Console.WriteLine("a não é maior que b.");
}

#endregion

#region 6. Operadores de Igualdade

string str1 = "Hello";
string str2 = "World";
if (str1 == str2){
    Console.WriteLine("As strings são iguais.");
}
else{
    Console.WriteLine("As strings são diferentes.");
}

#endregion

#region 7. Operadores Lógicos

bool condicao1 = true;
bool condicao2 = false;
if (condicao1 && condicao2){
    Console.WriteLine("Ambas as condições são verdadeiras.");
}
else{
    Console.WriteLine("Pelo menos uma das condições é falsa.");
}

#endregion

#region 8. Desafio de Mistura de Operadores

int num1 = 7;
int num2 = 3;
int num3 = 10;
if (num1 > num2 && num3 == num1 + num2){
    Console.WriteLine("num1 é maior que num2, e num3 é igual a num1 + num2.");
}
else{
    Console.WriteLine("As condições não são atendidas.");
}

#endregion
