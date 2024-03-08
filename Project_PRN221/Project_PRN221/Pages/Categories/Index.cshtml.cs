using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Models;
using Project_PRN221.Data;

namespace Project_PRN221.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly BakeryCakeContext _context;

        public IndexModel(BakeryCakeContext context)
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
