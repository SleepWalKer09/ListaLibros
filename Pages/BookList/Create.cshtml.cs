using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaLibros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaLibros.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public libro libro { get; set; }

        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.libro.AddAsync(libro);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
