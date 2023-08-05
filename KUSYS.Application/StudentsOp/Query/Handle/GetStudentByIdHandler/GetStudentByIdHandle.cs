using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Query.GetStudentByIdQueries;
using MediatR;
namespace KUSYS.Application.StudentsOp.Query.Handle.GetStudentByIdHandler
{
    public class GetStudentByIdHandle : IRequestHandler<GetStudentByIdQuery, StudentsResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentByIdHandle(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentsResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentsResponse>(_studentRepository.GetByIdAsync(request.id).Result);
        }
    }
}
