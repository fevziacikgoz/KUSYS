using KUSYS.Application.CourseMatchOp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Controllers
{
    [AllowAnonymous]
    public class CourseMatchViewController : Controller
    {
        public IActionResult Index(string id)
        {
            List<CourseMatchStudentResponse> courseMatchResponses = new List<CourseMatchStudentResponse>();
            ViewBag.Id = id;
            return View(courseMatchResponses);
        }
        public IActionResult Create(string id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
