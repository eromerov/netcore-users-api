using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Dto;
using UsersApi.Services;

namespace UsersApi.Controllers.v1
{    
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v1/users/")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var user = await this._userService.GetById(id);
            return Ok(user);
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var users = await this._userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUserDto dto)
        {
            var user = await this._userService.Save(dto);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Put(EditUserDto dto)
        {
            var user = await this._userService.Update(dto);
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var ok = await this._userService.Delete(id);

            if(!ok)
            {
                return BadRequest("Ha ocurrido un error, por favor inténtelo de nuevo más tarde");
            }

            return Ok("Usuario eliminado correctamente");
        }


    }
}
