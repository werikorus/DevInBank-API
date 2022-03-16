using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInBank_API.src.Entities
{
    public class ContaPoupanca : Contas
    {
        public override string Extrato()
        {
            return "Extrato Conta Poupança";
        }

        public string SimularRentabilidade(int TempoEmMeses, double ValorMensal)
        {
            return ""; 
        }
    }
}
