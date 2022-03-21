using System;
using System.Linq;
using System.Collections.Generic;
using SoftBank_console.src.Entities;
using SoftBank_console.src.Enums;
using System.Runtime.InteropServices;
using SoftBank_console.src.Services;

namespace SoftBank_console.src.Mocks
{
    public static class ContasMock
    {
        public static List<Contas> GerarMockContas()
        {
            List<Contas> contas = new List<Contas>();

            //mudar isso aqui depois pra um arquivo json
            ContaPoupanca cp = new("Werik Filipe dos Santos Cunha", "022.381.581-03", "Florianóplis-SC", 4645.85, AgenciasEnum.Florianopolis, 4545.22);
            ContaCorrente cc = new("Ester Carvalho de Alencar", "021.313.123-01", "Florianóplis-SC", 4645.85, AgenciasEnum.Biguacu, -105.03);
            ContaInvestimento ci = new("Fabricio Magalhães da Silva", "022.313.323-04", "Palmas-TO", 4645.85, AgenciasEnum.Biguacu, 6578.56, TipoInvestimentoEnum.LCI);

            contas.Add(cp);
            contas.Add(cc);
            contas.Add(ci);

            return contas;
        }

        public static List<Contas> GetAllContas()
        {
            List<Contas> contas = new List<Contas>();
            contas.AddRange(GerarMockContas());
            return contas;
        }

        public static Contas GetConta(string contaID, [Optional] string cpf)
        {
            List<Contas> contas = GetAllContas();
            Contas contaEncontrada = cpf != null ?
                contas.Find(x => (x.Conta) == (contaID)) :
                contas.Find(x => (x.Conta == contaID) && (Validates.FiltrarCPF(x.CPF) == Validates.FiltrarCPF(cpf)));

            return contaEncontrada;
        }

        public static ContaPoupanca GetContaPoupanca(string contaID, string cpf)
        {
            List<Contas> contas = GetAllContas();
            ContaPoupanca contaEncontrada = (ContaPoupanca)contas.Find(x => (x.Conta == contaID) && (Validates.FiltrarCPF(x.CPF) == Validates.FiltrarCPF(cpf)));

            return contaEncontrada;
        }

        public static ContaInvestimento GetContaInvestimento(string contaID)
        {
            List<Contas> contas = GetAllContas();
            ContaInvestimento contaEncontrada = (ContaInvestimento)contas.Where(x => x.Conta == contaID);
            return contaEncontrada;
        }

        public static List<Contas> AddConta(Contas conta)
        {
            List<Contas> contas = new List<Contas> { conta };
            return contas;
        }
    }
}
