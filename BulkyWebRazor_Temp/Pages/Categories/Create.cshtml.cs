using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        //BindingAddress an attribute bindProperty fior adding Category property add when post handler call do not ned to pass paramter 
        private readonly ApplicationDbContext _db; // new filed created
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
