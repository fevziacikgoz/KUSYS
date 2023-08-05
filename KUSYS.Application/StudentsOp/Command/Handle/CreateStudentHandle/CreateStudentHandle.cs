using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Command.CreateStudent;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.StudentsOp.Command.Handle.CreateStudentHandle
{
    public class CreateStudentHandle : IRequestHandler<CreateStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public CreateStudentHandle(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Student>(request.createUpdateStudentModel);
            return await _studentRepository.AddAsync(model);
        }
    }
}
