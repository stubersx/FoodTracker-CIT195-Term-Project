using System.ComponentModel.DataAnnotations;

namespace FoodTracker.Models
{
    public enum FoodGroups
    {
        Dairy,
        Fruits,
        Grains,
        Protein,
        Vegetables
    }

    public class Food
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Food Name")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Food Group")]
        public FoodGroups FoodGroup { get; set; }

        [Required]
        [Range(0, 10000)]
        public decimal Remaining { get; set; }

        [StringLength (10)]
        public string? Unit { get; set; } = string.Empty;

        [Display(Name = "Date Purchased")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        [Display(Name = "Date Opened")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OpenDate { get; set; }

        [Required]
        [Display(Name = "Date Expired")]
        [DisplayFormat(DataFormatString = "{0: MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Meal Plan")]
        [StringLength(500)]
        public string? MealPlan { get; set; } = string.Empty;

        [Display(Name = "Recipe Link")]
        [StringLength(500)]
        public string? RecipeLink { get; set; } = string.Empty;
    }
}
