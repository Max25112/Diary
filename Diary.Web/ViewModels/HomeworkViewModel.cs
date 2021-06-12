using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Diary.Web.ViewModels
{
    public class HomeworkViewModel
    {
        [Required()]
        public int TeacherId { get; set; }
        [Required()]
        [Display(Name = "Класс")]
        public int ClassId { get; set; }
        [Required()]
        [Display(Name = "Предмет")]
        public int SubjectId { get; set; }
        [Required()]
        [Display(Name = "Название")]
        public string Title { get; set; }
        [Required()]
        [Display(Name = "Текст Задания")]
        public string TaskText { get; set; }
        [Required()]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Required()]
        [Display(Name = "Время")]
        public DateTime Time { get; set; }
        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }
        [Display(Name = "Файл")]
        public IFormFile Files { get; set; }
        public int HomeworkId { get; set; }
    }
}
