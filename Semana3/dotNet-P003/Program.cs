using System;
using System.Collections.Generic;
using System.Linq;

class GerenciadorEstoque{
    static void Main(){
        List<(int Codigo, string Nome, int Quantidade, double Preco)> estoque = new List<(int, string, int, double)>();

        while (true){
            Console.WriteLine("===== Sistema de Gerenciamento de Estoque =====");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Consultar Produto");
            Console.WriteLine("3 - Atualizar Estoque");
            Console.WriteLine("4 - Gerar Relatórios");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine));

            try{
                switch (opcao){
                    case "1":
                        CadastrarProduto(estoque);
                        break;
                    case "2":
                        ConsultarProduto(estoque);
                        break;
                    case "3":
                        AtualizarEstoque(estoque);
                        break;
                    case "4":
                        GerarRelatorios(estoque);
                        break;
                    case "0":
                        Console.WriteLine("Saindo do sistema. Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (FormatException ex){
                Console.WriteLine($"Erro: {ex.Message}. Certifique-se de inserir os dados corretamente.");
            }
            catch (InvalidOperationException ex){
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (Exception ex){
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    static void CadastrarProduto(List<(int, string, int, double)> estoque){
        Console.Write("\nCódigo do Produto: ");
        string codigoStr = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine));

        if (!int.TryParse(codigoStr, out int codigo)){
            Console.WriteLine("Código inválido. Insira um número inteiro.");
            return;
        }

        if (estoque.Any(p => p.Item1 == codigo)){
            Console.WriteLine("Já existe um produto com esse código. Insira um código único.");
            return;
        }

        Console.Write("Nome do Produto: ");
        string nome = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine));

        Console.Write("Quantidade em Estoque: ");
        int quantidade = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        Console.Write("Preço Unitário: ");
        double preco = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        estoque.Add((codigo, nome, quantidade, preco));
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void ConsultarProduto(List<(int, string, int, double)> estoque){
        Console.Write("\nInforme o Código do Produto: ");
        string codigoStr = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine));

        if (!int.TryParse(codigoStr, out int codigoBusca)){
            Console.WriteLine("Código inválido. Insira um número inteiro.");
            return;
        }

        var produto = estoque.FirstOrDefault(p => p.Item1 == codigoBusca);

        Console.WriteLine($"Produto encontrado: {produto.Item2}, Quantidade: {produto.Item3}, Preço: {produto.Item4:C}");
  
    }

    static void AtualizarEstoque(List<(int, string, int, double)> estoque){
        Console.Write("\nDigite o tipo de operação desejada (\"+\" para Entrada ou \"-\" para Saída): ");
        string tipoOperacao = Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine));

        if (tipoOperacao != "+" && tipoOperacao != "-"){
            Console.WriteLine("Tipo de operação inválido. Use \"+\" para entrada e \"-\" para saída.");
            return;
        }

        Console.Write("Digite a quantidade: ");
        int quantidade = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        int operacao = (tipoOperacao == "+") ? quantidade : -quantidade;

        Console.Write("Informe o Código do Produto: ");
        int codigoBusca = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        var produto = estoque.FirstOrDefault(p => p.Item1 == codigoBusca);

        if ((operacao > 0) || (operacao < 0 && produto.Item3 >= quantidade)){
            var novoProduto = (produto.Item1, produto.Item2, produto.Item3 + operacao, produto.Item4);
            estoque[estoque.IndexOf(produto)] = novoProduto;
            Console.WriteLine("Estoque atualizado com sucesso!");
        }
        else{
            throw new InvalidOperationException("Quantidade insuficiente em estoque para realizar a saída.");
        }
    }

    static void GerarRelatorios(List<(int, string, int, double)> estoque){
        Console.Write("\nInforme o Limite de Quantidade para o Relatório 1: ");
        int limiteQuantidade = int.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        var relatorio1 = estoque.Where(p => p.Item3 < limiteQuantidade);
        ImprimirRelatorio("Relatório 1: Produtos com Quantidade Abaixo do Limite", relatorio1);

        Console.Write("Informe o Valor Mínimo para o Relatório 2: ");
        double valorMinimo = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        Console.Write("Informe o Valor Máximo para o Relatório 2: ");
        double valorMaximo = double.Parse(Console.ReadLine() ?? throw new ArgumentNullException(nameof(Console.ReadLine)));

        var relatorio2 = estoque.Where(p => p.Item4 >= valorMinimo && p.Item4 <= valorMaximo);
        ImprimirRelatorio("Relatório 2: Produtos com Valor Entre Mínimo e Máximo", relatorio2);

        var relatorio3 = estoque.Select(p => (Nome: p.Item2, ValorTotal: p.Item3 * p.Item4));

        double valorTotalEstoque = relatorio3.Sum(p => p.ValorTotal);

        Console.WriteLine($"Relatório 3: Valor Total do Estoque: {valorTotalEstoque:C}");
        foreach (var item in relatorio3){
            Console.WriteLine($"Produto: {item.Nome}, Valor Total: {item.ValorTotal:C}");
        }
    }

    static void ImprimirRelatorio(string titulo, IEnumerable<(int, string, int, double)> relatorio){
        Console.WriteLine($"{titulo}");
        foreach (var produto in relatorio){
            Console.WriteLine($"Produto: {produto.Item2}, Quantidade: {produto.Item3}, Preço: {produto.Item4:C}");
        }
        Console.WriteLine();
    }
}
