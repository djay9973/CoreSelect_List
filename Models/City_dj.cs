using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSelect_List.Models
{
    public class City_dj
    {
        [Key]
        [MaxLength(3)]
        public String Code { get; set; }
        [Required]
        [MaxLength(75)]
        public String Name { get; set; }
        [ForeignKey("Country")]
        public String CountryCode { get; set; }
        public virtual Country_dj Country { get; set;}
    }
}
