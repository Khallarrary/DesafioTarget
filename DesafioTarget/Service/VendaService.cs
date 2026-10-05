using DesafioTargetVendas.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioTargetVendas.Service
{
    internal class VendaService
    {

        public Dictionary<string, decimal> CalcularComissoes(RegistroVendas registro)
        {
            if (registro == null) 
            {
                throw new ArgumentNullException("Registro de vendas esta vazio");
            }

            var comissoes = new Dictionary<string, decimal>();

            foreach(var venda in registro.Vendas)
            {
                if(comissoes.ContainsKey(venda.Vendedor))
                {
                   comissoes[venda.Vendedor] += venda.Comissao;
                } else
                {
                    comissoes.Add(venda.Vendedor, venda.Comissao);
                }
            }

            return comissoes;
        }
    }
}
