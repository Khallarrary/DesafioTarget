using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTargetEstoque.Domain
{
    internal class MovimentacaoEstoque
    {
        public int IdMovimentacao { get; private set; }
        public int CodigoProdutoMovimentado { get; private set; }
        public TipoMovimentacao TipoMovimentacao { get; private set; }
        public int  QuantidadeMovimentada { get; private set; }
        public string DescricaoMovimentacao { get; private set; }
        public int EstoqueFinal {  get; private set; }

        public MovimentacaoEstoque(int idMovimentacao, int codigoProdutoMovimentado, TipoMovimentacao tipoMovimentacao, int quantidadeMovimentada, string descricaoMovimentacao, int estoqueFinal)
        {
            if(idMovimentacao <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(idMovimentacao), idMovimentacao, "Id da movimentacao invalido");
            }

            if(codigoProdutoMovimentado <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(codigoProdutoMovimentado), codigoProdutoMovimentado, "Codigo do produto invalido");
            }

            if (string.IsNullOrWhiteSpace(descricaoMovimentacao))
            {
                throw new ArgumentException("Descricao da movimentacao invalida", nameof(descricaoMovimentacao));
            }

            if (quantidadeMovimentada <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantidadeMovimentada), quantidadeMovimentada, "Quantidade movimentada inválida");
            }

            if (estoqueFinal < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(estoqueFinal), estoqueFinal, "Quantidade no estoque invalida");
            }


            IdMovimentacao = idMovimentacao;
            CodigoProdutoMovimentado = codigoProdutoMovimentado;
            TipoMovimentacao = tipoMovimentacao;
            QuantidadeMovimentada = quantidadeMovimentada;
            DescricaoMovimentacao = descricaoMovimentacao;
            EstoqueFinal = estoqueFinal;
        }
    }
}
