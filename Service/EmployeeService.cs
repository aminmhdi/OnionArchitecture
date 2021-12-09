using Domain.DataAccess.Repository;
using Domain.DataModel;
using Domain.Dto._Base;
using Domain.Dto.Employee;
using Domain.Mapping;
using Domain.Service;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService
        (
            IEmployeeRepository employeeRepository
        )
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<PagedResultDto<EmployeeDto>> ListAsync(EmployeePagedQueryDto dto)
        {
            return (await _employeeRepository.ListAsync(dto)).ToPagedResultDto();
        }
    }
}
