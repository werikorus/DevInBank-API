using System;
using SoftBank_console.src.Entities;
using SoftBank_console.src.Enums;

namespace SoftBank_console
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("**************************** ---------- Bem vindo ! ---------- *********************************");
            Console.WriteLine("O que deseja fazer?");

            Console.WriteLine(" 1 - Criar conta\n" +
                              " 2 - Depositar\n" +
                              " 3 - Sacar\n" +
                              " 4 - Simular investimento em Conta Poupança\n" +
                              " 5 - Simular investimento em Conta de Investimento\n" +
                              " 6 - Listar todas as contas\n" +
                              " 7 - Listar contas com Saldo Negativo\n");

            int menu = int.Parse(Console.ReadLine());

            switch (menu) {
                case 1:
                    {
                        Console.Write("Muito bem! Para criação da sua conta, precisaremos das seguintes informações:");

                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();

                        Console.Write("CPF: ");
                        string cpf = Console.ReadLine();

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
                                        ContaPoupanca conta = new(nome, cpf, endereco, rendaMensal, AgenciasEnum.Florianopolis, 0);
                                        
                                    }
                                    break;


                                case 2:
                                    {
                                        ContaCorrente conta = new(nome, cpf, endereco, rendaMensal, AgenciasEnum.Florianopolis, 0);

                                    }
                                    break;

                                case 3:
                                    {
                                        ContaInvestimento conta = new();

                                    }
                                    break;


                            }

                            Console.WriteLine("Conta criada com sucesso!");
                        }
                        catch
                        {
                            Console.WriteLine("Ocorreu algum erro ao criar a conta");
                        }

                    }
                    break;
                                      
            }
        }
    }
}
