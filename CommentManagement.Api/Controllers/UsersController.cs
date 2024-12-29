using CommentManagement.Api.Contracts.Results;
using CommentManagement.Api.Contracts.Users;
using CommentManagement.Application.Comments.Contracts;
using CommentManagement.Application.Users.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagement.Api.Controllers
{
    /// <summary>
    /// user's controller
    /// </summary>
    /// <param name="userApplication"></param>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class UsersController(IUserApplication userApplication) : ControllerBase
    {
        /// <summary>
        /// create a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<SuccessResultDto<UserOutputDto>>(200)]
        [ProducesResponseType<FailureResultDto>(604)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command)
        {
            var user = await userApplication.CreateAsync(command.Email);

            return Ok(user);
        }

        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType<SuccessResultDto<UserOutputDto>>(200)]
        [ProducesResponseType<FailureResultDto>(604)]
        public async Task<ActionResult<UserOutputDto>> GetById([FromRoute] int id)
        {
            var user = await userApplication.FindByIdAsync(id);

            return Ok(user);
        }
    }
}
