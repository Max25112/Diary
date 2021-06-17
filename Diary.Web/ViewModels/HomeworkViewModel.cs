using Diary.Web.Data;
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
        [Display(Name = "Класс")]
        public string ClassName { get; set; }
        [Display(Name = "Предмет")]
        public string SubjectName { get; set; }
        [Required()]
        [Display(Name = "Текст задания")]
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
        public string DeadlineString { get; set; }
        public string DateString { get; set; }
        public string TimeString { get; set; }
        public List<IFormFile> Files { get; set; }
        public int HomeworkId { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
    }
}
