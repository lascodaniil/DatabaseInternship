using Microsoft.EntityFrameworkCore;

namespace APP
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) {

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id=1 , RestaurantName= "Mi Piace", City = "Chisinau", Street = "str.Miron Costin", RestaurantType="Italian", Capacity=150},
                new Restaurant { Id=2 , RestaurantName= "Meat House", City = "Chisinau", Street = "str.Ismail", RestaurantType="Moldavian", Capacity=10},
                new Restaurant { Id=3 , RestaurantName= "Star Kebab", City = "Chisinau", Street = "bd.Moscova", RestaurantType="Fast-Food", Capacity=50},
                new Restaurant { Id=4 , RestaurantName= "Twistter", City = "Chisinau", Street = "bd.Moscova", RestaurantType="Fast-Food", Capacity=15},
                new Restaurant { Id=5 , RestaurantName= "Andys Pizza", City = "Chisinau", Street = "str.Ceucari", RestaurantType="Fast-Food", Capacity=50},
                new Restaurant { Id=6 , RestaurantName= "Versenz", City = "Chisinau", Street = "bd.Moscova", RestaurantType="Wedding", Capacity=150},
                new Restaurant { Id=7 , RestaurantName= "Capitoles Park", City = "Chisinau", Street = "db.Decebal", RestaurantType= "Wedding", Capacity=250},
                new Restaurant { Id=8 , RestaurantName= "Oasis", City = "Chisinau", Street = "bd.Stefan cel Mare", RestaurantType="Turkish", Capacity=70},
                new Restaurant { Id=9 , RestaurantName= "Eleganace", City = "Chisinau", Street = "str.Ceucari", RestaurantType="Wedding", Capacity=150}
            );
        }
    }

}
