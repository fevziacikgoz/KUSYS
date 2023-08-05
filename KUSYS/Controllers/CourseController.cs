using KUSYS.Application.CourseOp;
using KUSYS.Application.CourseOp.Command.CreateCourse;
using KUSYS.Application.CourseOp.Command.DeleteCourse;
using KUSYS.Application.CourseOp.Command.UpdateCourse;
using KUSYS.Application.CourseOp.Query.GetCourseByIdQueries;
using KUSYS.Application.CourseOp.Query.GetCourseQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace KUSYS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CourseResponse>))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCourseQuery()));
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCourseCommand createCourseCommand)
        {
            return Ok(await _mediator.Send(createCourseCommand));
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCourseCommand updateCourseCommand)
        {
            return Ok(await _mediator.Send(updateCourseCommand));
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteCourseCommand(id)));
        }

        [HttpGet("GetById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseResponse))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetCourseByIdQuery(id)));
        }
    }
}
