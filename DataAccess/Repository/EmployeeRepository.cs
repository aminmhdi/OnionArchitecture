using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataAccess.Repository;
using Domain.DataModel;
using Domain.Dto._Base;
using Domain.Dto.Employee;

namespace DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IBaseRepository<Employee> _repository;

        public EmployeeRepository(IBaseRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<PagedResultDto<Employee>> ListAsync(EmployeePagedQueryDto dto)
        {
            var sql = "SELECT * FROM portal_employees ";
            sql += GetListConditions(dto);
            return await _repository.GetPagedAsync(sql, dto, dto.PageSize, dto.PageIndex, dto.OrderField, null);
        }

        private string GetListConditions(EmployeePagedQueryDto dto)
        {
            var condition = "WHERE 1=1 AND ";
            if (!string.IsNullOrEmpty(dto.Name))
                condition += $"{nameof(Employee.Name)} LIKE '%{dto.Name}%' ";

            return condition;
        }
    }
}
