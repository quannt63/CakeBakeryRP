﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectPRN221.Models;

namespace ProjectPRN221.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectPRN221.Models.BakeryCakeContext _context;

        public DetailsModel(ProjectPRN221.Models.BakeryCakeContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            var productsWithSameCategory = await _context.Products
               .Include(p => p.Category)
               .Where(p => p.Category.CategoryId == product.Category.CategoryId && p.ProductId != id)
               .ToListAsync();
            ViewData["ProductsWithSameCategory"] = productsWithSameCategory;

            return Page();
        }
    }
}