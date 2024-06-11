using StoneEmployee.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public CPF Document { get; private set; }
        public string Sector { get; private set; }
        public decimal GrossSalary { get; private set; }
        public DateTime AdmissionDate { get; private set; }
        public bool HasHealthPlan { get; private set; }
        public bool HasDentalPlan { get; private set; }
        public bool HasTransportationVouchers { get; private set; }

        public Employee()
        {
        }

        public Employee(string id, string firstName, string lastName, string document, string sector, decimal grossSalary,
                        DateTime admissionDate, bool hasHealthPlan, bool hasDentalPlan, bool hasTransportationVouchers)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Document = new CPF(document);
            this.Sector = sector;
            this.GrossSalary = grossSalary;
            this.AdmissionDate = admissionDate;
            this.HasHealthPlan = hasHealthPlan;
            this.HasDentalPlan = hasDentalPlan;
            this.HasTransportationVouchers = hasTransportationVouchers;
        }
    }
}
