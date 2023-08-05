using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseMatchOp.Command.DeleteCourseMatch;
using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.Handle.UpdateCourseMatchHandle
{
    public class DeleteCourseMatchHandle : IRequestHandler<DeleteCourseMatchCommand, bool>
    {
        private readonly ICourseMatchRepository _courseMatchRepository;
        public DeleteCourseMatchHandle(ICourseMatchRepository courseMatchRepository)
        {
            _courseMatchRepository = courseMatchRepository;
        }

        public async Task<bool> Handle(DeleteCourseMatchCommand request, CancellationToken cancellationToken)
        {
            return await _courseMatchRepository.DeleteAsync(request.id);
        }
    }
}
