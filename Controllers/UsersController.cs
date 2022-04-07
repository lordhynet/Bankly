using BANKLYFINANCIALAPP.Entities.Dto;
using BANKLYFINANCIALAPP.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BANKLYFINANCIALAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {

            _userService = userService;

        }

        [HttpGet("get-user/{userId}")]

        public async Task<IActionResult> GetUser(string userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("no available");
            }
            var user = await _userService.GetUser(userId);

            return Ok(user);

        }


        [HttpGet("get-all-account")]

        public async Task<IActionResult> GetUsers()
        {
            var user = await _userService.GetUsers();
            return Ok(user);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> AddUser(RegistrationDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid input");
            }
            var res = await _userService.AddUser(model);
            return Ok(res);

        }

        [HttpDelete("delete-account{UserId}")]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid resquest");

            }
            var res = await _userService.DeleteUser(UserId);
            return Ok(res);
        }

        [HttpPatch("update-account{UserId}")]

        public async Task<IActionResult> UpdateUser(string UserId, UpdateUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("invalid resquest");
            }
            var res = await _userService.UpdateUser(UserId, model);
            return Ok(res);
        }





    }
}
