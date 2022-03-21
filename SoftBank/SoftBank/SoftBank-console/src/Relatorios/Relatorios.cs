using System.Collections.Generic;
using System.Linq;
using SoftBank_console.src.Mocks;


namespace SoftBank_console.src.Entities
{
    public static class Relatorios
    {
        public static string RelatorioContas()
        {
            List<Contas> contas = ContasMock.GetAllContas();

            string relatorio = ":::::::: LISTAGEM DE CONTAS :::::::: \n ***********************************\n";

            foreach (Contas conta in contas)
            {
                relatorio += $"Nome: {conta.Nome}\n" +
                             $"CPF: {conta.CPF}\n" +
                             $"Conta: {conta.Conta}\n" +
                             $"Agência: {conta.Agencia}\n" +
                             $"Tipo conta: {conta.TipoConta}\n" +
                             $"************************************\n";
            };

            return relatorio;
        }

        public static string RelatorioContasSaldoNegativo()
        {
            List<Contas> contas = ContasMock.GetAllContas();

            List<Contas> consulta = new();

            foreach (Contas conta in contas)
            {
                if (conta.Saldo < 0)
                    consulta.Add(conta);
            }
                        

            string relatorio = " :::::::: LISTAGEM DE CONTAS COM SALDO NEGATIVO :::::::: \n *********************************** \n";

            foreach (Contas conta in consulta)
            {
                relatorio += $"Nome: {conta.Nome}\n" +
                             $"CPF: {conta.CPF}\n" +
                             $"Conta: {conta.Conta}\n" +
                             $"Agência: {conta.Agencia}\n" +
                             $"Tipo conta: {conta.TipoConta}\n" +
                             $"Saldo: {conta.Saldo}\n" +
                             $"***********************************";
            };

            return relatorio;
        }



        public static string RelatorioTransacoesCliente(int contaID)
        {
            List<Contas> contas = ContasMock.GetAllContas();

            Contas consulta = new();

            consulta = (Contas)contas.Where(x => x.Conta == contaID.ToString());

            string relatorio = $" :::::::: TODAS AS TRANSAÇÕES de {consulta.Nome} :::::::: \n *********************************** \n";


            return relatorio;
        }

    }
}