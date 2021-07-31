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
    public class IndexModel : PageModel
    {
        private readonly Recipe.Data.ApplicationDbContext _context;

        public IndexModel(Recipe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipes> Recipes { get;set; }

        public async Task OnGetAsync()
        {
            Recipes = await _context.Recipes.ToListAsync();
        }
    }
}
