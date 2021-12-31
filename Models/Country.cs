using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSelect_List.Models
{
    public class Country_dj
    {
        [Key]
        [MaxLength(3)]
        public String Code { get; set;}
        [Required]
        [MaxLength(75)]
        public String Name { get; set; }
    }
}
