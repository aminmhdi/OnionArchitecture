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

        #region Create

        public async Task<int> CreateAsync(EmployeeDto dto)
        {
            return await _employeeRepository.CreateAsync(dto.ToDataModel());
        }

        #endregion

        #region Edit

        public async Task<int> EditAsync(EmployeeDto dto)
        {
            if (await GetAsync(dto.Id) != null)
                return await _employeeRepository.EditAsync(dto.ToDataModel());

            return 0;
        }

        #endregion

        #region Get

        public async Task<EmployeeDto> GetAsync(int id)
        {
            return (await _employeeRepository.GetAsync(id)).ToDto();
        }

        #endregion

        #region Delete

        public async Task<int> DeleteAsync(int id)
        {
            if (await GetAsync(id) != null)
                return await _employeeRepository.DeleteAsync(id);

            return 0;
        }

        #endregion
    }
}
                