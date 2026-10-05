using System.Globalization;

decimal CalcularJuros(decimal valorConta, DateTime data)
{
    
    int diasEmAtraso = Math.Max(0, (DateTime.Today - data.Date).Days);

    decimal juros = valorConta * 0.025m * diasEmAtraso;
    
    return juros;
}

int opcao = 0;

void Menu()
{
    Console.WriteLine("Caso queira fazer outro calculo digite 0 e qualquer outro numero para encerrar");

    if (!int.TryParse(Console.ReadLine(), out opcao))
    {
        Console.WriteLine("Opção inválida. O programa será encerrado.");
        opcao = -1;
    }
}

while (opcao == 0)
{
    Console.Write("Digite o valor da conta que deseja calcular os juros: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal valorConta) || valorConta <= 0)
    {
        Console.WriteLine("Valor inválido.");
        continue;
    }

    Console.Write("Digite a data de vencimento da conta que deseja calcular os juros: ");
    string? dataDigitada = Console.ReadLine();

    if (!DateTime.TryParseExact(
        dataDigitada,
        "dd/MM/yyyy",
        CultureInfo.InvariantCulture,
        DateTimeStyles.None,
        out DateTime dataConta))
    {
        Console.WriteLine("Data inválida. Use o formato dd/MM/aaaa.");
        continue;
    }

    var juros = CalcularJuros(valorConta, dataConta);

    Console.WriteLine($"Juros: R$ {juros:F2}");

    Menu();
}
