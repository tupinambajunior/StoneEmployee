using StoneEmployee.Core.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Entities
{
    public class PayslipItem : BaseEntity
    {
        public PayslipItemType Type { get; set; }
        public decimal Value { get; set; }
        public string Description { get; set; }
    }
}
