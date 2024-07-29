using System;
using System.Linq;

namespace FI.WebAtividadeEntrevista.Helpers
{
    public class UtilsHelper
    {
        public bool ValidarCPF(string cpf)
        {
            try
            {
                cpf = new string(cpf.Where(char.IsDigit).ToArray());

                if (cpf.Length != 11)
                    return false;

                if (cpf.Distinct().Count() == 1)
                    return false;

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (cpf[i] - '0') * (10 - i);
                int primeiroDigitoVerificador = soma % 11;
                if (primeiroDigitoVerificador < 2)
                    primeiroDigitoVerificador = 0;
                else
                    primeiroDigitoVerificador = 11 - primeiroDigitoVerificador;

                if (cpf[9] - '0' != primeiroDigitoVerificador)
                    return false;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += (cpf[i] - '0') * (11 - i);
                int segundoDigitoVerificador = soma % 11;
                if (segundoDigitoVerificador < 2)
                    segundoDigitoVerificador = 0;
                else
                    segundoDigitoVerificador = 11 - segundoDigitoVerificador;

                if (cpf[10] - '0' != segundoDigitoVerificador)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string RemoverMascaraCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return cpf;
            }

            return cpf.Replace(".", "").Replace("-", "");
        }

        public string AdicionarMascaraCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf) || cpf.Length != 11)
            {
                throw new ArgumentException("O CPF deve conter exatamente 11 dígitos.");
            }

            return cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }
    }
}