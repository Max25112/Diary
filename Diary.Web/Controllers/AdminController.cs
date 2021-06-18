using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Diary.Web.Data;
using System.Data;
using Diary.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace Diary.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public AdminController(
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _db = db;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            SelectList subjects = new SelectList(_db.Subjects, "Id", "Name");
            ViewBag.Subjects = subjects;
            SelectList classes = new SelectList(_db.Classes, "Id", "Name");
            ViewBag.Classes = classes;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelApplicationUser model, string cases)
        {
            if (ModelState.IsValid)
            {
                if (cases == "NoChoice")
                {
                    return View();
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, MiddleName = model.MiddleName };// добавляем пользователя// , Student = student, Teacher=teacher
                var result = await _userManager.CreateAsync(user, model.Password);
                var userId = _db.Users.Where(x => x.Email == user.Email).Select(x => x.Id).Single().ToString();
                var userRole = await _userManager.FindByIdAsync(userId);
                if (cases == "Teacher")
                {
                    IEnumerable<string> role = new string[] { "Teacher" };
                    await _userManager.AddToRolesAsync(user, role);

                    List<Subject> Subs = new List<Subject>();
                    foreach (var a in model.SubjectIds)
                    {
                        string b = (from t in _db.Subjects
                                    where t.Id == a
                                    select t.Name).Single().ToString();
                        Subs.Add(new Subject { Id = a, Name = b });
                    }
                    var teacher = new Teacher
                    {
                        Post = model.TeacherPost,
                        UserId = _db.Users.Where(x => x.Email == user.Email).Select(x => x.Id).Single().ToString()
                    };
                    _db.Teachers.Add(teacher);
                    foreach (var a in Subs)
                        teacher.Subjects.Add(a);

                    _db.SaveChanges();
                }
                if (cases == "Student")
                {
                    IEnumerable<string> role = new string[] { "Student" };
                    await _userManager.AddToRolesAsync(user, role);
                    var student = new Student
                    {
                        ClassId = model.ClassId,
                        UserId = _db.Users.Where(x => x.Email == user.Email).Select(x => x.Id).Single().ToString()
                    };
                    _db.Students.Add(student);
                    _db.SaveChanges();
                }
            }
            ViewBag.Subjects = null;
            ViewBag.Classes = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AddClass()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddSubject()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(Class classs)
        {
            _db.Classes.Add(classs);
            _db.SaveChanges();
            return View();
        }
        [HttpPost]
        public IActionResult AddSubject(Subject subject)
        {
            _db.Subjects.Add(subject);
            _db.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult AddLesson()
        {
            var teacherSubject = _db.Teachers.Include("Subjects").Select(u => new
            {
                Id = u.Id,
                usub = u.Subjects,
            }).ToList();
            ViewBag.TeacherSubject = teacherSubject;
            SelectList classes = new SelectList(_db.Classes, "Id", "Name");
            ViewBag.Classes = classes;
            var teaherFIO = from t in _db.Teachers
                            join u in _db.Users on t.UserId equals u.Id
                            select new
                            {
                                FIO = u.LastName + " " + u.FirstName + " " + u.MiddleName,
                                Id = t.Id
                            };
            SelectList teachers = new SelectList(teaherFIO, "Id", "FIO");
            ViewBag.Teachers = teachers;
            SelectList subjects = new SelectList(_db.Subjects, "Id", "Name");
            ViewBag.Subjects = subjects;

            return View();
        }
        [HttpPost]
        public IActionResult AddLesson(LessonModel model)
        {
            var lesson = new Lesson { TeacherId = model.TeacherId, ClassId = model.ClassId, Cabinet = model.Cabinet, Day = model.Day, Order = model.Order, SubjectId = model.SubjectId };
            _db.Lessons.Add(lesson);
            _db.SaveChanges();
            return RedirectToAction("AddLesson");
        }
        [HttpPost]
        public JsonResult SelectSub([FromBody] string TeacherId)
        {
            int value = Convert.ToInt32(TeacherId);
            var teacherSubject = _db.Teachers.Include("Subjects").Where(u => u.Id == value).Select(u => new
            {
                usub = u.Subjects
            }).ToList();

            var sub = new List<Sub>();
            for (int i = 0; i < teacherSubject.Count + 1; i++)
            {
                sub.Add(new Sub(teacherSubject[0].usub[i].Id, teacherSubject[0].usub[i].Name));
            }
            return Json(sub);
        }
        [HttpGet]
        public IActionResult AllGrades()
        {
            var teaherFIO = from t in _db.Teachers
                            join u in _db.Users on t.UserId equals u.Id
                            select new
                            {
                                FIO = u.LastName + " " + u.FirstName + " " + u.MiddleName,
                                Id = t.Id
                            };
            SelectList teachers = new SelectList(teaherFIO, "Id", "FIO");
            ViewBag.Teachers = teachers;
            SelectList classes = new SelectList(_db.Classes, "Id", "Name");
            ViewBag.Classes = classes;
            return View();
        }
        [HttpPost]
        public JsonResult SelectResponse([FromBody] TeacherClass teacherClass)
        {
            int StudentLenght = _db.Students.Where(x => x.ClassId == Convert.ToInt32(teacherClass.ClassId)).Count();
            int HomeworkLength = _db.Homeworks.Where(x => x.ClassId == Convert.ToInt32(teacherClass.ClassId)).Count();
            var students = _db.Students.Where(x => x.ClassId == Convert.ToInt32(teacherClass.ClassId))
                .OrderBy(x => x.User.LastName)
                .ThenBy(x => x.User.FirstName)
                .ThenBy(x => x.User.MiddleName)
                .Select(x => new
                {
                    Id = x.Id,
                    StudentName = x.User.LastName + " " + x.User.FirstName[0] + "." + x.User.MiddleName[0] + "."
                }).ToList();
            var titleHw = _db.Homeworks
                .Where(x => x.ClassId == Convert.ToInt32(teacherClass.ClassId))
                .Where(x => x.TeacherId == Convert.ToInt32(teacherClass.TeacherId))
                .Select(x => new
                {
                    Id = x.Id,
                    Title = x.Title
                }).ToList();
            string[,] Gr = new string[StudentLenght + 1, HomeworkLength + 1];
            int n = 1;
            foreach (var item in students)
            {
                Gr[n, 0] = item.StudentName;
                n++;
            }
            n = 1;
            foreach (var item in titleHw)
            {
                Gr[0, n] = item.Title;
                n++;
            }

            for (int i = 1; i <= StudentLenght; i++)
            {
                for (int j = 1; j <= HomeworkLength; j++)
                {
                    if (!_db.HomeworkResults.Any(x => x.Homework.Id == titleHw[j - 1].Id
                    && x.StudentId == students[i - 1].Id))
                        continue;
                    Gr[i, j] = _db.HomeworkResults
                        .Where(x => x.Homework.Id == titleHw[j - 1].Id)
                        .Where(x => x.StudentId == students[i - 1].Id)
                        .Select(x => x.Grade).Single().ToString();
                }
            }
            var res= JsonConvert.SerializeObject(Gr);
            return Json(res);//grades
        }
    }
    public struct Sub
    {
        public Sub(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
    }
    public class TeacherClass
    {
        public string ClassId { get; set; }
        public string TeacherId { get; set; }
    }
    public class Grades
    {
        public int HomeworkId { get; set; }
        public int Grade { get; set; }
        public string StudentName { get; set; }
        public string Title { get; set; }

    }
    public class JsonGrade
    {
        public int StudentLenght { get; set; }
        public int HomeworkLength { get; set; }
        public List<string> NameStudent { get; set; } = new();
        public List<int> IdHomework { get; set; } = new();
        public List<Grades> Grades { get; set; } = new();
    }
}