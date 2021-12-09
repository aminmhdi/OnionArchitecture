using Domain.DataAccess.Repository;
using Domain.DataModel;
using Domain.Mapping;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseRepository<Employee> _repository;

        public EmployeeService
        (
            IBaseRepository<Employee> repository
        )
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeDto>> List()
        {
            var query = "Select * From PORTAL_EMPLOYEES";
            var result = await _repository.QueryAsync(query);
            var model = result.ToDtoList();
            return model;
        }
    }
}
