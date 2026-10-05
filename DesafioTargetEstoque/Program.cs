using DesafioTargetEstoque.Data;
using DesafioTargetEstoque.Domain;
using DesafioTargetEstoque.Service;

LeitorEstoqueJson leitor = new LeitorEstoqueJson();

var caminho = Path.Combine(
    AppContext.BaseDirectory,
    "Json",
    "estoque.json"
);

var resultado = leitor.Ler(caminho);

EstoqueService service = new EstoqueService(resultado);

int opcao = 0;

void Menu() {
 Console.WriteLine("Caso queira fazer outra movimentacao digite 0 e qualquer outro numero para encerrar");

 if (!int.TryParse(Console.ReadLine(), out opcao))
 {
     Console.WriteLine("Opção inválida. O programa será encerrado.");
     opcao = -1;
 }
}

while(opcao == 0)
{
    Console.Write("Codigo do produto a ser movimentado: ");
    if (!int.TryParse(Console.ReadLine(), out int codigoProduto))
    {
        Console.WriteLine("Código do produto inválido.");
        continue;
    }

    Console.Write("O tipo de movimentacao, entrada ou saida do estoque: ");
    string? tipo = Console.ReadLine();

    if(!Enum.TryParse<TipoMovimentacao>(tipo, ignoreCase: true, out var tipoConvertido) || !Enum.IsDefined(tipoConvertido)){
        Console.WriteLine("Tipo Invalido.");
        continue;
    }

    Console.Write("Quantidade do produto a ser movimentado: ");
    if (!int.TryParse(Console.ReadLine(), out int quantidadeProduto))
    {
        Console.WriteLine("Quantidade inválida.");
        continue;
    }

    Console.Write("Descricao da movimentacao: ");
    string descricao = Console.ReadLine() ?? string.Empty;

    try
    {
        var movimentacao = service.Movimentar(codigoProduto, tipoConvertido, quantidadeProduto, descricao);

        Console.WriteLine($"Movimentação: {movimentacao.IdMovimentacao} | Estoque final: {movimentacao.EstoqueFinal}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Não foi possível realizar a movimentação: {ex.Message}");
        continue;
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Não foi possível realizar a movimentação: {ex.Message}");
        continue;
    }

    Menu();
}
