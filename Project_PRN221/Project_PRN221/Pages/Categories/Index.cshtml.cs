using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectPRN221.Models;

namespace ProjectPRN221.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ProjectPRN221.Models.BakeryCakeContext _context;

        public IndexModel(ProjectPRN221.Models.BakeryCakeContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Category = await _context.Categories.Include(c => c.Products).ToListAsync();
            }
        }
    }
}
