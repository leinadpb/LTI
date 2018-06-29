using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Admin
    {
        [Key]
        public int AdminID { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

    }
}
