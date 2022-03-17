using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInBank_API.src.Enums;

namespace DevInBank_API.src.Entities
{
    public class ContaInvestimento : Contas
    {

        public TipoInvestimentoEnum TipoInvestimento { get; set; }


        public ContaInvestimento(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo, TipoInvestimentoEnum tipoInvestimento)
            : base(nome, cPF, endereco, rendaMensal, agencia, saldo)
        {
            TipoInvestimento = tipoInvestimento;
        }

        public ContaInvestimento()
        {

        }

        public override string Extrato()
        {
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

            double rendimentoAnual = Valor * PorcentagemAoAno;

            string msg = $"Valor aplicado:  {Valor}\n" +
                         $"Tipo de investimento: {tipoInvestimento}\n ({PorcentagemAoAno}% ao ano)" +
                         $"Rendimento mensal: {rendimentoAnual / 12}" +
                         $"Rendimento anual: {rendimentoAnual}\n";


            return msg;

            bool aplicar = false;

            if (aplicar)
            {
                AplicarInvestimento(tipoInvestimento, Valor);
            }
            else
            {
                return default;
            }
        }

        public string AplicarInvestimento(TipoInvestimentoEnum tipoInvestimento, double Valor)
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


            return $"O Investimento foi feito com sussesso e já está rendendo {PorcentagemAoAno}$ ao ano.";
        }

    }
}
