using System;
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
    //[Authorize(Roles = "Admin")]
    
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public string message = "";
        public string choice { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            SelectList subjects = new SelectList(_db.Subjects);
            ViewBag.Subjects = subjects;
            SelectList classes = new SelectList(_db.Classes);
            ViewBag.Classes = classes;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, MiddleName = model.MiddleName };// добавляем пользователя
                var student = new Student { User = user, UserId = user.Id, Class = model.Student.Class};
                var teacher = new Teacher { User = user, UserId = user.Id, Subjects = model.Teacher.Subjects };
                /*
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                */
            }
            return View(model);
        }
        private void my_button_Click(object sender)
        {
            if (choice=="teacher")
                IsTeacher();
            if (choice == "student")
                IsStudent();
            else message = "Выберите род деятельности";
        }
        public void IsTeacher()
        {

        }
        public void IsStudent()
        {

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
        public void AddClass(Class classs)
        {
            _db.Classes.Add(classs);
            _db.SaveChanges();
        }
        [HttpPost]
        public IActionResult AddSubject(Subject subject)
        {
            return View();
        }
    }
}
