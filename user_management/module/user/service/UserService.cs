using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using user_management.common;
using user_management.context;
using user_management.module.user.model;
using System.Security.Cryptography;
using user_management.module.user.service;

namespace pharmacy_pos_system.module.role.service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository<User> _userRepository;
        public UserService(IUserRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateRoleAsync(CreateUserDto dto)
        {
           
            ArgumentNullException.ThrowIfNull(dto, $"the argument {nameof(dto)} is null");

            var existingRole = await _userRepository.GetAsync(u => u.Name.Equals(dto.Name));

            if (existingRole != null)
            {
                throw new Exception("The Role name already taken");
            }

            User role = _mapper.Map<User>(dto);


            role.IsDeleted = false;
          
            await _userRepository.CreateAsync(role);

            return true;
        }

        public async Task<List<User>> GetRoleAsync()
        {
            var role = await _userRepository.GetAllByFilterAsync(u => !u.IsDeleted);

            return _mapper.Map<List<User>>(role);
        }

        public async Task<UserDto> GetRoleByIdAsync(int id)
        {
            var role = await _userRepository.GetAsync(u => !u.IsDeleted && u.Id == id);

            return _mapper.Map<UserDto>(role);
        }

        public async Task<User> GetRoleByRolenameAsync(string rolename)
        {
            var user = await _userRepository.GetAsync(u => !u.IsDeleted && u.Name.Equals(rolename));

            // return _mapper.Map<RoleDto>(user);

            return user;
        }

        public async Task<bool> UpdateRoleAsync(UserDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto, nameof(dto));

            var existingUser = await _userRepository.GetAsync(u => !u.IsDeleted && u.Id == dto.Id, true);
            if (existingUser == null)
            {
                throw new Exception($"Role not found with the Id: {dto.Id}");
            }

            var roleToUpdate = _mapper.Map<User>(dto);
            roleToUpdate.UpdatedAt = DateTime.Now;
           

            await _userRepository.UpdateAsync(roleToUpdate);

            return true;
        }
        public async Task<bool> DeleteRole(int roleId)
        {
            if (roleId <= 0)
                throw new ArgumentException(nameof(roleId));

            var existingUser = await _userRepository.GetAsync(u => !u.IsDeleted && u.Id == roleId, true);
            if (existingUser == null)
            {
                throw new Exception($"User not found with the Id: {roleId}");
            }

            existingUser.IsDeleted = true;

            await _userRepository.UpdateAsync(existingUser);

            return true;
        }
       

    }
}
