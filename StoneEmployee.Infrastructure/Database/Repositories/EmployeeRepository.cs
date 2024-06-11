using Microsoft.EntityFrameworkCore;
using StoneEmployee.Core.Entities;
using StoneEmployee.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Infrastructure.Database.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly PgContext _dbContext;
        public EmployeeRepository(PgContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetByDocument(string document, string id = null)
        {
            var employee = await _dbContext.Employee
                                            .Where(e => e.Document == document && 
                                                        e.Id != id)
                                            .FirstOrDefaultAsync();

            return employee;
        }
    }
}
