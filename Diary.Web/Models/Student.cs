using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diary.Web.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }
        //
        [Required()]
        public string Grade { get; set; }
        //[Required()]

        public ApplicationUser User { get; set; }
    }

}
