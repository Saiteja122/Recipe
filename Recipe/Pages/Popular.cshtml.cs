using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Recipe.Pages
{
    public class PopularModel : PageModel
    {
        private readonly ILogger<PopularModel> _logger;

        public PopularModel(ILogger<PopularModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
