using KUSYS.Application.Common.Dtos;
using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.CreateCourseMatch
{
    public class CreateCourseMatchCommand : IRequest<DataResponseDto<bool>>
    {
        public CreateUpdateCourseMatchModel CreateUpdateCourseMatchModel { get; set; }
    }
}
