using SoftBank_console.src.Enums;
using SoftBank_console.src.Services;
using System.Collections.Generic;

namespace SoftBank_console.src.Entities
{
    public class ContaCorrente : Contas
    {
        public double ChequeEspecial { get; set; }

        public ContaCorrente(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoConta = TipoContaEnum.ContaCorrente;
            ChequeEspecial = rendaMensal * 0.1;

            if (Saldo < -ChequeEspecial)
                throw new("Não é possível Saldo negativo abaixo do limite de cheque especial!");
            else
                Saldo = saldo;
        }

        public ContaCorrente()
        {

        }
        public override string Extrato()
        {
            Transacoes<ContaCorrente> transacao = new(this);
            transacao.GetAllMovimentation();

            //finalizar depois 

            return "Extrato Conta Corrente";
        }
    }
}
