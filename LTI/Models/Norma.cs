using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Norma
    {
        [Key]
        public int NormaID { get; set; }

        [Required]
        [StringLength(1250)]
        public string NormaContent { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        //Navigation properties

    }
}
