using CommentManagement.Api.Contracts.Comments;
using CommentManagement.Api.Contracts.Results;
using CommentManagement.Application.Comments.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommentManagement.Api.Controllers
{
    /// <summary>
    /// comment's controller
    /// </summary>
    /// <param name="commentApplication"></param>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class CommentsController(ICommentApplication commentApplication) : ControllerBase
    {
        /// <summary>
        /// create comment
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<SuccessResultDto<CommentOutputDto>>(200)]
        [ProducesResponseType<FailureResultDto>(604)]
        public async Task<ActionResult<CommentOutputDto>> CreateAsync([FromBody] CreateCommentCommand command,
            CancellationToken cancellationToken = default)
        {
            var comment = await commentApplication
                .CreateAsync(command.UserId, command.Content);

            return Ok(comment);
        }

        /// <summary>
        /// get approved comments 
        /// </summary>
        /// <param name="pageIndex">default value is zero</param>
        /// <param name="pageSize">default value is 50</param>
        /// <param name="search">it's optional</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType<SuccessResultDto<CommentOutputDto>>(200)]
        public IActionResult GetApproved([FromQuery] ushort pageIndex = 0,
            [FromQuery] ushort pageSize = 50,
            [FromQuery] string? search = null)
        {
            var result = commentApplication
                .GetApprovedComments(pageIndex, pageSize, search);


            return Ok(new { result.totalRecords, result.records });
        }

        /// <summary>
        /// approve the comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/approve")]
        [ProducesResponseType<SuccessResultDto<CommentOutputDto>>(200)]
        [ProducesResponseType<FailureResultDto>(604)]
        public async Task<IActionResult> ApproveAsync([FromRoute] int id)
        {
            await commentApplication
                .ApproveAsync(id);

            return Ok();
        }

        /// <summary>
        /// remove the comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType<SuccessResultDto<CommentOutputDto>>(200)]
        [ProducesResponseType<FailureResultDto>(604)]
        public async Task<IActionResult> RemoveAsync([FromRoute] int id)
        {
            await commentApplication
                .RemoveAsync(id);

            return Ok();
        }
    }

}
