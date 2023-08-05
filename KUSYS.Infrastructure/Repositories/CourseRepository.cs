﻿using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Infrastructure.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(KUSYSContext context) : base(context) { }

    }
}
