using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minimalProject.Core.Domains.User;
using minimalProject.Models.User;
using minimalProject.Services;

namespace minimalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<User>> CreateUser([FromBody] AddUserInput userModel, CancellationToken cancellationToken)
        {
            return await userService.AddUser(addUserInput: userModel, cancellationToken: cancellationToken);


        }
    }
}
