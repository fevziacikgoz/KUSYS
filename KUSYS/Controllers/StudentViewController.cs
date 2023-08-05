using KUSYS.Application.StudentsOp;
using KUSYS.Application.StudentsOp.Query.GetStudentsQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Controllers
{
    [AllowAnonymous]
    public class StudentViewController : Controller
    {
       
        public IActionResult Index()
        {           
            return View(new List<StudentsResponse>());
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            ViewBag.Id = id;
            return View(new CreateUpdateStudentModel());
        }

        public IActionResult Detail(string id)
        {
            ViewBag.Id = id;
            return View(new StudentsResponse());
        }
    }
}
