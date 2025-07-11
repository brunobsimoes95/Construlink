using System;
using System.Collections.Generic;

namespace Construlink.Data
{
    public class EnumOptions
    {
        public Dictionary<string, string> Modulos { get; private set; }
        public Dictionary<string, string> DebitoCredito { get; private set; }
        public Dictionary<string, string> Fluxos { get; private set; }

        public EnumOptions()
        {
            Modulos = new Dictionary<string, string>
            {
                { "V", "Vendas" },
                { "C", "Compras" },
                { "S", "Stocks" },
                { "I", "Internos" },
                { "T", "Tesouraria" }
            };

            DebitoCredito = new Dictionary<string, string>
            {
                { "D", "Débito" },
                { "C", "Crédito" }
            };

            Fluxos = new Dictionary<string, string>
            {
                { "E", "Entrada" },
                { "S", "Saída" },
                { "T", "Transferência" }
            };
        }
    }
}
