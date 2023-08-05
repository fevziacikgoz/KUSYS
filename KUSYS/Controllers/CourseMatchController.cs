using Azure.Messaging;
using KUSYS.Application.Common.Dtos;
using KUSYS.Application.Common.Messages;
using KUSYS.Application.CourseMatchOp;
using KUSYS.Application.CourseMatchOp.Command.CreateCourseMatch;
using KUSYS.Application.CourseMatchOp.Command.DeleteCourseMatch;
using KUSYS.Application.CourseMatchOp.Command.UpdateCourseMatch;
using KUSYS.Application.CourseMatchOp.Query.GetCourseMatchByStudentIdQueries;
using KUSYS.Application.CourseMatchOp.Query.GetCourseMatchQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Security.Claims;

namespace KUSYS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CourseMatchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private ClaimsIdentity claims;
        public CourseMatchController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CourseMatchResponse>))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCourseMatchQuery()));
        }


        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DataResponseDto<bool>))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Create(CreateCourseMatchCommand createCourseMatchCommand)
        {
            claims = HttpContext.User.Identity as ClaimsIdentity;
            if (claims.FindFirst(ClaimTypes.Role).Value != "Admin")
            {
                var studentId = claims.FindFirst(ClaimTypes.Sid).Value;
                if (!string.IsNullOrEmpty(studentId))
                {
                    createCourseMatchCommand.CreateUpdateCourseMatchModel.StudentId = int.Parse(studentId);
                }
                else
                {
                    return BadRequest(new DataResponseDto<bool>()
                    {
                        Data = false,
                        Successful = false,
                        Message = MessagesConstant.StudentCourseDenied
                    });
                }
            }

            return Ok(await _mediator.Send(createCourseMatchCommand));
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCourseMatchCommand updateCourseMatchCommand)
        {
            return Ok(await _mediator.Send(updateCourseMatchCommand));
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteCourseMatchCommand(id)));
        }

        [HttpGet("GetByStudentId/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseMatchResponse))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetCourseMatchByStudentIdQuery(id)));
        }
    }
}
