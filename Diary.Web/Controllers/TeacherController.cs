using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Diary.Web.Data;
using System.Data;
using Diary.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diary.Web.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        // GET: Teacher
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        public TeacherController(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult ViewLesson()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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
                    _db.Lessons.Where(x => x.Day == i).Where(x=>x.Teacher.UserId==uId).Select(x => new TableLessons
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
        [HttpGet]
        public IActionResult AddHomework()
        {
            SelectList classes = new(_db.Classes, "Id", "Name");
            ViewBag.Classes = classes;
            return View();
        }
        [HttpPost]
        public IActionResult AddHomework(HomeworkViewModel model)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var time = model.Date.Add(model.Time.TimeOfDay);
            var homework = new Homework { ClassId = model.ClassId, TaskText = model.TaskText, TeacherId = tId, Deadline = time, Title = model.Title };
            _db.Homeworks.Add(homework);
            _db.SaveChanges();
            return RedirectToAction("AddHomework", "Teacher");
        }
        [HttpGet]
        public IActionResult ViewHomework()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var homeworks = (_db.Homeworks.Where(x => x.TeacherId == tId).Select(x => new ViewHomework
            {
                Title = x.Title,
                ClassName = x.Class.Name,
                TaskText = x.TaskText,
                Deadline = x.Deadline,
            }).ToList());
            return View(homeworks);
        }
    }
}

