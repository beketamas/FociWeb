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
    public class MerkozesListaModel : PageModel
    {
        private readonly FociWebApplication.Models.FociDbContext _context;

        public MerkozesListaModel(FociWebApplication.Models.FociDbContext context)
        {
            _context = context;
        }

        public IList<Meccs> Match { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Match = await _context.Meccsek.ToListAsync();
        }
    }
}
