using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required]
        [StringLength(60)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(120)]
        public string DisplayName { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Domain { get; set; }

        [Required]
        [StringLength(20)]
        public string ComputerName { get; set; }

        [Required]
        public bool HasFilledSurvey { get; set; }
        
        //Navigation Properties

        public HistoryTeacher HistoryTeacher { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Suggestion> Suggestions { get; set; }
        public ICollection<Claim> Claims { get; set; }
        public ICollection<Complain> Complains { get; set; }

        public ICollection<Student> Students { get; set; }

    }
}
