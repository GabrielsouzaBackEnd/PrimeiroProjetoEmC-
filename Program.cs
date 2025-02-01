//Screen Sound
using System.Runtime.CompilerServices;

string mensagemDeBoasVindas = "Boas Vindas Ao Screen Sound";
//List<string> ListasDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Queen", new List<int> { 7, 10 , 8});
bandasRegistradas.Add("The Beatles", new List<int> { 9, 8, 7 });

void ExibirLogo() 
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░

");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite a sua opção: ");
    String OpcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(OpcaoEscolhida); 
    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBandas();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarBandas();
            break;
        case 4: MediaDasBandas();
            break;
        case 5 : Console.WriteLine("Você escolheu a opção " + opcaoEscolhidaNumerica);
            break;
        default : Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBandas()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nRegistro de bandas");
    Console.Write("\nDigite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine("\nEssa banda já foi cadastrada.");
    }
    else 
    {
        bandasRegistradas.Add(nomeDaBanda, new List<int>());
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso.");
    }
    Thread.Sleep(1000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("Exibindo todas as bandas registradas");
    //for (int i = 0; i < ListasDasBandas.Count; i++)
    //{
    //    Console.WriteLine($"Banda: {ListasDasBandas[i]}");
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}


void AvaliarBandas()
{
    Console.Clear();
    ExibirLogo();
    Console.WriteLine("\nAvaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(1000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        ExibirOpcoesDoMenu();
    }
}

void MediaDasBandas()
{
    Console.Clear();
    ExibirLogo();
    Console.Write("Digite O nome da banda que deseja ver a média: ");
    string ProcurarBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(ProcurarBanda))
    {
        var notas = bandasRegistradas[ProcurarBanda];
        int soma = notas.Sum();
        double media = (double)soma / notas.Count;
        Console.WriteLine($"Media {media}");
    }
    Thread.Sleep(1000);
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

ExibirOpcoesDoMenu();

