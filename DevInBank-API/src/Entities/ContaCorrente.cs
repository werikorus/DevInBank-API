using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevInBank_API.src.Entities
{
    public class ContaCorrente : Contas
    {
        public override string Extrato()
        {
            return "Extrato Conta Corrente";
        }
    }
}
