using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodTracker.Data;
using FoodTracker.Models;

namespace FoodTracker.Pages.Foods
{
    public class DetailsModel : PageModel
    {
        private readonly FoodTracker.Data.FoodTrackerContext _context;

        public DetailsModel(FoodTracker.Data.FoodTrackerContext context)
        {
            _context = context;
        }

        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FirstOrDefaultAsync(m => m.Id == id);
            if (food == null)
            {
                return NotFound();
            }
            else
            {
                Food = food;
            }
            return Page();
        }
    }
}
