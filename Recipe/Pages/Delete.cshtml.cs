using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Recipe.Data;
using Recipe.Models;

namespace Recipe.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Recipe.Data.ApplicationDbContext _context;

        public DeleteModel(Recipe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Recipes Recipes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipes = await _context.Recipes.FirstOrDefaultAsync(m => m.ID == id);

            if (Recipes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipes = await _context.Recipes.FindAsync(id);

            if (Recipes != null)
            {
                _context.Recipes.Remove(Recipes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
