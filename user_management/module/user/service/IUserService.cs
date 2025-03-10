
using user_management.module.user.model;

namespace user_management.module.user.service
{
    public interface IUserService
    {
        Task<bool> CreateRoleAsync(CreateUserDto dto);
        Task<List<User>> GetRoleAsync();
        Task<UserDto> GetRoleByIdAsync(int id);
        Task<User> GetRoleByRolenameAsync(string username);
        Task<bool> UpdateRoleAsync(UserDto dto);
        Task<bool> DeleteRole(int roleId);
    }
}
