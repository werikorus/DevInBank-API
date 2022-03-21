using System.Collections.Generic;
using System.Linq;
using SoftBank_console.src.Mocks;
using SoftBank_console.src.Entities;

namespace SoftBank_console.src.Services
{
    class Validates
    {
        public static bool ValidarCPF(string cpf)
        {
			int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digit;
			int sum;
			int rest;

			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)
				return false;

			tempCpf = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

			rest = sum % 11;
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			digit = rest.ToString();

			tempCpf += digit;

			sum = 0;
			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

			rest = sum % 11;
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			digit += rest.ToString();

			return cpf.EndsWith(digit);
        }

		public static int  GerarNovoNumeroConta(int ultimo)
        {
			List<Contas> contas = ContasMock.GetAllContas();
			var sequencial = contas.Max(x => int.Parse(x.Conta))+1;


			return ultimo+1; //provisorio pois o sequencial deu problema
		}

		public static string FiltrarCPF(string cpf)
        {
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");

			return cpf;
		}
    }
}
