using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Command.DeleteStudent;
using KUSYS.Application.StudentsOp.Command.UpdateStudent;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.StudentsOp.Command.Handle.UpdateStudentHandle
{
    public class DeleteStudentHandle : IRequestHandler<DeleteStudentCommand, bool>
    {
        private readonly IStudentRepository _studentRepository;
        public DeleteStudentHandle(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.DeleteAsync(request.id);
        }
    }
}
