using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Diary.Web.Data;
using System.Security.Claims;
using System;

namespace Diary.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public StudentController(ApplicationDbContext db,
           UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        // GET: Student
        public ActionResult Index()
        {            
            return View();
        }
        public IActionResult ViewLesson()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var classId = Convert.ToInt32(_db.Students.Where(x => x.UserId == uId).Select(x => x.ClassId).Single());//.Single()
            Dictionary<int, List<TableLessons>> DictLessons = new Dictionary<int, List<TableLessons>>(6);
            var ListLessons = _db.Lessons.Select(x => new TableLessons
            {
                Id = x.Id,
                FIO = x.Teacher.User.LastName + " " + x.Teacher.User.FirstName[0] + "." + x.Teacher.User.MiddleName[0],
                ClassName = x.Class.Name,
                SubjectName = x.Subject.Name,
                Cabinet = x.Cabinet,
                Order = x.Order
            }).ToList();
            for (int i = 1; i <= 6; i++)
            {
                DictLessons.Add(i,
                    _db.Lessons.Where(x => x.Day == i).Where(x => x.ClassId == classId).Select(x => new TableLessons
                    {
                        Id = x.Id,
                        FIO = x.Teacher.User.LastName + " " + x.Teacher.User.FirstName[0] + "." + x.Teacher.User.MiddleName[0],
                        ClassName = x.Class.Name,
                        SubjectName = x.Subject.Name,
                        Cabinet = x.Cabinet,
                        Order = x.Order
                    }).OrderBy(i => i.Order).ToList());
            }
            return View(DictLessons);
        }


    }
}
