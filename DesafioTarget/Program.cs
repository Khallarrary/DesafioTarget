using DesafioTargetVendas.Data;
using DesafioTargetVendas.Service;

VendaService vendaService = new VendaService();
LeitorVendasJson leitor = new LeitorVendasJson();

var caminho = Path.Combine(
    AppContext.BaseDirectory,
    "Json",
    "vendas.json"
);

var resultado = leitor.Ler(caminho);

var comissoes = vendaService.CalcularComissoes(resultado);

foreach (var como in comissoes)
{
    Console.WriteLine($"{como.Key} - R$ { como.Value:F2}");
}