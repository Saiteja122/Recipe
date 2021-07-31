using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Recipe.Data;
using Recipe.Models;

namespace Recipe.Pages
{
    public class EditModel : PageModel
    {
        private readonly Recipe.Data.ApplicationDbContext _context;

        public EditModel(Recipe.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Recipes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(Recipes.ID))
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

        private bool RecipesExists(int id)
        {
            return _context.Recipes.Any(e => e.ID == id);
        }
    }
}
