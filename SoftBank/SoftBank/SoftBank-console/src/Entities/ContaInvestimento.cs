using SoftBank_console.src.Enums;
using SoftBank_console.src.Services;

namespace SoftBank_console.src.Entities
{
    public class ContaInvestimento : Contas
    {
        public TipoInvestimentoEnum TipoInvestimento { get; set; }

        public ContaInvestimento(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo, TipoInvestimentoEnum tipoInvestimento)
            :base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoConta = TipoContaEnum.ContaInvestimento;
            TipoInvestimento = tipoInvestimento;
        }

        public ContaInvestimento()
        {

        }

        public override string Extrato()
        {
            Transacoes <ContaInvestimento> transacao = new(this);
            transacao.GetAllMovimentation();

            //finalizar depois 

            return "Extrato Conta Investimento";
        }

        public string SimularInvestimento(TipoInvestimentoEnum tipoInvestimento, int tempoEmMeses, double Valor)
        {
            double PorcentagemAoAno = 0;

            switch (tipoInvestimento)
            {
                case TipoInvestimentoEnum.LCI:
                    PorcentagemAoAno = 0.08;
                    break;

                case TipoInvestimentoEnum.LCA:
                    PorcentagemAoAno = 0.09;
                    break;

                case TipoInvestimentoEnum.CDB:
                    PorcentagemAoAno = 0.1;
                    break;
            };

            double rendimentoAnual = (Valor * 12) + (Valor * PorcentagemAoAno);

            string msg = $"Valor aplicado:  {Valor}\n" +
                         $"Tipo de investimento: {tipoInvestimento}\n ({PorcentagemAoAno}% ao ano)" +
                         $"Rendimento mensal: {rendimentoAnual / 12}" +
                         $"Rendimento anual: {rendimentoAnual}\n";

            return msg;
        }

        public string AplicarInvestimento(TipoInvestimentoEnum tipoInvestimento, int tempoEmMeses, double Valor)
        {
            double PorcentagemAoAno = 0;

            switch (tipoInvestimento)
            {
                case TipoInvestimentoEnum.LCI:
                    PorcentagemAoAno = 0.08;
                    break;

                case TipoInvestimentoEnum.LCA:
                    PorcentagemAoAno = 0.09;
                    break;

                case TipoInvestimentoEnum.CDB:
                    PorcentagemAoAno = 0.1;
                    break;
            };

            return $"O Investimento foi feito com sussesso e já está rendendo {PorcentagemAoAno}% ao ano.";
        }

    }
}
