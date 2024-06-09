using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Models
{
    public class INSSTaxRate
    {
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal Rate { get; set; }
    }
}
