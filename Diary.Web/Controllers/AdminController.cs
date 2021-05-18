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
using Diary.Web.Views.ViewModels;

namespace Diary.Web.Controllers
{

    [Authorize(Roles = "Admin")]
    
    public class AdminController : Controller
    {
        public string message = "";
        public RegisterViewModelApplicationUser Input { get; set; }
        public string choice { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModelApplicationUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName, MiddleName = Input.MiddleName };
                ApplicationDbContext db = new ApplicationDbContext();
                //string connectionString = @"Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Class;Integrated Security=True";
                //DataContext db = new DataContext(connectionString);
                //this.DataContext = Classes;
                //var student = new Student { UserId=user.Id, Class=Input.Class};
                //var teacher = new Teacher { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName, MiddleName = Input.MiddleName };
                // добавляем пользователя
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
        public IActionResult AddClass()
        {
            return View();
        }
        public IActionResult AddSubject()
        {
            return View();
        }
       
    }
}
