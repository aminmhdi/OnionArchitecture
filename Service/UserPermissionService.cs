using DataAccess.Repository;
using Domain.DataAccess.Repository;
using Domain.Dto.Permission;
using Domain.Dto.UserPermission;
using Domain.Mapping;
using Domain.Service;

namespace Service
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IUserPermissionRepository _userPermissionRepository;

        public UserPermissionService
        (
            IUserRepository userRepository,
            IPermissionRepository permissionRepository,
            IUserPermissionRepository userPermissionRepository)
        {

            _userRepository = userRepository;
            _permissionRepository = permissionRepository;
            _userPermissionRepository = userPermissionRepository;
        }


        public async Task<IEnumerable<PermissionDto>> ListAsync(int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            var permissions = await _permissionRepository.ListByUserIdAsync(user.Id);
            return permissions.ToDtoList();
        }

        public async Task UpdateUserPermissionsAsync(UpdateUserPermissionsDto updateUserPermissionsDto)
        {
            var user = await _userRepository.GetAsync(updateUserPermissionsDto.Id);
            if (user == null)
            {
                throw new InvalidParameterException(nameof(updateUserPermissionsDto.Id));
            }
            var currentPermissionIds = (await _permissionRepository.ListByUserIdAsync(user.Id)).Select(p => p.Id);
            var toDeletePermission = currentPermissionIds.Except(updateUserPermissionsDto.PermissionIds);
            if(toDeletePermission.Any())
            {
                await _userPermissionRepository.DeletePermissionsForUserAsync(user.Id, toDeletePermission);
            }

            var toInsertPermissions = updateUserPermissionsDto.PermissionIds.Except(currentPermissionIds);
            if (toInsertPermissions.Any())
                await _userPermissionRepository.CreatePermissionsForUserAsync(user.Id, toInsertPermissions);
        }
    }
}
