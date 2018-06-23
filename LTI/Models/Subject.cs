using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [Required]
        [StringLength(120)]
        public string SubjectName { get; set; }

        [Required]
        [StringLength(10)]
        public string SubjectCode { get; set; }

        //Navigation Properties

    }
}
