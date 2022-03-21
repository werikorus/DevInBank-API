using SoftBank_console.src.Enums;
using SoftBank_console.src.Mocks;
using SoftBank_console.src.Services;
using System;

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
        public  TipoContaEnum  TipoConta { get; set; }
        public double Saldo { get; set; }

        public Contas(string nome, string cPF, string endereco, double rendaMensal, AgenciasEnum agencia, double saldo)
        {
            var random = new Random();
            var account = random.Next(1, 1000); //provisorio pois o sequencial deu problema


            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;          
            Agencia = agencia;
            Conta = Validates.GerarNovoNumeroConta(account).ToString();            
            Saldo = saldo;
        }

        public Contas()
        {
        }

        public void Saque(double valor)
        {
            Saldo -= valor;
            RegistrarTransacao();
        }

        public void Deposito(double valor)
        {
            Saldo += valor;
            RegistrarTransacao();
        }

        public double SaldoConta()
        {
            return Saldo;
        }

        public virtual string Extrato()
        {
            return "Extrato";
        }

        public void Transferencia(double valor, string contaID)
        {
            try
            {
                Contas contaDestino = ContasMock.GetConta(contaID);
                Saldo = -valor;

                if(contaDestino == null)
                {
                    throw new("Conta destino não encontrada!");
                }

                contaDestino.Deposito(valor);
            }
            catch
            {
                
            }
            
        }

        public void AlterarDadosCadastrais(int conta)
        {

        }

        public void RegistrarTransacao()
        {
            Transacoes<Contas> transacao = new(this);
            transacao.SaveTransaction();
        }
                    
        public string Cpf { get; set; }
        public string Operacao { get; set; }
        public double Valor { get; set; }
    }
}
