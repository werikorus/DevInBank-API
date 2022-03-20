using System;
using SoftBank_console.src.Enums;


namespace SoftBank_console.src.Entities
{
    public class Contas
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public double RendaMensal { get; set; }
        public string Conta { get; private set; }
        public AgenciasEnum Agencia { get; set; }
        public  TipoContaEnum  TipoConta { get; private set; }
        public double Saldo { get; set; }

        public Contas(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
        {
            var random = new Random();
            var account = random.Next(1, 1000);

            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;          
            Agencia = agencia;
            Conta = $"{account}-00{agencia}";
            Saldo = saldo;
        }

        public Contas()
        {

        }

        public void Saque(double valor)
        {
            Saldo =- valor;
        }

        public void Deposito(double valor)
        {
            Saldo =+ valor;
        }

        public double SaldoConta()
        {
            return 0;
        }

        public virtual string Extrato()
        {
            return "Extrato";
        }


        public void Transferencia(int conta, double valor)
        {
            Saldo =-valor;
        }

        public void AlterarDadosCadastrais()
        {

        }
    }
}
