using System;
using System.Collections.Generic;

namespace APP.Models
{
    public partial class Packages
    {
        public Packages()
        {
            Customers = new HashSet<Customers>();
        }

        public int PackId { get; set; }
        public string Speed { get; set; }
        public DateTime? StrtDate { get; set; }
        public int? MonthlyPayment { get; set; }
        public int? SectorId { get; set; }

        public virtual Sectors Sector { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
