using System;
using System.Collections.Generic;

namespace APP.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string MainPhoneNum { get; set; }
        public string SecondaryPhoneNum { get; set; }
        public string Fax { get; set; }
        public decimal? MonthlyDiscount { get; set; }
        public int? PackId { get; set; }

        public virtual Packages Pack { get; set; }
    }
}
