using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH
{
    public class TestProjectEFDbContext : DbContext
    {
        private const string connectionString = @"data source=DESKTOP-I2JBLKP; Initial Catalog=TestProjectEF;  Trusted_Connection=True; ";
       
        public TestProjectEFDbContext() { }
        public TestProjectEFDbContext(DbContextOptions options) : base(options) { }
        public DbSet<BaseUniversity> Universities { get; set; }
        public DbSet<MedicineUniversity> MedicineUniversities { get; set; }
        public DbSet<ArtUniversity> ArtUniversities { get; set; }
        public DbSet<TechUniversity> TechUniveristies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
