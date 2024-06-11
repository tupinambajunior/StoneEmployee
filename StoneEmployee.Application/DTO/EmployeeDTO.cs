using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.DTO
{
    public class EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Sector { get; set; }
        public decimal GrossSalary { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool HasHealthPlan { get; set; }
        public bool HasDentalPlan { get; set; }
        public bool HasTransportationVouchers { get; set; }
    }
}
