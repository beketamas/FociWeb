using FociWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace FociWebApplication.Pages
{
    public class AdatokFeltolteseFajlbolModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly FociDbContext _context;


        public AdatokFeltolteseFajlbolModel(IWebHostEnvironment env, FociDbContext context)
        {
            _env = env;
            _context = context;
        }


        [BindProperty]
        public IFormFile Feltoltes { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (Feltoltes == null || Feltoltes.Length == 0)
            {
                ModelState.AddModelError("Feltoltes", "Adj meg egy állományt!");
                return Page();
            }



            var UploadDirPath =Path.Combine(_env.ContentRootPath,"uploads");
            var UploadFilePath = Path.Combine(UploadDirPath,Feltoltes.FileName);

            using(var stream=new FileStream(UploadFilePath, FileMode.Create))
            {
                await Feltoltes.CopyToAsync(stream);   
            }

            StreamReader sr = new StreamReader(UploadFilePath);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var elemek = sr.ReadLine().Split();

                Meccs ujMeccs = new(elemek);
                _context.Meccsek.Add(ujMeccs);
            }

            sr.Close();
            _context.SaveChanges();
            //System.IO.File.Delete(UploadFilePath);
            return Page();
        }
    }
}
