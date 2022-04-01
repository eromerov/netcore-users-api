using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UsersApi.Contexts;
using UsersApi.Dto;
using UsersApi.Entities;

namespace UsersApi.Services
{
    public class UserService : IUserService
    {
        private readonly DbApiContext _db;
        private readonly IMapper _mapper;

        public UserService(DbApiContext db, IMapper mapper)
        {
            this._db = db;
            this._mapper = mapper;
        }


        public async Task<IList<UserDto>> GetAll()
        {
            var users = await _db.Users.ToListAsync();
            return this._mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto> GetById(string id)
        {
            
            var userId = Guid.Parse(id);
            var user = await _db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            if(null == user)
            {
                return new UserDto();
            }

            return this._mapper.Map<UserDto>(user);

        }

        public async Task<UserDto> Save(CreateUserDto dto)
        {
            var user = this._mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();

            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return this._mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Update(EditUserDto dto)
        {
            var user = await _db.Users.Where(x => x.Id == dto.Id).FirstOrDefaultAsync();

            if (user != null)
            {
                user.Name = dto.Name;
                user.Email = dto.Email;
                user.Password = dto.Password;
                user.IsAdmin = dto.IsAdmin;
                user.UpdatedAt = DateTime.Now;

                _db.Users.Update(user);
                await _db.SaveChangesAsync();
            }

            return this._mapper.Map<UserDto>(user);
        }


        public async Task<bool> Delete(string id)
        {
            var userId = Guid.Parse(id);
            var user = await _db.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

            if(user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
