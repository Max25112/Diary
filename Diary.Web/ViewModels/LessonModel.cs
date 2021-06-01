using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Diary.Web.ViewModels
{
    public class LessonModel
    {
        [Required()]
        [Display(Name = "Учитель")]
        public int TeacherId { get; set; }
        [Required()]
        [Display(Name = "Класс")]
        public int ClassId { get; set; }
        [Required()]
        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }
        [Required()]
        [Display(Name = "Кабинет")]
        public string Cabinet { get; set; }
        [Required()]
        [Display(Name = "День")]
        public int Day { get; set; }
        [Required()]
        [Display(Name = "Номер Урока")]
        public int Order { get; set; }
    }
}
