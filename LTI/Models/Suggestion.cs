using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Suggestion
    {

        [Key]
        public int SuggestionID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The text is too long.")]
        public string SuggestionText { get; set; }

        //Navigation properties
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }


    }
}
