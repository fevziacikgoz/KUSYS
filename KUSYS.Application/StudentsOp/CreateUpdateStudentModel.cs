using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Application.StudentsOp
{
    public class CreateUpdateStudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Password { get; set; }
        public long SchoolNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
        public string? IdentityUserId { get; set; }
        public bool CreateUser { get; set; }
    }
}
