using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Diary.Web.Data;
using System.Data;
using Diary.Web.Models;
using Diary.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                var userRole = await _userManager.FindByIdAsync(user.Id);
                /*  if (result.Succeeded)
                   {
                       // установка куки
                       //await _signInManager.SignInAsync(user, false);
                   }
                   else
                   {
                       foreach (var error in result.Errors)
                       {
                           ModelState.AddModelError(string.Empty, error.Description);
                       }
                   }
                  */
                if (cases == "Teacher")
                {
                    IEnumerable<string> role = new string[] { "Teacher" };
                    await _userManager.AddToRolesAsync(user, role);

                    List <Subject> Subs = new List<Subject>();
                    foreach (var a in model.SubjectIds)
                    {
                        string b = (from t in _db.Subjects // определяем каждый объект из teams как t
                                    where t.Id == a//фильтрация по критерию
                                    select t.Name).Single().ToString();
                        Subs.Add(new Subject { Id = a, Name = b });
                    }
                    var teacher = new Teacher
                    {
                        Post = model.TeacherPost,
                        UserId = (from t in _db.Users // определяем каждый объект из teams как t//фильтрация по критерию
                                  orderby t.Id
                                  select t.Id).Last()
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
                    
                    //await _userManager.AddToRoleAsync(user, "Student");
                    /*var Clas = new Class
                    {
                        Id =  model.ClassId,
                        Name = (from t in _db.Classes // определяем каждый объект из teams как t
                                where t.Id == model.ClassId//фильтрация по критерию
                                select t.Name).Single().ToString()
                    }; */
                    var student = new Student
                    {
                        ClassId = model.ClassId,
                        UserId = (from t in _db.Users // определяем каждый объект из teams как t//фильтрация по критерию
                                  orderby t.Id
                                  select t.Id).Last()

                    };
                    _db.Students.Add(student);
                    _db.SaveChanges();
                }
            }
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

    }
}

