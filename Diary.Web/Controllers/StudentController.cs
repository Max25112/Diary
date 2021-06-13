using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Diary.Web.Data;
using System.Security.Claims;
using System;
using Diary.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Diary.Web.Controllers
{
    [Authorize(Roles = "Student")]
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
        [HttpGet]
        public IActionResult ViewHomework()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var classId = Convert.ToInt32(_db.Students.Where(x => x.UserId == uId).Select(x => x.ClassId).Single());
            var homeworks = (_db.Homeworks.Where(x => x.ClassId == classId)/*.Where(x=>x.Deadline>DateTime.Now)*/.Select(x => new ViewHomework
            {
                Id = x.Id,
                Title = x.Title,
                FIO = x.Teacher.User.LastName + " " + x.Teacher.User.FirstName[0] + "." + x.Teacher.User.MiddleName[0],
                SubjectName = x.Subject.Name,
                TaskText = x.TaskText,
                Deadline = x.Deadline,
            }).ToList());
            return View(homeworks);
        }
        [HttpGet]
        public new IActionResult Response(int HomeworkId)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HomeworkViewModel homework = _db.Homeworks.Where(x => x.Id == HomeworkId).Select(x => new HomeworkViewModel
            {
                HomeworkId = x.Id,
                Deadline = x.Deadline,
                TaskText = x.TaskText,
                Title = x.Title,
                SubjectId = x.SubjectId
            }).Single();
            ViewData["SubjectName"] = _db.Subjects.Where(x => x.Id == homework.SubjectId).Select(x => x.Name).Single().ToString();
            ViewBag.HomeworkId = homework.HomeworkId;
            return View(homework);
        }
        [HttpPost]
        public async Task<IActionResult> Response(int HomeworkId, [FromForm] List<IFormFile> Files, string Response)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var classId = Convert.ToInt32(_db.Students.Where(x => x.UserId == uId).Select(x => x.ClassId).Single());
            var sId = Convert.ToInt32(_db.Students.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            //Attachment attachment = new Attachment { Name = uploadedFile.FileName };

            var homeworkResult = _db.Homeworks.Where(x => x.Id == HomeworkId).Select(x => new HomeworkResult
            {
                ClassId = x.ClassId,
                Response = Response,
                StudentId = sId,
                HomeworkId = x.Id,
                SubjectId = x.SubjectId,
                TeacherId = x.TeacherId
            }).Single();
            _db.HomeworkResults.Add(homeworkResult);
            _db.SaveChanges();
            foreach (var file in Files)
            {
                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var extension = Path.GetExtension(file.FileName);
                        var attachment = new Attachment
                        {
                            CreatedOn = DateTime.UtcNow,
                            FileType = file.ContentType,
                            Extension = extension,
                            Name = fileName,
                            HomeworkResult = homeworkResult
                        };
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            attachment.Data = dataStream.ToArray();
                        }
                        _db.Attachments.Add(attachment);
                    }
                }
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult ViewResponse()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var sId = Convert.ToInt32(_db.Students.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var responses = _db.HomeworkResults.Where(x => x.StudentId == sId).Select(x => new ViewResponse
            {
                Id = x.Id,
                SubjecName = x.Subject.Name,
                Deadline = x.Homework.Deadline,
                Attachments = x.Attachments,
                Title=x.Homework.Title
            });
            return View(responses);
        }
        public IActionResult DownloadFile(int id)
        {
            /*var file = await _db.HomeworkResults.Include("Attachement").Where(x => x.Id == id).Select(x => new Attachment { 
                  Data = x.Attachments.,
                  FileType=x.FileType,
            }).ToList();*/
            var file = _db.Attachments.Where(x => x.Id == id).Single();

            if (file == null) return null;
            var FileType = file.FileType;
            return File(file.Data, file.FileType, file.Name + file.Extension);
            //return View();
        }
    }
}
