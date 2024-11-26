using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Model;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db; // new filed created
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet() // OnGet method/handlar without On error
        {
            CategoryList = _db.Categories.ToList();// get data from db var add into CategegoryList
        }
    }
}
