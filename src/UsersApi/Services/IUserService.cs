using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsersApi.Dto;

namespace UsersApi.Services
{
    public interface IUserService
    {
        Task<UserDto> Save(CreateUserDto dto);
        Task<IList<UserDto>> GetAll();
        Task<UserDto> GetById(string id);
        Task<UserDto> Update(EditUserDto dto);
        Task<bool> Delete(string id);
    }
}
