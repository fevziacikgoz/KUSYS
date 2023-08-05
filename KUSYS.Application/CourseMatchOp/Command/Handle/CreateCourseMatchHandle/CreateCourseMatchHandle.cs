using AutoMapper;
using KUSYS.Application.Common.Dtos;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.Common.Messages;
using KUSYS.Application.CourseMatchOp.Command.CreateCourseMatch;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.Handle.CreateCourseMatchHandle
{
    public class CreateCourseMatchHandle : IRequestHandler<CreateCourseMatchCommand, DataResponseDto<bool>>
    {
        private readonly ICourseMatchRepository _courseMatchRepository;
        private readonly IMapper _mapper;
        public CreateCourseMatchHandle(ICourseMatchRepository courseMatchRepository, IMapper mapper)
        {
            _courseMatchRepository = courseMatchRepository;
            _mapper = mapper;
        }

        public async Task<DataResponseDto<bool>> Handle(CreateCourseMatchCommand request, CancellationToken cancellationToken)
        {
            var matchCheck = _courseMatchRepository.GetWhere(w => w.CourseId == request.CreateUpdateCourseMatchModel.CourseId && w.StudentId == request.CreateUpdateCourseMatchModel.StudentId).FirstOrDefault();
            if (matchCheck == null)
            {
                var model = _mapper.Map<CourseMatch>(request.CreateUpdateCourseMatchModel);
                var add = await _courseMatchRepository.AddAsync(model);
                return new DataResponseDto<bool>
                {
                    Data = add,
                    Successful = add,
                    Message = add ? MessagesConstant.StudentCourseAdded : MessagesConstant.StudentCourseAddException
                };
            }
            else
            {
                return new DataResponseDto<bool>
                {
                    Data = false,
                    Successful = false,
                    Message = MessagesConstant.StudentCourseAlreadyExist
                };
            }

        }
    }
}
