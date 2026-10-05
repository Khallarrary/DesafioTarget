using DesafioTargetEstoque.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesafioTargetEstoque.Service
{
    internal class EstoqueService
    {
        private readonly List<ProdutoEstoque> _produtos;
        private readonly List<MovimentacaoEstoque> _movimentacoes = [];
        private int _proximoId = 1;
        public EstoqueService(RegistroEstoque estoque)
        {
            ArgumentNullException.ThrowIfNull(estoque);

            _produtos = estoque.Estoque;
        }

        public MovimentacaoEstoque Movimentar(int codigoProduto, TipoMovimentacao tipoMovimentacao, int quantidade, string descricao)
        {
            var itemEncontrado = _produtos.Find(item => item.CodigoProduto == codigoProduto);

            if (itemEncontrado == null)
            {
                throw new ArgumentException("Item não localizado", nameof(itemEncontrado.CodigoProduto));
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("Descricao invalida", nameof(itemEncontrado.DescricaoProduto));
            }

            if (tipoMovimentacao == TipoMovimentacao.Entrada)
            {
                itemEncontrado.AdicionarEstoque(quantidade);
            } else if(tipoMovimentacao == TipoMovimentacao.Saida)
            {
                itemEncontrado.RetirarEstoque(quantidade);
            }

            MovimentacaoEstoque movimentacao = new MovimentacaoEstoque(_proximoId, itemEncontrado.CodigoProduto, tipoMovimentacao, quantidade, descricao, itemEncontrado.Estoque);

            _movimentacoes.Add(movimentacao);

            _proximoId++;

            return movimentacao;
        }
    }
}
