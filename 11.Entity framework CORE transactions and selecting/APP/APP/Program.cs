using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APP;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace APP
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataBaseOperation.CrossTransaction();
            // DataBaseOperation.Transaction();
            Console.ReadLine();
        }
    }

    public class DataBaseOperation
    {

        private const string connectionString = @"data source=DESKTOP-I2JBLKP; Initial Catalog=TransactionDB;  Trusted_Connection=True; ";
        public static void Transaction()
        {
            using (var context = new DatabaseContext())
            {
                using (var dbTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Database.ExecuteSqlCommand(
                       @"INSERT INTO [dbo].[Restaurants] VALUES('Noroc','Chisinau','str.Petricani','Wedding',100)");

                        context.Database.ExecuteSqlCommand(
                       @"UPDATE [dbo].[Restaurants] SET RestaurantName = WHERE [dbo].[Restaurants].Id =50");
                        context.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception e)
                    {
                        dbTransaction.Rollback();
                    }
                }
            }
        }


        public static void CrossTransaction()
        {

            var options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(new SqlConnection(connectionString)).Options;
            using (var FirstContext = new DatabaseContext(options))
            {
                using (var transaction = FirstContext.Database.BeginTransaction())
                {
                    FirstContext.Database.ExecuteSqlCommand(@"INSERT INTO [dbo].[Restaurants] VALUES('Noroc','Chisinau','str.Petricani','Wedding',100)");
                    FirstContext.Restaurants.Add(new Restaurant { RestaurantName = "Noroc", City = "Chisinau", Street = "str.Petricani", RestaurantType = "Wedding", Capacity = 100 });
                    FirstContext.SaveChanges();
                    using (var SecondContext = new DatabaseContext(options))
                    {
                        SecondContext.Database.UseTransaction(transaction.GetDbTransaction());
                        var GrandRestaurants = SecondContext.Restaurants.Where(x => x.Capacity > 50);
                    }
                    transaction.Commit();
                }
            }
        }
    }




}
