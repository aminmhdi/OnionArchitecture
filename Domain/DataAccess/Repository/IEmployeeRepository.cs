using Domain.Dto._Base;
using Domain.Dto.Employee;

namespace Domain.DataAccess.Repository
{
    public interface IEmployeeRepository
    {
        Task<PagedResultDto<DataModel.Employee>> ListAsync(EmployeePagedQueryDto dto);
    }
}
