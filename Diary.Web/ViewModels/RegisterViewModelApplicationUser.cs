using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Diary.Web.ViewModels
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
        [Display(Name = "Предмет")]
        public List<int> SubjectIds { get; set; }
        [Display(Name = "Должность")]
        public string TeacherPost { get; set; }
        [Display(Name = "Класс")]
        public int ClassId { get; set; }
        //public RegisterViewModelStudent Student {get; set;}
        //public RegisterViewModelTeacher Teacher { get; set; }
    }
    
}
    

