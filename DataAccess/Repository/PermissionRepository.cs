using Domain.DataAccess.Repository;
using Domain.DataModel;

namespace DataAccess.Repository
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IBaseRepository<Permission> _repository;

        public PermissionRepository(IBaseRepository<Permission> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Permission>> ListAsync()
        {
            var sql = "SELECT * FROM portal_permissions ";
            return await _repository.QueryAsync(sql);
        }

        public async Task<IEnumerable<Permission>> ListByUserIdAsync(int id)
        {
            var sql = @"
                SELECT p.* FROM portal_permissions p 
                JOIN portal_user_permissions up ON p.id = up.permissionId
                WHERE up.userId = :id
                ";
            return await _repository.QueryAsync(sql, new {id});
        }
    }
}
