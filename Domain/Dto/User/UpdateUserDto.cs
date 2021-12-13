using Domain.Dto.Permission;

namespace Domain.Dto.User
{
    public class UpdateUserDto
    {
        public string Username { get; set; }
        public IEnumerable<PermissionDto> Permissions { get; set; }
    }
}
