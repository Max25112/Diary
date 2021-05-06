using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diary.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }

    public class ApplicationUser : IdentityUser
    {
        [Required()]
        public string FirstName { get; set; }
        [Required()]
        public string LastName { get; set; }
        [Required()]
        public string MiddleName { get; set; }
    }
}
