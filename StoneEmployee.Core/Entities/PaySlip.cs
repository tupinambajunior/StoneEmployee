using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Entities
{
    public class PaySlip : BaseEntity
    {
        public DateTime ReferenceMonth { get; set; }
        public List<PayslipItem> PayslipItems { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetSalary { get; set; }
    }
}
