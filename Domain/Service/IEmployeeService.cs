using Domain.DataModel;

namespace Domain.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> List();
    }
}
