using Domain.DataModel;
using Domain.Dto._Base;
using Domain.Dto.Employee;

namespace Domain.Service
{
    public interface IEmployeeService
    {
        Task<PagedResultDto<EmployeeDto>> ListAsync(EmployeePagedQueryDto dto);
    }
}
