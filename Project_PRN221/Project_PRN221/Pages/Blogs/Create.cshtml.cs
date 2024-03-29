﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_PRN221.Models;
using Project_PRN221.Data;

namespace Project_PRN221.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly BakeryCakeContext _context;

        public CreateModel(BakeryCakeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CreateBy"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Blogs == null || Blog == null)
            {
                return Page();
            }

            _context.Blogs.Add(Blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
