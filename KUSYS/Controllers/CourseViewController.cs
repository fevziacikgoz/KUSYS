using KUSYS.Application.CourseOp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Controllers
{
    [AllowAnonymous]
    public class CourseViewController : Controller
    {
        public IActionResult Index()
        {
            List<CourseResponse> courseResponses = new List<CourseResponse>();

            return View(courseResponses);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
