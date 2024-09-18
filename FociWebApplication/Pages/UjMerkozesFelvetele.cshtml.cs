using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FociWebApplication.Models;

namespace FociWebApplication.Pages
{
    public class UjMerkozesFelveteleModel : PageModel
    {
        private readonly FociWebApplication.Models.FociDbContext _context;

        public UjMerkozesFelveteleModel(FociWebApplication.Models.FociDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Meccsek.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
