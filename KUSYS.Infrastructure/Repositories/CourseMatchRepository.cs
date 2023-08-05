using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Infrastructure.Repositories
{
    public class CourseMatchRepository : GenericRepository<CourseMatch>, ICourseMatchRepository
    {
        public CourseMatchRepository(KUSYSContext context) : base(context) { }

    }
}
