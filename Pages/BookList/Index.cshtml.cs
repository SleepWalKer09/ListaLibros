using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaLibros.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ListaLibros.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<libro> libros { get; set; }

        public async Task OnGet()
        {
            libros = await _db.libro.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var libro = await _db.libro.FindAsync(id);
            if(libro == null)
            {
                return NotFound();
            }
            _db.libro.Remove(libro);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
