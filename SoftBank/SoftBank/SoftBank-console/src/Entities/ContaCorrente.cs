using SoftBank_console.src.Enums;

namespace SoftBank_console.src.Entities
{
    public class ContaCorrente : Contas
    {
        public ContaCorrente(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo) 
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoConta = TipoContaEnum.ContaCorrente;
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
