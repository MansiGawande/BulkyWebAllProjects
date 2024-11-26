using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db; // new filed created
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
             }
        }
        public IActionResult OnPost() {

            Category? obj = _db.Categories.Find(Category.Id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Categories.Remove(obj); // pass obj of Category type.
                _db.SaveChanges(); // go to db save changes
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index"); // after add go view all category
                   }
            
        }
    }

