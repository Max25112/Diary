using Diary.Web.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.ViewModels
{
    public class ViewResponse
    {
        [Required()]
        public int Id { get; set; }
        [Required()]
        public string Title { get; set; }//Возможно нужно убрать 
        [Required()]
        public int Grade { get; set; }
        [Required()]
        public byte[] Data { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int HomeworkId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime Deadline { get; set; }
        public string TeacherName { get; set; }
        public string ClassName { get; set; }
        public string SubjecName { get; set; }
        public string StudentName { get; set; }
        public string Response { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
    }
}
