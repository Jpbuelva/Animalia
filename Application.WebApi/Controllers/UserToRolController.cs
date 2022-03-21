using Domain.Service.Interfaces;
using Infraestructure.Entity.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserToRolController : ControllerBase
    {
        private readonly IUserToRolService _userToRolService;

        public UserToRolController(IUserToRolService userToRolService)
        {
            _userToRolService = userToRolService;
        }

        [HttpPost]
        public async Task<bool> Create(UserToRolRequest collection)
        {
            return await _userToRolService.Insert(collection);
        }
        [HttpPut]
        public async Task<bool> Update(UserUpdateRequest update)
        {
            return await _userToRolService.Update(update);
        }

    }
}
