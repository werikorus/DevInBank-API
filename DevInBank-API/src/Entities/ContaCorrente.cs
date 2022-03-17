using DevInBank_API.src.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInBank_API.src.Entities
{
    public class ContaCorrente : Contas
    {
        public ContaCorrente(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {

        }

        public ContaCorrente()
        {

        }

        public override string Extrato()
        {
            return "Extrato Conta Corrente";
        }
    }
}
