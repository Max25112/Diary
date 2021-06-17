using Diary.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.ViewModels
{
    public class ViewHomework
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public string FIO { get; set; }
        public string SubjectName { get; set; }
        public int HomeworkResultId { get; set; }
        public bool IsExists { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
        public string TaskText { get; set; }
        public DateTime Deadline { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
    }
}
