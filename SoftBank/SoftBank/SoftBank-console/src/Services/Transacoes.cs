using System;
using System.Collections.Generic;
using SoftBank_console.src.Entities;
using SoftBank_console.src.Interfaces;


namespace SoftBank_console.src.Services
{
    public class Transacoes<T> : ITransacoes<T>
    {
        public Contas Self { get; set; }

        public Transacoes(Contas Conta) 
        {
            Self = Conta;
        }

        public void SaveTransaction()
        {
            string movimento = $"Conta: {Self.Conta}\n" +
                               $"Cpf: {Self.Cpf}\n" +
                               $"Operacao: {Self.Operacao}\n" +
                               $"Valor: ${Self.Valor}\n " +
                               $"Data Transação: {new DateTime().Date}";

            ExtratoContas extrato = new ExtratoContas(Self.Conta, movimento);
        }

        public List<ExtratoContas> GetAllMovimentation()
        {
            List<ExtratoContas> listaExtrato = new();

            return listaExtrato;
        }

    }
}
