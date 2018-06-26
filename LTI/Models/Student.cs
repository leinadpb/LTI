using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [StringLength(120)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(60)]
        public string LoginName { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }

        [Required]
        [StringLength(20)]
        public string Domain { get; set; }

        [Required]
        [StringLength(20)]
        public string ComputerName { get; set; }

        [StringLength(140)]
        public string SubjectName { get; set; }

        [StringLength(10)]
        public string SubjectSection { get; set; }

        [StringLength(20)]
        public string SubjectCode { get; set; }

        [Required]
        public bool HasFilledSurvey { get; set; }
        
                //Navigation properties

        public HistoryStudent HistoryStudent { get; set; }


        public virtual Teacher Teacher { get; set; }
        
        public ICollection<Suggestion> Suggestions { get; set; }
        public ICollection<Claim> Claims { get; set; }
        public ICollection<Complain> Complains { get; set; }

    }
}
