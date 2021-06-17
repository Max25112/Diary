﻿using System.Collections.Generic;
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
using Microsoft.AspNetCore.Http;
using System.IO;

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
            string[,] Shedule = new string[6, 7];
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 6; j++)
                {
                    if (!_db.Lessons.Any(x => x.Day == i + 1 && x.Order == j + 1 && x.Teacher.UserId == uId))
                        continue;
                    Shedule[i, j] = _db.Lessons
                        .Where(x => x.Day == i + 1)
                        .Where(x => x.Teacher.UserId == uId)
                        .Where(x => x.Order == j + 1)
                        .Select(x => x.Class.Name + "\n" + x.Subject.Name + "\nКб." + x.Cabinet).Single().ToString();
                }
            }
            return View(Shedule);
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
        public async Task<IActionResult> AddHomework(HomeworkViewModel model, [FromForm] List<IFormFile> Files)
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var time = model.Date.Add(model.Time.TimeOfDay);
            var homework = new Homework
            {
                ClassId = model.ClassId,
                TaskText = model.TaskText,
                TeacherId = tId,
                Deadline = time,
                Title = model.Title,
                SubjectId = model.SubjectId
            };
            _db.Homeworks.Add(homework);
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
                            Homework = homework
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
        public IActionResult ViewHomework()
        {
            var uId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var tId = Convert.ToInt32(_db.Teachers.Where(x => x.UserId == uId).Select(x => x.Id).Single());
            var homeworks = (_db.Homeworks.Where(x => x.TeacherId == tId).Select(x => new ViewHomework
            {
                Id = x.Id,
                Title = x.Title,
                ClassName = x.Class.Name,
                SubjectName = x.Subject.Name,
                TaskText = x.TaskText,
                Deadline = x.Deadline,
                Attachments = x.Attachments
            }).ToList());
            return View(homeworks);
        }
        [HttpGet]
        public IActionResult UpdateHomework(int HomeworkId)
        {
            var homework = _db.Homeworks.Where(x => x.Id == HomeworkId).Select(x => new HomeworkViewModel
            {
                TaskText = x.TaskText,
                //DeadlineString = x.Deadline.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T'),
                //DateString = x.Deadline.ToShortDateString(),
                Date = x.Deadline.Date,
                TimeString = x.Deadline.ToShortTimeString(),
                ClassName = x.Class.Name,
                SubjectName = x.Subject.Name,
                Title = x.Title,
                SubjectId = x.SubjectId,
                HomeworkId = HomeworkId
            }).Single();
            return View(homework);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHomework([FromForm] HomeworkViewModel homeworkViewModel, [FromQuery] int HomeworkId)
        {
            Homework homework = _db.Homeworks.Where(x => x.Id == HomeworkId).Single();
            homework.Deadline = homeworkViewModel.Date.Add(homeworkViewModel.Time.TimeOfDay);
            homework.TaskText = homeworkViewModel.TaskText;
            homework.Title = homeworkViewModel.Title;
            _db.SaveChanges();
            if (_db.Attachments.Any(x => x.HomeworkId == HomeworkId))
            {
                var listAttach = _db.Attachments.Where(x => x.HomeworkId == HomeworkId).ToList();
                foreach (var a in listAttach)
                {
                    _db.Attachments.Remove(a);
                }
            }
            foreach (var file in homeworkViewModel.Files)
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
                            //Homework = homework
                            //HomeworkId = HomeworkId
                        };
                        using (var dataStream = new MemoryStream())
                        {
                            await file.CopyToAsync(dataStream);
                            attachment.Data = dataStream.ToArray();
                        }
                        
                        _db.Attachments.Add(attachment);
                        _db.SaveChanges();
                        attachment.Homework = homework;
                        _db.SaveChanges();
                    }
                }
            }
            _db.SaveChanges();
            return View();
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
                Grade = x.Grade,
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
                Attachments = x.Attachments,
                Response = x.Response,
                ClassName = x.Class.Name,
                StudentName = x.Student.User.LastName + " " + x.Student.User.FirstName[0] + "." + x.Student.User.MiddleName[0] + "."
            }).Single();
            return View(responses);
        }

        [HttpPost]
        public IActionResult UpdateResponse(int Id, int Grade)
        {
            var response = _db.HomeworkResults.Where(x => x.Id == Id).FirstOrDefault();
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

