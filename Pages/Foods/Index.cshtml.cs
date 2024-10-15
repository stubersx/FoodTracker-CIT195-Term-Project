using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodTracker.Data;
using FoodTracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace FoodTracker.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly FoodTracker.Data.FoodTrackerContext _context;

        public IndexModel(FoodTracker.Data.FoodTrackerContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public string GroupSort { get; set; }
        public string BuySort { get; set; }
        public string OpenSort { get; set; }
        public string ExpireSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            GroupSort = String.IsNullOrEmpty(sortOrder) ? "group_desc" : "";
            BuySort = sortOrder == "Buy" ? "buy_desc" : "Buy";
            OpenSort = sortOrder == "Open" ? "open_desc" : "Open";
            ExpireSort = sortOrder == "Expire" ? "expire_desc" : "Expire";

            IQueryable<Food> foodsIQ = from f in _context.Foods
                                             select f;
            
            if (!String.IsNullOrEmpty(SearchString))
            {
                foodsIQ = foodsIQ.Where(f => f.Name.Contains(SearchString) || f.MealPlan.Contains(SearchString));
            }
            
            switch (sortOrder)
            {
                case "group_desc":
                    foodsIQ = foodsIQ.OrderByDescending(f => f.FoodGroup);
                    break;
                case "Buy":
                    foodsIQ = foodsIQ.OrderBy(f => f.PurchaseDate);
                    break;
                case "buy_desc":
                    foodsIQ = foodsIQ.OrderByDescending(f => f.PurchaseDate);
                    break;
                case "Open":
                    foodsIQ = foodsIQ.OrderBy(f => f.OpenDate);
                    break;
                case "open_desc":
                    foodsIQ = foodsIQ.OrderByDescending(f => f.OpenDate);
                    break;
                case "Expire":
                    foodsIQ = foodsIQ.OrderBy(f => f.ExpirationDate);
                    break;
                case "expire_desc":
                    foodsIQ = foodsIQ.OrderByDescending(f => f.ExpirationDate);
                    break;
                default:
                    foodsIQ = foodsIQ.OrderBy(f => f.FoodGroup);
                    break;
            }

            Food = await foodsIQ.AsNoTracking().ToListAsync();
        }
    }
}
