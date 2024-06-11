using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Validator
{
    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            var invalidCpfs = new[]
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };

            if (invalidCpfs.Contains(cpf))
                return false;

            var cpfArray = cpf.Select(c => int.Parse(c.ToString())).ToArray();
            for (int j = 0; j < 2; j++)
            {
                int sum = 0;
                for (int i = 0; i < 9 + j; i++)
                {
                    sum += cpfArray[i] * (10 + j - i);
                }
                int remainder = sum % 11;
                if (remainder < 2)
                {
                    if (cpfArray[9 + j] != 0)
                        return false;
                }
                else
                {
                    if (cpfArray[9 + j] != 11 - remainder)
                        return false;
                }
            }

            return true;
        }
    }
}