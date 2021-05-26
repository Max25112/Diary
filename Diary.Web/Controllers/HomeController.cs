using Diary.Web.Data;
using Diary.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy([FromServices] RoleManager<IdentityRole> roleManager, [FromServices] UserManager<ApplicationUser> userManager,
            [FromServices] ApplicationDbContext db)
        {
            //roleManager.            

            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Student"
            });
            //var user = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            //await userManager.AddToRoleAsync(user, "Teacher");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
