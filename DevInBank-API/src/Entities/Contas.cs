using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevInBank_API.src.Enums;


namespace DevInBank_API.src.Entities
{
    public class Contas
    {
        public string Nome { get; set; }
        public string CPF { get; set; }

        public string Endereco { get; set; }
        public double RendaMensal { get; set; }

        public int Conta { get; set; }
        public AgenciasEnum Agencia { get; set; }

        public Contas(string nome, string cPF, string endereco, double rendaMensal, int conta, AgenciasEnum agencia)
        {
            Nome = nome;
            CPF = cPF;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Conta = conta;
            Agencia = agencia;
        }

         public Contas()
        {

        }
    }
}
