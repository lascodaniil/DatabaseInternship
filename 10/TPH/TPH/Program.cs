using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPH
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProjectEFDbContext testProjectEFDbContext = new TestProjectEFDbContext();


            var FirstUniversitiy = testProjectEFDbContext.Universities.First();

            testProjectEFDbContext.Database.ExecuteSqlCommand(" UPDATE " + " dbo.Universities SET Name = @p0" + " WHERE UniversityId = @p1", "UTM", 1);
            FirstUniversitiy.Name = "USM";

            try
            {
                testProjectEFDbContext.SaveChanges(); // exception
            }catch(DbUpdateConcurrencyException e)
            {
                SaveCheckChanges(testProjectEFDbContext);
            }


            Console.ReadLine();
        }


        public static void SaveCheckChanges(TestProjectEFDbContext context)
        {
            var saved = false;
            while (!saved)
            {
                try
                {
                    context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        if (entry.Entity is BaseUniversity)
                        {

                            var proposedValues = entry.CurrentValues;
                            var databaseValues = entry.GetDatabaseValues();

                            foreach (var property in proposedValues.Properties)
                            {
                                var proposedValue = proposedValues[property];
                                var databaseValue = databaseValues[property];

                            }
                           // entry.OriginalValues.SetValues(databaseValues);
                        }
                        
                    }
                }
            }
        }
    }
}
