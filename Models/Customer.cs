using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreSelect_List.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(75)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        public String LastName { get; set; }
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-Mail is not Valid")]
        public String EmailId { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public String CountryCode { get; set; }
        public virtual Country_dj Country { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("City")]
        [DisplayName("City")]
        public String CityCode { get; set; }
        public virtual City_dj city { get; set; }
    }
}
