using KUSYS.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace KUSYS.Domain.Entity
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public long? SchoolNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Mail { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public string IdentityUserId { get; set; }
    }
}