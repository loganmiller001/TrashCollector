using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public int Zipcode { get; set; }
        public double AmountDue { get; set; }
        public string PickUpDay { get; set; }
        public string OneTimePickUp {get; set;}
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public virtual ApplicationUser applicationUser { get; set; }

    }
}