using Microsoft.EntityFrameworkCore;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Infrastructure.Database
{
    public class PgContext : DbContext
    {
        public PgContext(DbContextOptions<PgContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
