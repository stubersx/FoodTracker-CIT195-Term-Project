using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodTracker.Models;

namespace FoodTracker.Data
{
    public class FoodTrackerContext : DbContext
    {
        public FoodTrackerContext (DbContextOptions<FoodTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<FoodTracker.Models.Food> Foods { get; set; } = default!;
    }
}
