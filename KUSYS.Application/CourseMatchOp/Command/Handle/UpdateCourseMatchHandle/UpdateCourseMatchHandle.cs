using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseMatchOp.Command.UpdateCourseMatch;
using KUSYS.Application.StudentsOp.Command.UpdateStudent;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.Handle.UpdateCourseMatchHandle
{
    public class UpdateCourseMatchHandle : IRequestHandler<UpdateCourseMatchCommand, bool>
    {
        private readonly ICourseMatchRepository _courseMatchRepository;
        private readonly IMapper _mapper;
        public UpdateCourseMatchHandle(ICourseMatchRepository courseMatchRepository, IMapper mapper)
        {
            _courseMatchRepository = courseMatchRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCourseMatchCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<CourseMatch>(request.CreateUpdateCourseMatchModel);
            return Task.FromResult(_courseMatchRepository.Update(model));
        }
    }
}
