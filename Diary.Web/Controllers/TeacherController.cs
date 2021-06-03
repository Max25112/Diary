using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Diary.Web.Data;
using System.Security.Claims;
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
                    _db.Lessons.Where(x => x.Day == i).Select(x => new TableLessons
                    {
                        Id = x.Id,
                        FIO = x.Teacher.User.LastName + " " + x.Teacher.User.FirstName[0] + "." + x.Teacher.User.MiddleName[0],
                        ClassName = x.Class.Name,
                        SubjectName = x.Subject.Name,
                        Cabinet = x.Cabinet,
                        Order = x.Order
                    }).OrderBy(i => i.Order).ToList());
            }
            int n = 1;
            return View(DictLessons);
        }
    }
    /*  public class TableLessons
     {
         public int Id { get; set; }
         public string TeacherFIO { get; set; }
         public int TeacherId { get; set; }
         public int ClassId { get; set; }
         public string ClassName { get; set; }
         public int SubjectId { get; set; }
         public string SubjectName { get; set; }
         public string Cabinet { get; set; }
         public int Day { get; set; }
         public int Order { get; set; }
     }*/

}

