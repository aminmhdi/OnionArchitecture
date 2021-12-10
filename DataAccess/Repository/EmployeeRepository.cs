using Dapper.FastCrud;
using DataAccess.Configuration.Register;
using Domain.DataAccess.Repository;
using Domain.DataModel;
using Domain.Dto._Base;
using Domain.Dto.Employee;

namespace DataAccess.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Constructor

        private readonly IBaseRepository<Employee> _repository;

        public EmployeeRepository
        (
            IBaseRepository<Employee> repository
        )
        {
            _repository = repository;
        }

        #endregion

        #region List

        public async Task<PagedResultDto<Employee>> ListAsync(EmployeePagedQueryDto dto)
        {
            var sql = $"SELECT * FROM {Sql.Table<Employee>().ToTableName()} ";
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

        #endregion

    }
}
