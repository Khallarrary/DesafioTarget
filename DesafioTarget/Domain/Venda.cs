using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTargetVendas.Domain
{
    internal class Venda
    {
        public string Vendedor { get; private set; } = string.Empty;
        public decimal Valor { get; private set; }
        public decimal Comissao { get; private set; }


        public Venda (string vendedor, decimal valor) 
        {
            if (String.IsNullOrWhiteSpace(vendedor))
            {
                throw new ArgumentException("Deve conter um vendedor válido");
            }

            if (valor < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), valor, "Valor nao deve ser negativo");
            }

            Vendedor = vendedor;
            Valor = valor;

            if(valor < 100)
            {
                Comissao = 0;
            } else if(valor < 500)

            {
                Comissao = valor / 100 * 1;
            }
            else
            {
                Comissao = valor / 100 * 5;
            }
        }


        
    }
}
