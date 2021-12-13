using Domain.DataAccess.Repository;
using Domain.Dto.Permission;
using Domain.Mapping;
using Domain.Service;

namespace Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService
        (
            IPermissionRepository permissionRepository
        )
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<IEnumerable<PermissionDto>> ListAsync()
        {
            return (await _permissionRepository.ListAsync()).ToDtoList();
        }
    }
}
