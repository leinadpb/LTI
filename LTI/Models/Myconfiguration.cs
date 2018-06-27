using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTI.Models
{
    class Myconfiguration
    {
        [Key]
        public int MyconfigurationID { get; set; }

        [StringLength(30)]
        public string Key { get; set; }

        [StringLength(1200)]
        public string Value { get; set; }
    }
}
