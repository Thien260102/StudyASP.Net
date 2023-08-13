using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyASP.Data;
using StudyASP.Model;

namespace StudyASP.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
				// Validation will display below Name input field
				//ModelState.AddModelError("Category.Name", "The DisplayOrder must be different from Name.");

				// Validation will display below DisplayOrder input field
				ModelState.AddModelError("Category.DisplayOrder", "The DisplayOrder must be different from Name.");
            }

            if (ModelState.IsValid)
            {
				await _db.Category.AddAsync(Category);
				await _db.SaveChangesAsync();

				return RedirectToPage("Index");
			}

            return Page();
        }
    }
}
