using KUSYS.Application.StudentsOp;
using KUSYS.Application.StudentsOp.Command.CreateStudent;
using KUSYS.Application.StudentsOp.Command.DeleteStudent;
using KUSYS.Application.StudentsOp.Command.UpdateStudent;
using KUSYS.Application.StudentsOp.Query.GetStudentByIdQueries;
using KUSYS.Application.StudentsOp.Query.GetStudentsQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace KUSYS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<StudentsResponse>))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetStudentsQuery()));
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateStudentCommand createStudentCommand)
        {
            return Ok(await _mediator.Send(createStudentCommand));
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateStudentCommand updateStudentCommand)
        {
            return Ok(await _mediator.Send(updateStudentCommand));
        }

        [HttpDelete("{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand(id)));
        }

        [HttpGet("GetById/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentsResponse))]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery(id)));
        }
    }
}
