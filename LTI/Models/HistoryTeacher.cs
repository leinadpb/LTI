using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class HistoryTeacher
    {
        [Key]
        public int HistoryTeacherID { get; set; }

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

        //Navigation properties
        public ICollection<Teacher> Teachers { get; set; }


    }
}
