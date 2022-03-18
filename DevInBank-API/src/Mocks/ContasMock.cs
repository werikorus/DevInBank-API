using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInBank_API.src.Entities;
using DevInBank_API.src.Enums;

namespace DevInBank_API.src.Mocks
{
    public static class ContasMock
    {
        public static List<Contas> GetAllContas() 
        {
            List<Contas> contas = new List<Contas>();

            ContaPoupanca cp = new("Werik Filipe dos Santos Cunha", "022.381.581-03", "Florianóplis-SC", 4645.85, AgenciasEnum.Florianopolis, 4545.22);
            ContaCorrente cc = new("Ester Carvalho de Alencar", "021.313.123-01", "Florianóplis-SC", 4645.85, AgenciasEnum.Biguacu, 6578.56);
            ContaInvestimento ci = new("Fabricio Magalhães da Silva", "022.313.323-04", "Palmas-TO", 4645.85, AgenciasEnum.Biguacu, 6578.56, TipoInvestimentoEnum.LCI);

            contas.Add(cp);
            contas.Add(cc);
            contas.Add(ci);
            
            return contas;
        }

    }
}
