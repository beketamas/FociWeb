using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FociWebApplication.Models;

namespace FociWebApplication.Pages
{
    public class MerkozesDeleteModel : PageModel
    {
        private readonly FociWebApplication.Models.FociDbContext _context;

        public MerkozesDeleteModel(FociWebApplication.Models.FociDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Match Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Meccsek.FirstOrDefaultAsync(m => m.Id == id);

            if (match == null)
            {
                return NotFound();
            }
            else
            {
                Match = match;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Meccsek.FindAsync(id);
            if (match != null)
            {
                Match = match;
                _context.Meccsek.Remove(Match);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
