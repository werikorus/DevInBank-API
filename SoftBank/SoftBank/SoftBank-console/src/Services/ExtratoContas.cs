using System;
using SoftBank_console.src.Mocks;


namespace SoftBank_console.src.Services
{
    public class ExtratoContas 
    {
        public string Conta { get; set; }
        public string Movimentacao { get; set; }

        public ExtratoContas(string conta, string mov)
        {
            Conta = conta;
            Movimentacao = mov;
        }
    }
}
