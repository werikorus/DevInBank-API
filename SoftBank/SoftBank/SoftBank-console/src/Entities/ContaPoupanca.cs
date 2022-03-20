using SoftBank_console.src.Enums;

namespace SoftBank_console.src.Entities
{
    public class ContaPoupanca : Contas
    {
        public ContaPoupanca(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoConta = TipoContaEnum.ContaPoupanca;

            if (saldo < 0)
            {
                string msg = "Não é possível";
            }
            else
            {
                Saldo = saldo;
            }
        }
        public ContaPoupanca()
        {

        }

        public override string Extrato()
        {
            return "Extrato Conta Poupança";
        }

        public string SimularRentabilidade(int TempoEmMeses, double ValorMensal)
        {
            double taxa = 0.1075;
            double total = 0;

            string msg = $"Valor de investimento mensal: {ValorMensal}\n"+
                         $"Tempo de investimento: {TempoEmMeses} meses\n"+
                         $"Total de investimento: R$ {ValorMensal * TempoEmMeses}\n"+
                         $"Taxa de rendimento: {taxa}\n" +
                         $"Total em {TempoEmMeses} meses: R${total}\n";

            return msg; 
        }
    }
}
