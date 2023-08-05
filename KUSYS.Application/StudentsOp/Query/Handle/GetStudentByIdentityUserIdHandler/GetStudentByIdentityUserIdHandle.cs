using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Query.GetStudentByIdentityUserIdQueries;
using KUSYS.Application.StudentsOp.Query.GetStudentByIdQueries;
using MediatR;
namespace KUSYS.Application.StudentsOp.Query.Handle.GetStudentByIdentityUserIdHandler
{
    public class GetStudentByIdentityUserIdHandle : IRequestHandler<GetStudentByIdentityUserIdQuery, StudentsResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentByIdentityUserIdHandle(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentsResponse> Handle(GetStudentByIdentityUserIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<StudentsResponse>(_studentRepository.GetWhere(w => w.IdentityUserId == request.identityUserId).FirstOrDefault());
        }
    }
}
