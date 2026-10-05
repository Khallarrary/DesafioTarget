using DesafioTargetVendas.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesafioTargetVendas.Data
{
    internal class LeitorVendasJson
    {
        public RegistroVendas Ler(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                throw new ArgumentException(
                    "O caminho é obrigatório.",nameof(caminho));
            }

            if (!File.Exists(caminho))
            {
                throw new FileNotFoundException("Arquivo não encontrado.", caminho);
            }

            string json = File.ReadAllText(caminho);

            var opcoes = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,

                
            };

            RegistroVendas? registroVendas = JsonSerializer.Deserialize<RegistroVendas>(json, opcoes);

            if (registroVendas is null)
            {
                throw new JsonException("O JSON está vazio ou não pôde ser convertido.");
            }

            return registroVendas;
        }


    }
}
 