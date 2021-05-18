﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Diary.Web.Data;
namespace Diary.Web.Views.ViewModels
{
    public class RegisterViewModelApplicationUser
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required()]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required()]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required()]
        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string ConfirmPassword { get; set; }
        public RegisterViewModelStudent student {get; set;}
        public RegisterViewModelTeacher teacher { get; set; }
    }
}
    
