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
        #region Constructor

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService
        (
            IEmployeeRepository employeeRepository
        )
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region List

        public async Task<PagedResultDto<EmployeeDto>> ListAsync(EmployeePagedQueryDto dto)
        {
            return (await _employeeRepository.ListAsync(dto)).ToPagedResultDto();
        }

        #endregion
    }
}
