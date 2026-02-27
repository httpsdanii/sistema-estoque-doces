Dictionary<string, int> produto = new Dictionary<string, int>
{
        { "Cookie", 50 },
        { "Brownie", 40 }
};


Boolean executando = true;

MenuLoja();
void MenuLoja()
{
    while (executando)
    {
        Console.Clear();
        ExibirTituloDaOpcao("Bem-vindo(a) à nossa loja de doces!");


        Console.WriteLine("O que deseja?\n");
        Console.WriteLine("1 - Visualizar estoque");
        Console.WriteLine("2 - Adicionar itens ao estoque");
        Console.WriteLine("3 - Remover itens do estoque");
        Console.WriteLine("4 - Sair\n");

        Console.Write("Digite sua opção: ");
        string opcao = Console.ReadLine();

        if (int.TryParse(opcao, out int opcaonumerica))
        {
            switch (opcaonumerica)
            {
                case 1:
                    VisuEstoque();
                    break;
                case 2:
                    AdicionarAoEstoque();
                    break;
                case 3:
                    RemoverEstoque();
                    break;
                case 4:
                    Console.WriteLine("Até mais!");
                    executando = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Thread.Sleep(1500);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Digite um número válido!");
            Thread.Sleep(1500);
        }
    }
}



void VisuEstoque()
{
    Console.Clear();
    ExibirTituloDaOpcao("ESTOQUE DE PRODUTOS");

    if (produto.Count == 0)
    {
        Console.WriteLine("Estoque vazio!\n");
    }
    else
    {
        foreach (var prod in produto)
        {
            Console.WriteLine($"Produto: {prod.Key} | Quantidade: {prod.Value}");
        }
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
    Console.ReadKey();
}




void AdicionarAoEstoque()
{
    Console.Clear();
    ExibirTituloDaOpcao("ADIÇÃO DE PRODUTOS");

    Console.Write("Qual produto você deseja adicionar? ");
    string entradaprod = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(entradaprod))
    {
        Console.WriteLine("\nNome do produto inválido!");
        Thread.Sleep(2000);
        return;
    }

    Console.Write("Qual a quantidade do produto: ");
    if (!int.TryParse(Console.ReadLine(), out int entradaqntd) || entradaqntd <= 0)
    {
        Console.WriteLine("\nQuantidade inválida! Digite um número positivo.");
        Thread.Sleep(2000);
        return;
    }

    if (!produto.ContainsKey(entradaprod))
    {
        produto.Add(entradaprod, entradaqntd);
        Console.WriteLine($"\nProduto '{entradaprod}' adicionado com sucesso!");
    }
    else
    {
        produto[entradaprod] += entradaqntd;
        Console.WriteLine($"\nQuantidade atualizada! Agora '{entradaprod}' tem {produto[entradaprod]} unidades.");
    }

    Thread.Sleep(2000);
}




void RemoverEstoque()
{
    Console.Clear();
    ExibirTituloDaOpcao("REMOÇÃO DE PRODUTOS");

    if (produto.Count == 0)
    {
        Console.WriteLine("Estoque vazio! Nada para remover.\n");
        Console.WriteLine("Pressione qualquer tecla para voltar");
        Console.ReadKey();
        return;
    }


    foreach (var prod in produto)
    {
        Console.WriteLine($"Produto: {prod.Key} | Quantidade: {prod.Value}");
    }

    Console.Write("\nQual produto deseja remover? ");
    string nomeprod = Console.ReadLine();

    if (!produto.ContainsKey(nomeprod))
    {
        Console.WriteLine($"\nProduto '{nomeprod}' não encontrado!");
        Console.ReadKey();
        return;
    }

    Console.WriteLine("\n1 - Remover produto inteiro");
    Console.WriteLine("2 - Remover quantidade");
    Console.Write("\nEscolha: ");

    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        produto.Remove(nomeprod);
        Console.WriteLine($"\nProduto '{nomeprod}' removido com sucesso!");
    }
    else if (opcao == "2")
    {
        int quantidadeAtual = produto[nomeprod];

        Console.Write($"Remover quantas unidades de '{nomeprod}' (máximo {quantidadeAtual}): ");

        if (int.TryParse(Console.ReadLine(), out int remover) && remover > 0)
        {
            if (remover >= quantidadeAtual)
            {
                produto.Remove(nomeprod);
                Console.WriteLine($"\n'{nomeprod}' removido do sistema (estoque zerado)");
            }
            else
            {
                produto[nomeprod] = quantidadeAtual - remover;
                Console.WriteLine($"\nQuantidade atualizada! Agora '{nomeprod}' tem {produto[nomeprod]} unidades");
            }
        }
        else
        {
            Console.WriteLine("\nQuantidade inválida!");
        }
    }
    else
    {
        Console.WriteLine("\nOpção inválida!");
    }

    Thread.Sleep(2000);
}



void ExibirTituloDaOpcao(string titulo)
{
    int qntdletras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(qntdletras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}
