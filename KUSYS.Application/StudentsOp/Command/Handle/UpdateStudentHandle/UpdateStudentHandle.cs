using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Command.UpdateStudent;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.StudentsOp.Command.Handle.UpdateStudentHandle
{
    public class UpdateStudentHandle : IRequestHandler<UpdateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public UpdateStudentHandle(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Student>(request.createUpdateStudentModel);
            return Task.FromResult(_studentRepository.Update(model));
        }
    }
}
