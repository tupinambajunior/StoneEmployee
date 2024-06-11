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
        public Task<string> Create(CreateEmployeeDTO dto);

        public Task<Employee> Get(string id);
    }
}
