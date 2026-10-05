using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTargetEstoque.Domain
{
    public class ProdutoEstoque
    {
        public int CodigoProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public int Estoque { get; private set; }
       

        public ProdutoEstoque(int codigoProduto, string descricaoProduto, int estoque)
        {
            if (codigoProduto <= 0) 
            {
                throw new ArgumentOutOfRangeException("Codigo do produto invalido");
            }

            if (string.IsNullOrEmpty(descricaoProduto))
            {
                throw new ArgumentException("Descricao do produto invalida");
            }

            if(Estoque < 0)
            {
                throw new ArgumentOutOfRangeException("Quantidade do produto invalida");
            }

            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            Estoque = estoque;
        }

        public void AdicionarEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantidade), quantidade, "Quantidade do produto invalida");
            }

            Estoque += quantidade;
        }

        public void RetirarEstoque(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantidade), quantidade, "Quantidade do produto invalida");
            }

            if (quantidade > Estoque) 
            {
                throw new InvalidOperationException("Nao possui quantidade em estoque para retirada");
            }

            Estoque -= quantidade;
        }
    }
}
