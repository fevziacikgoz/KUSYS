using KUSYS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Domain.Entity
{
    public class CourseMatch : BaseEntity
    {
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
    }
}
