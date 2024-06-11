using StoneEmployee.Core.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.ValueObjects
{
    public class CPF
    {
        public string Value { get; private set; }

        public CPF(string value)
        {
            if (!IsValid(value))
                throw new ArgumentException("Invalid CPF");

            Value = value;
        }

        private bool IsValid(string cpf)
        {
            return CpfValidator.IsValid(cpf);
        }
    }
}
