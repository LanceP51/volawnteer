using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace voLAWNteer.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Display(Name = "Date Completed")]
        public DateTime? CompletedDate { get; set; }

        [Display(Name = "Listing Created")]
        public DateTime ListingCreated { get; set; }

        public int? LawnId { get; set; }

        public Lawn Lawn { get; set; }
    }
}
