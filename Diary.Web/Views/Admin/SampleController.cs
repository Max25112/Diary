using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Diary.Web.Views.Admin
{
    public class SampleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SampleController(
           ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SelectSub(int TeacherID)
        {
            var teacherSubject = _db.Teachers.Include("Subjects").Where(u => u.Id == TeacherID).Select(u => new
            {
                Id = u.Id,
                usub = u.Subjects,
            }).ToList();
            ViewBag.TeacherSubject = teacherSubject;
            var data = JsonConvert.SerializeObject(teacherSubject);
            return Json(data);
        }
    }
}
