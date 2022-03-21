using System;
using System.Collections.Generic;
using System.Globalization;
using SoftBank_console.src.Entities;
using SoftBank_console.src.Enums;
using SoftBank_console.src.Mocks;
using SoftBank_console.src.Services;




namespace SoftBank_console
{
    class Program
    {
        static void Main()
        {
            ContasMock.GerarMockContas();

            Console.WriteLine("**************************** ---------- Bem vindo ! ---------- *********************************");
            Console.WriteLine("O que deseja fazer?");

            Console.WriteLine(" 1 - Criar conta\n" +
                              " 2 - Depositar\n" +
                              " 3 - Sacar\n" +
                              " 4 - Transferir\n" +
                              " 5 - Simular investimento em Conta Poupança\n" +
                              " 6 - Simular investimento em Conta de Investimento\n" +
                              " 7 - Listar todas as contas\n" +
                              " 8 - Listar contas com Saldo Negativo\n" +
                              " 9 - Extrato de Conta\n" +
                              " 10 - Consultar Saldo\n" +
                              " 11 - SAIR");

            int menu = int.Parse(Console.ReadLine());

            //  while (menu != 9)
            //   {

            switch (menu)
            {
                case 1:
                    {
                        Console.WriteLine("Muito bem! Para criação da sua conta, precisaremos das seguintes informações:");

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("CPF (000.000.000-00): ");
                        string cpf = Console.ReadLine();

                        bool cpfValido = Validates.ValidarCPF(cpf);

                        while (!cpfValido)
                        {
                            Console.WriteLine("Infome um CPF válido!");
                            cpf = Console.ReadLine();
                            cpfValido = Validates.ValidarCPF(cpf);
                        }

                        Console.Write("Endereço: ");
                        string endereco = Console.ReadLine();

                        Console.Write("Renda Mensal: ");
                        double rendaMensal = double.Parse(Console.ReadLine());

                        Console.Write("Escolha uma agência: ( 1.Florianópolis, 2.São-José, 3.Biguaçu)");
                        int agencia = int.Parse(Console.ReadLine());

                        Console.Write("Tipo de conta: (1.Poupança, 2.Corrente, 3.Investimento)");
                        int tipoConta = int.Parse(Console.ReadLine());

                        try
                        {
                            switch (tipoConta)
                            {
                                case 1:
                                    {
                                        try
                                        {
                                            ContaPoupanca conta = new(nome, cpf, endereco, rendaMensal, (AgenciasEnum)agencia, 0);
                                            ContasMock.AddConta(conta);

                                            Console.WriteLine($"Conta Poupança criada com sucesso para {nome}");
                                        }
                                        catch (ApplicationException e)
                                        {
                                            throw new($"Erro ao criar conta poupança! {e.Message}");
                                        }
                                    }
                                    break;

                                case 2:
                                    {
                                        try
                                        {
                                            ContaCorrente conta = new(nome, cpf, endereco, rendaMensal, AgenciasEnum.Florianopolis, 0);
                                        }
                                        catch (ApplicationException e)
                                        {
                                            throw new($"Erro ao criar conta corrente! {e.Message}");
                                        }
                                    }
                                    break;

                                case 3:
                                    {
                                        try
                                        {
                                            Console.WriteLine("Informe o tipo de investimento:\n+" +
                                                              "LCI 8% ao ano. Tempo mínimo de aplicação: 6 meses\n+" +
                                                              "LCA 9% ao ano. Tempo mínimo de aplicação: 12 meses" +
                                                              "LCI 10% ao ano. Tempo mínimo de aplicação: 36 meses");

                                            ContaInvestimento conta = new(nome, cpf, endereco, rendaMensal, AgenciasEnum.Florianopolis, 0, TipoInvestimentoEnum.LCI);

                                        }
                                        catch (ApplicationException e)
                                        {
                                            throw new($"Erro ao criar conta investimento {e.Message}");
                                        }

                                    }
                                    break;
                            }

                            Console.WriteLine("Conta criada com sucesso!");
                        }
                        catch (ApplicationException e)
                        {
                            Console.WriteLine($"Erro: {e.Message}");
                        }

                    }
                    break;

                case 2:
                    {
                        Console.Write("Informe a conta para depósito: ");
                        string conta = Console.ReadLine();


                        Contas contaParaDeposito = ContasMock.GetConta(conta);

                        if (contaParaDeposito == null)
                            Console.WriteLine("Conta não encontrada!");
                        else
                        {
                            Console.Write("Informe o valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            if (valor >= 0)
                            {
                                contaParaDeposito.Deposito(valor);
                                Console.WriteLine($"Deposito feito de R${valor:0.00} com sucesso para conta: {contaParaDeposito.Conta} de {contaParaDeposito.Nome}");
                            }
                            else
                                throw new("Valor para depósito inválido!");
                        }
                    }
                    break;

                case 3:
                    {
                        Console.Write("Informe a sua conta para saque: ");
                        string conta = Console.ReadLine();

                        Console.Write("Informe o CPF: ");
                        string CPF = Console.ReadLine();

                        Contas contaParaSaque = ContasMock.GetConta(conta, CPF);

                        if (contaParaSaque == null)
                            Console.WriteLine("Conta não encontrada!");
                        else
                        {
                            Console.Write("Informe o valor: ");
                            double valor = double.Parse(Console.ReadLine());

                            if (valor >= 0)
                            {
                                Console.WriteLine($"Saldo anterior: {contaParaSaque.Saldo}");
                                contaParaSaque.Saque(valor);
                                Console.WriteLine($"Saque feito de R${valor} com sucesso da conta: {contaParaSaque.Conta} de {contaParaSaque.Nome}");
                                Console.WriteLine($"Novo Saldo: {contaParaSaque.Saldo:0.00}");
                            }
                            else
                                throw new("Valor para saque inválido!");
                        }
                        break;
                    }

                case 4:
                    {
                        try
                        {
                            Console.Write("Informe sua conta: ");
                            string numeroContaOrigem = Console.ReadLine();

                            Console.Write("Informe o CPF: ");
                            string CPF = Console.ReadLine();

                            Console.Write("Informe a conta para transferência: ");
                            string contaDestino = Console.ReadLine();

                            Contas contaOrigem = ContasMock.GetConta(numeroContaOrigem, CPF);

                            if (contaOrigem != null)
                                Console.WriteLine("Conta origem não encontrada!");
                            else
                            {
                                Console.Write("Informe o valor: ");
                                double valor = double.Parse(Console.ReadLine());

                                if (valor >= 0)
                                {
                                    contaOrigem.Transferencia(valor, contaDestino);
                                    Console.WriteLine($"Transferência feita com sucesso para conta {contaDestino}");
                                }
                                else
                                    throw new("Valor para transferência inválido!");
                            }

                        }
                        catch (ApplicationException e)
                        {
                            throw new($"Erro ao realizar saque: {e.Message}");
                        }

                    }
                    break;

                case 5:
                    {
                        try
                        {
                            Console.Write("Informe sua conta: ");
                            string conta = Console.ReadLine();

                            Console.Write("Informe o CPF: ");
                            string CPF = Console.ReadLine();

                            ContaPoupanca contaPoupancaParaSimulacao = ContasMock.GetContaPoupanca(conta, CPF);

                            if (contaPoupancaParaSimulacao == null)
                                throw new("Conta não encontrada!");
                            else
                            {
                                Console.Write("Informe o tempo em meses: ");
                                int meses = int.Parse(Console.ReadLine());
                                Console.Write("Informe o valor mensal para rendimento: ");
                                double valor = double.Parse(Console.ReadLine());
                                string result = contaPoupancaParaSimulacao.SimularRentabilidade(meses, valor);
                                Console.WriteLine(result);
                            }

                        }
                        catch (ApplicationException e)
                        {
                            throw new($"Erro ao simular rendimento em conta poupança: {e.Message}");
                        }
                    }
                    break;

                case 6:
                    {
                        try
                        {
                            Console.Write("Informe sua conta: ");
                            string conta = Console.ReadLine();

                            ContaInvestimento contaInvestimentoParaSimulacao = ContasMock.GetContaInvestimento(conta);

                            if (contaInvestimentoParaSimulacao == null)
                                throw new("Conta não encontrada!");
                            else
                            {
                                Console.Write("Informe o tempo em meses: ");
                                int meses = int.Parse(Console.ReadLine());

                                Console.Write("Informe o valor mensal para rendimento: ");
                                double valor = double.Parse(Console.ReadLine());

                                Console.Write("Informe o tipo de investimento (1.LC1, 2.LCA, 3.CDB): ");
                                int tipoInvestimento = int.Parse(Console.ReadLine());

                                string result = contaInvestimentoParaSimulacao.SimularInvestimento((TipoInvestimentoEnum)tipoInvestimento, meses, valor);

                                Console.WriteLine(result);

                                Console.WriteLine("Deseja aplicar? (True - False)");
                                bool aplicar = bool.Parse(Console.ReadLine());


                                if (aplicar)
                                    contaInvestimentoParaSimulacao.AplicarInvestimento((TipoInvestimentoEnum)tipoInvestimento, meses, valor);
                            }

                        }
                        catch (ApplicationException e)
                        {
                            throw new($"Erro ao simular rendimento em conta investimento: {e.Message}");
                        }
                    }
                    break;

                case 7:
                    {
                        string relatorioContas = Relatorios.RelatorioContas();
                        Console.WriteLine(relatorioContas);
                    }
                    break;

                case 8:
                    {
                        string relatorioSaldoNegativo = Relatorios.RelatorioContasSaldoNegativo();
                        Console.WriteLine(relatorioSaldoNegativo);
                    }
                    break;
                case 9:
                    {
                        Console.Write("Informe a conta para o Extrato: ");
                        string conta = Console.ReadLine();

                        Console.Write("Informe o CPF: ");
                        string CPF = Console.ReadLine();

                        Contas contaParaExtrato = ContasMock.GetConta(conta, CPF);

                        if (contaParaExtrato == null)
                            Console.WriteLine("Conta não encontrada!");
                        else
                        {
                            string extrato = contaParaExtrato.Extrato();
                            Console.WriteLine(extrato);
                        }
                    }
                    break;

                case 10:
                    {
                        Console.Write("Informe a conta: ");
                        string conta = Console.ReadLine();

                        Console.Write("Informe o CPF: ");
                        string CPF = Console.ReadLine();

                        Contas contaEncontrada = ContasMock.GetConta(conta, CPF);

                        if (contaEncontrada == null)
                            Console.WriteLine("Conta não encontrada!");
                        else
                            Console.WriteLine($"Saldo atual da conta: R${contaEncontrada.SaldoConta()}");
                    }
                    break;
            }
        }
        //}
    }
}
