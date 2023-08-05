using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.StudentsOp.Query.GetStudentsQueries;
using MediatR;
namespace KUSYS.Application.StudentsOp.Query.Handle.GetStudentsHandle
{
    public class GetStudentsQueryHandle : IRequestHandler<GetStudentsQuery, List<StudentsResponse>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        public GetStudentsQueryHandle(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<StudentsResponse>>(_studentRepository.GetAll().ToList());
        }
    }
}
