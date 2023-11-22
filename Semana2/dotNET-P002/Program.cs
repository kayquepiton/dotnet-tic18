using System;
using System.Collections.Generic;

class GerenciadorDeTarefas{
    static List<Tarefa> tarefas = new List<Tarefa>();

    static void Main(){
        while (true){
            Console.WriteLine("===== Sistema de Gerenciamento de Tarefas =====");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-Chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha){
                case 1:
                    CriarTarefa();
                    break;
                case 2:
                    ListarTodasAsTarefas();
                    break;
                case 3:
                    MarcarTarefaComoConcluida();
                    break;
                case 4:
                    ListarTarefasPendentes();
                    break;
                case 5:
                    ListarTarefasConcluidas();
                    break;
                case 6:
                    ExcluirTarefa();
                    break;
                case 7:
                    PesquisarTarefasPorPalavraChave();
                    break;
                case 8:
                    ExibirEstatisticas();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CriarTarefa(){
        Console.Write("\nDigite o título da tarefa: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite a data de vencimento (DD/MM/AAAA): ");
        string inputData = Console.ReadLine();

        // ParseExact para converter a string no formato especificado
        DateTime dataDeVencimento;
        if (DateTime.TryParseExact(inputData, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dataDeVencimento)){
            Tarefa novaTarefa = new Tarefa(titulo, descricao, dataDeVencimento);
            tarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa criada com sucesso!\n");
        }
        else{
            Console.WriteLine("Formato de data inválido. Use o formato DD-MM-AAAA.");
        }
    }


    static void ListarTodasAsTarefas(){
        Console.WriteLine("\n===== Lista de Todas as Tarefas =====");
        foreach (var tarefa in tarefas){
            Console.WriteLine(tarefa);
        }
        Console.WriteLine("\n");
    }

    static void MarcarTarefaComoConcluida(){
        Console.Write("\nDigite o ID da tarefa a ser marcada como concluída: ");
        int idTarefa = int.Parse(Console.ReadLine());

        if (idTarefa >= 0 && idTarefa < tarefas.Count){
            tarefas[idTarefa].EstaConcluida = true;
            Console.WriteLine("Tarefa marcada como concluída!\n");
        }
        else{
            Console.WriteLine("ID de tarefa inválido.");
        }
    }

    static void ListarTarefasPendentes(){
        Console.WriteLine("\n===== Lista de Tarefas Pendentes =====");

        bool existemTarefasPendentes = false;

        foreach (var tarefa in tarefas){
            if (!tarefa.EstaConcluida){
                Console.WriteLine(tarefa);
                existemTarefasPendentes = true;
            }
        }

        if (!existemTarefasPendentes){
            Console.WriteLine("Não existem tarefas pendentes.\n");
        }

        Console.WriteLine("\n");
    }


    static void ListarTarefasConcluidas(){
        Console.WriteLine("\n===== Lista de Tarefas Concluídas =====");

        bool existemTarefasConcluidas = false;

        foreach (var tarefa in tarefas){
            if (tarefa.EstaConcluida){
                Console.WriteLine(tarefa);
                existemTarefasConcluidas = true;
            }
        }

        if (!existemTarefasConcluidas){
            Console.WriteLine("Não existem tarefas concluídas.\n");
        }
        Console.WriteLine("\n");
    }


    static void ExcluirTarefa(){
        Console.Write("\nDigite o ID da tarefa a ser excluída: ");
        int idTarefa = int.Parse(Console.ReadLine());

        if (idTarefa >= 0 && idTarefa < tarefas.Count){
            tarefas.RemoveAt(idTarefa);
            Console.WriteLine("Tarefa excluída com sucesso!");
        }
        else{
            Console.WriteLine("ID de tarefa inválido.");
        }
    }

    static void PesquisarTarefasPorPalavraChave(){
        Console.Write("\nDigite a palavra-chave para a pesquisa: ");
        string palavraChave = Console.ReadLine().ToLower();

        Console.WriteLine($"===== Resultados da Pesquisa para '{palavraChave}' =====");
        foreach (var tarefa in tarefas){
            if (tarefa.Titulo.ToLower().Contains(palavraChave) || tarefa.Descricao.ToLower().Contains(palavraChave)){
                Console.WriteLine(tarefa);
            }
            Console.Write("\n");
        }
    }

    static void ExibirEstatisticas(){
        int totalTarefas = tarefas.Count;
        int tarefasConcluidas = tarefas.Count(tarefa => tarefa.EstaConcluida);
        int tarefasPendentes = totalTarefas - tarefasConcluidas;

        if (totalTarefas > 0){
            Tarefa tarefaMaisAntiga = tarefas.Min();
            Tarefa tarefaMaisRecente = tarefas.Max();

            Console.WriteLine($"\n===== Estatísticas =====");
            Console.WriteLine($"Total de Tarefas: {totalTarefas}");
            Console.WriteLine($"Tarefas Concluídas: {tarefasConcluidas}");
            Console.WriteLine($"Tarefas Pendentes: {tarefasPendentes}");
            Console.WriteLine($"Tarefa Mais Antiga: {tarefaMaisAntiga}");
            Console.WriteLine($"Tarefa Mais Recente: {tarefaMaisRecente}");
        }
        else{
            Console.WriteLine("Nenhuma tarefa encontrada para exibir estatísticas.");
        }
        Console.Write("\n");
    }
}

class Tarefa : IComparable<Tarefa>{
    private static int proximoId = 0;

    public int Id { get; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataDeVencimento { get; set; }
    public bool EstaConcluida { get; set; }

    public Tarefa(string titulo, string descricao, DateTime dataDeVencimento){
        Id = proximoId++;
        Titulo = titulo;
        Descricao = descricao;
        DataDeVencimento = dataDeVencimento;
        EstaConcluida = false;
    }

    public override string ToString(){
        string status = EstaConcluida ? "Concluída" : "Pendente";
        return $"ID: {Id}, Título: {Titulo}, Descrição: {Descricao}, Data de Vencimento: {DataDeVencimento}, Status: {status}";
    }

    public int CompareTo(Tarefa outra){
        return DataDeVencimento.CompareTo(outra.DataDeVencimento);
    }
}
