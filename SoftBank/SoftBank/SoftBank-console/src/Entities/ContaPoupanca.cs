using SoftBank_console.src.Enums;
using SoftBank_console.src.Services;

namespace SoftBank_console.src.Entities
{
    public class ContaPoupanca : Contas
    {
        public ContaPoupanca(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoConta = TipoContaEnum.ContaPoupanca;

            if (saldo < 0)
                throw new("Não é possível Saldo negativo para Conta Poupança!");
            else
                Saldo = saldo;
        }
        public ContaPoupanca()
        {

        }

        public override string Extrato()
        {
            Transacoes<ContaPoupanca> transacao = new(this);
            transacao.GetAllMovimentation();

            //finalizar depois
            return "Extrato Conta Poupança";
        }

        public string SimularRentabilidade(int TempoEmMeses, double ValorMensal)
        {
            if (TempoEmMeses <= 0 || ValorMensal <= 0)
                throw new($"Tempo em meses ou Valor mensal inválido para simulação!");
            else
            {
                double taxaSelic = 0.1175;
                double total = (ValorMensal * 12) + (ValorMensal * taxaSelic);

                string msg = $"\nValor de investimento mensal: {ValorMensal}\n" +
                             $"Tempo de investimento: {TempoEmMeses} meses\n" +
                             $"Total de investimento: R$ {ValorMensal * TempoEmMeses}\n" +
                             $"Taxa de rendimento anual: {taxaSelic}\n" +
                             $"Total em {TempoEmMeses} meses: R${total}\n";
                
                return msg;
            }
        }
    }
}
