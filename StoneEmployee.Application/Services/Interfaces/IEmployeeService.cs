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
        public Task<EmployeeDTO> Create(EmployeeDTO dto);
        public Task<EmployeeDTO> Update(EmployeeDTO dto, string id);
        public Task<EmployeeDTO> GetByIdAsync(string id);
        public Task DeleteAsync(string id);
        public Task<List<EmployeeDTO>> GetListAsync();
    }
}
