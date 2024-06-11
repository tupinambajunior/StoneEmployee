using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Infrastructure.Database.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
               .ToTable("employee");

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasMaxLength(100);

            builder
                .Property(x => x.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(255);

            builder
                .Property(x => x.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(255);

            builder
                .Property(x => x.Document)
                .HasColumnName("document")
                .HasMaxLength(11);

            builder
                .HasIndex(x => x.Document)
                .IsUnique();

            builder
                .Property(x => x.Sector)
                .HasColumnName("sector")
                .HasMaxLength(255);

            builder
                .Property(x => x.GrossSalary)
                .HasColumnName("gross_salary");

            builder
                .Property(x => x.AdmissionDate)
                .HasColumnName("admission_data");

            builder
                .Property(x => x.HasHealthPlan)
                .HasColumnName("has_health_plan");

            builder
                .Property(x => x.HasDentalPlan)
                .HasColumnName("has_dental_plan");

            builder
                .Property(x => x.HasTransportationVouchers)
                .HasColumnName("has_transportation_vouchers");
        }
    }
}
