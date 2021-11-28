using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaLibros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListaLibros.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public libro libro { get; set; }

        public async Task OnGet(int id)
        {
            libro = await _db.libro.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.libro.FindAsync(libro.Id);
                BookFromDb.Name = libro.Name;
                BookFromDb.ISBN = libro.ISBN;
                BookFromDb.Author = libro.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}
