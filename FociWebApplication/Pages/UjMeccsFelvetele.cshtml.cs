using FociWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FociWebApplication.Pages
{
    public class UjMeccsFelveteleModel : PageModel
    {
        [BindProperty]
        public Match UjMeccs { get; set; }

        public List<Match> MeccsekListaja { get; set; }

        private readonly FociDbContext _db;
        public UjMeccsFelveteleModel(FociDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            MeccsekListaja = _db.Meccsek.ToList();
        }

        public IActionResult OnPost()
        {
            _db.Meccsek.Add(UjMeccs);
            _db.SaveChanges();
            return Page();

        }
    }
}
