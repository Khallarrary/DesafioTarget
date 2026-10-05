# Desafio Target

Solução em C# para três exercícios de Console: cálculo de comissões, movimentação de estoque e cálculo de juros por atraso.

## Requisitos

- .NET SDK 10.0

## Projetos

### DesafioTargetVendas

Lê `vendas.json`, calcula a comissão de cada venda e apresenta o total por vendedor.

Regras:

- Valor abaixo de R$ 100,00: 0%.
- Valor entre R$ 100,00 e R$ 499,99: 1%.
- Valor a partir de R$ 500,00: 5%.

Executar:

```powershell
dotnet run --project .\DesafioTarget\DesafioTargetVendas.csproj
```

### DesafioTargetEstoque

Lê `estoque.json` e permite registrar entradas e saídas. Cada movimentação recebe um ID sequencial, uma descrição e registra o saldo final.

Validações principais:

- Produto deve existir.
- Quantidade deve ser positiva.
- Saída não pode ultrapassar o saldo disponível.
- Tipo deve ser `Entrada` ou `Saida`.

Executar:

```powershell
dotnet run --project .\DesafioTargetEstoque\DesafioTargetEstoque.csproj
```

### DesafioTargetJuros

Calcula juros simples de 2,5% ao dia com base no valor da conta e na data de vencimento.

A data deve ser informada no formato `dd/MM/aaaa`. Contas ainda não vencidas geram juros iguais a zero.

Executar:

```powershell
dotnet run --project .\DesafioTargetJuros\DesafioTargetJuros.csproj
```

## Estrutura

```text
DesafioTarget/
  Data/            leitura do JSON de vendas
  Domain/          modelos e regra de comissão
  Json/            arquivos de entrada
  Service/         consolidação das comissões

DesafioTargetEstoque/
  Data/            leitura do JSON de estoque
  Domain/          produto, movimentação e tipo
  Json/            arquivo de entrada
  Service/         processamento das movimentações

DesafioTargetJuros/
  Program.cs       entrada, cálculo e saída
```

## Decisões

- Valores monetários utilizam `decimal`.
- Arquivos JSON são copiados para o diretório de saída na compilação.
- O estoque e o histórico de movimentações são mantidos em memória.
- IDs de movimentação reiniciam a cada execução.
- O cálculo de juros utiliza juros simples.
- A data atual é obtida do relógio local da máquina.
