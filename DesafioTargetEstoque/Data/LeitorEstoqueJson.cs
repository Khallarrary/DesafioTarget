using DesafioTargetEstoque.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DesafioTargetEstoque.Data
{
    internal class LeitorEstoqueJson
    {
        public RegistroEstoque Ler(string caminho)
        {
            if (string.IsNullOrWhiteSpace(caminho))
            {
                throw new ArgumentException(
                    "O caminho é obrigatório.", nameof(caminho));
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

            RegistroEstoque? registroEstoque = JsonSerializer.Deserialize<RegistroEstoque>(json, opcoes);

            if (registroEstoque is null)
            {
                throw new JsonException("O JSON está vazio ou não pôde ser convertido.");
            }

            return registroEstoque;
        }
    }
 }
