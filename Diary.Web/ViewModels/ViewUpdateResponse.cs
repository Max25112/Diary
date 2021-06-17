using Diary.Web.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.ViewModels
{
    public class ViewUpdateResponse
    {
        [Required()]
        public int Id { get; set; }
        [Required()]
        public string Title { get; set; }//Возможно нужно убрать 
        [Required()]
        public int Grade { get; set; }
        [Required()]
        public DateTime Deadline { get; set; }
        public int SubjectId { get; set; }
        public string TaskText { get; set; }
        public string ClassName { get; set; }
        public string SubjecName { get; set; }
        public string StudentName { get; set; }
        public string Response { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<Attachment> AttachmentsTeacher { get; set; } = new();
        public List<Attachment> AttachmentsStudent { get; set; } = new();
    }
}
