using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project_PRN221.Models;
using Project_PRN221.Data;

namespace Project_PRN221.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private readonly BakeryCakeContext _context;

        public IndexModel(BakeryCakeContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Blogs != null)
            {
                Blog = await _context.Blogs
                .Include(b => b.CreateByNavigation).ToListAsync();

            }
            var totalComment = _context.Comments
                .GroupBy(b => b.BlogId)
                .Select(g => new { BlogID = g.Key, Count = g.Count() })
                .ToList();

            ViewData["TotalComment"] = totalComment;
        }
    }
}
