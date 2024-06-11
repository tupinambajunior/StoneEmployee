using StoneEmployee.Application.DTO;
using StoneEmployee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneEmployee.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<Employee> Create(EmployeeDTO dto);
        public Task<Employee> Update(EmployeeDTO dto, string id);
        public Task<EmployeeDTO> GetByIdAsync(string id);
    }
}
