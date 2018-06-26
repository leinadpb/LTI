using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Complain
    {
        [Key]
        public int ComplainID { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The text is too long.")]
        public string ComplainText { get; set; }

        //Navigation properties

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

    }
}
