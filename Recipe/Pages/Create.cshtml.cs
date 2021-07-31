using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipe.Data;
using Recipe.Models;

namespace Recipe.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Recipe.Data.ApplicationDbContext _context;

        public CreateModel(Recipe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Recipes Recipes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Recipes.Add(Recipes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
