using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Application.Common.Messages
{
    public class MessagesConstant
    {
        #region StudentCourse
        public const string StudentCourseAlreadyExist = "The student has already been added to the course.";
        public const string StudentCourseAdded = "The student has been added to the course.";
        public const string StudentCourseAddException = "An error occurred while adding the student to the course.";
        public const string StudentCourseDenied = "Unauthorized course matching cannot be made!";
        #endregion

        #region Register
        public const string UserAlreadyExist = "User already exist!";
        public const string UserCreated = "User Created Successfully!";
        public const string UserCreateFailed = "User Failed To Create!";
        #endregion
    }
}
