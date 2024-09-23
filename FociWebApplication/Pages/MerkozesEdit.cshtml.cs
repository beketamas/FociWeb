using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FociWebApplication.Models;

namespace FociWebApplication.Pages
{
    public class MerkozesEditModel : PageModel
    {
        private readonly FociWebApplication.Models.FociDbContext _context;

        public MerkozesEditModel(FociWebApplication.Models.FociDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Meccs Match { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match =  await _context.Meccsek.FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }
            Match = match;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(Match.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MatchExists(int id)
        {
            return _context.Meccsek.Any(e => e.Id == id);
        }
    }
}
