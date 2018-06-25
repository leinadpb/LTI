using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Claim
    {
        [Key]
        public int ClaimID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The text is too long.")]
        public string ClaimText { get; set; }

        //Navigation properties
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}
