using FoodTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FoodTrackerContext(
                serviceProvider.GetRequiredService<DbContextOptions<FoodTrackerContext>>()))
            {
                if (context == null || context.Foods == null)
                {
                    throw new ArgumentNullException("Null FoodTrackerContext");
                }

                // Look for any foods.
                if (context.Foods.Any())
                {
                    return;     // DB has been seeded
                }

                context.Foods.AddRange(
                    new Food
                    {
                        Name = "Spaghetti",
                        FoodGroup = FoodGroups.Grains,
                        Remaining = 500,
                        Unit = "g",
                        PurchaseDate = DateTime.Parse("2024-9-16"),
                        OpenDate = DateTime.Parse("2024-9-23"),
                        ExpirationDate = DateTime.Parse("2027-6-30"),
                        MealPlan = "10/19: meat sauce spaghetti",
                        RecipeLink = "https://www.inspiredtaste.net/38940/spaghetti-with-meat-sauce-recipe/"
                    },
                    new Food
                    {
                        Name = "Pears",
                        FoodGroup = FoodGroups.Fruits,
                        Remaining = 5,
                        PurchaseDate = DateTime.Parse("2024-10-10"),
                        OpenDate = DateTime.Parse("2024-10-12"),
                        ExpirationDate = DateTime.Parse("2024-10-18"),
                    },
                    new Food
                    {
                        Name = "Half & Half",
                        FoodGroup = FoodGroups.Dairy,
                        Remaining = 32,
                        Unit = "oz",
                        PurchaseDate = DateTime.Parse("2024-10-3"),
                        OpenDate = DateTime.Parse("2024-10-4"),
                        ExpirationDate = DateTime.Parse("2025-3-31"),
                    },
                    new Food
                    {
                        Name = "Frozen Shrimp",
                        FoodGroup = FoodGroups.Protein,
                        Remaining = 200,
                        Unit = "g",
                        PurchaseDate = DateTime.Parse("2024-8-5"),
                        OpenDate = DateTime.Parse("2024-8-7"),
                        ExpirationDate = DateTime.Parse("2025-2-28"),
                        MealPlan = "olive spaghetti with shrimp",
                    },
                    new Food
                    {
                        Name = "Potatoes",
                        FoodGroup = FoodGroups.Vegetables,
                        Remaining = 900,
                        Unit = "g",
                        PurchaseDate = DateTime.Parse("2024-8-23"),
                        OpenDate = DateTime.Parse("2024-8-29"),
                        ExpirationDate = DateTime.Parse("2024-12-31"),
                        MealPlan = "10/18: curry and rice",
                        RecipeLink = "https://www.japanesecooking101.com/curry-and-rice-recipe/"
                    },
                    new Food
                    {
                        Name = "Beef",
                        FoodGroup = FoodGroups.Protein,
                        Remaining = 300,
                        Unit = "g",
                        PurchaseDate = DateTime.Parse("2024-10-10"),
                        ExpirationDate = DateTime.Parse("2025-10-16"),
                        MealPlan = "10/15: steak",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
