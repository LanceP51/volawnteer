using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace voLAWNteer.Models
{
    public class Lawn
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Required]
        [Display(Name = "Zip Code")]
        public long ZipCode { get; set; }
        
        [Required]
        public string Size { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public bool Approved { get; set; }
        
        [Required]
        public string Photo { get; set; }

        public List<Service> Services { get; set; } = new List<Service>();
    }
}
