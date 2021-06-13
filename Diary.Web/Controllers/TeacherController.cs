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
using Microsoft.EntityFrameworkCore;

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
                    _db.Lessons.Where(x => x.Day == i).Where(x => x.Teacher.UserId == uId).Select(x => new TableLessons
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
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            SelectList classes = new(_db.Classes, "Id", "Name");
            ViewBag.Classes = classes;
            var teacherSubject = _db.Teachers.Include("Subjects").Where(u => u.Id == tId).Select(u => new
            {
                usub = u.Subjects
            }).ToList();
            var sub = new List<Sub>();
            for (int i = 0; i < teacherSubject.Count + 1; i++)
            {
                sub.Add(new Sub(teacherSubject[0].usub[i].Id, teacherSubject[0].usub[i].Name));
            }
            SelectList subjects = new(sub, "Id", "Name");
            ViewBag.Subjects = subjects;
            return View();
        }
        [HttpPost]
        public IActionResult AddHomework(HomeworkViewModel model)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var time = model.Date.Add(model.Time.TimeOfDay);
            var homework = new Homework { ClassId = model.ClassId, TaskText = model.TaskText, TeacherId = tId, Deadline = time, Title = model.Title, SubjectId = model.SubjectId };
            _db.Homeworks.Add(homework);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
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
        [HttpGet]
        public IActionResult ViewResponse()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var responses = _db.HomeworkResults.Where(x => x.TeacherId == tId).Select(x => new ViewResponse
            {
                Id = x.Id,
                SubjecName = x.Subject.Name,
                Deadline = x.Homework.Deadline,
                Attachments = x.Attachments,
                Grade=x.Grade,
                Response = x.Response,
                Title = x.Homework.Title,
                ClassName = x.Class.Name,
                StudentName = x.Student.User.LastName + " " + x.Student.User.FirstName[0] + "." + x.Student.User.MiddleName[0] + "."
            });
            ViewBag.Disabled = "disabled";
            return View(responses);
        }
        [HttpPost]
        public void ViewResponse(List<ViewResponse> viewResponses, List<IdGrade> IdGrade)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var responses = _db.HomeworkResults.Where(x => x.TeacherId == tId).Select(x => new ViewResponse
            {
                Id = x.Id,
                SubjecName = x.Subject.Name,
                Deadline = x.Homework.Deadline,
                Attachments = x.Attachments,
                Response = x.Response,
                Title = x.Homework.Title,
                ClassName = x.Class.Name,
                StudentName = x.Student.User.LastName + " " + x.Student.User.FirstName[0] + "." + x.Student.User.MiddleName[0] + "."
            });
            return;
        }
        [HttpGet]
        public IActionResult UpdateResponse(int id)
        {
            var responses = _db.HomeworkResults.Where(x => x.Id == id).Select(x => new ViewResponse
            {
                Title = x.Homework.Title,
                Id = x.Id,
                SubjecName = x.Subject.Name,
                Grade = x.Grade,
                Attachments=x.Attachments,
                Response=x.Response,
                ClassName=x.Class.Name,
                StudentName = x.Student.User.LastName + " " + x.Student.User.FirstName[0] + "." + x.Student.User.MiddleName[0] + "."
            }).Single();
            return View(responses);
        }

        [HttpPost]
        public IActionResult UpdateResponse(int Id, int Grade)
        {
            var response=_db.HomeworkResults.Where(x => x.Id == Id).FirstOrDefault();
            response.Grade = Grade;
            _db.SaveChanges();
            return RedirectToAction("ViewResponse");
        }
        public IActionResult DownloadFile(int id)
        {
            var file = _db.Attachments.Where(x => x.Id == id).Single();
            if (file == null) return null;
            var FileType = file.FileType;
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }
        [HttpGet]
        public IActionResult ViewGrade()
        {
            return View();
        }
    }
}

