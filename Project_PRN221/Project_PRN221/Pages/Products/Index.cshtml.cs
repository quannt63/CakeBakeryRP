using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectPRN221.Models;

namespace ProjectPRN221.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ProjectPRN221.Models.BakeryCakeContext _context;

        public IndexModel(ProjectPRN221.Models.BakeryCakeContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get; set; } = default!;

        public PaginatedList<Product> Products { get; set; }

        public async Task OnGetAsync(string sortOrder,
                                            string currentFilter,
                                            string searchString,
                                            int? pageNumber,
                                            int? categoryId,
                                            decimal? minPrice,
                                            decimal? maxPrice)
        {
            var categoryList = await _context.Categories.ToListAsync();
            ViewData["CategoryList"] = categoryList;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "Name" ? "name_desc" : "Name";
            ViewData["UnitPriceSortParm"] = sortOrder == "UnitPrice" ? "unitprice_desc" : "UnitPrice";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentCategoryId"] = categoryId;

            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;

            var products = from p in _context.Products.Include(p => p.Category)
                           select p;
            int totalCount = await products.CountAsync();
            ViewData["TotalCount"] = totalCount;

            // Lọc theo tên sản phẩm
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            // Lọc theo giá sản phẩm
            if (minPrice != null && maxPrice != null)
            {
                products = products.Where(p => p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice);
            }

            // Lọc theo CategoryID 
            if (categoryId != null)
            {
                products = products.Where(p => p.CategoryId == categoryId);
                ViewData["CurrentCategory"] = categoryId;
            }
            switch (sortOrder)
            {
                case "id_desc":
                    products = products.OrderByDescending(p => p.ProductId);
                    break;
                case "Name":
                    products = products.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(p => p.Name);
                    break;
                case "UnitPrice":
                    products = products.OrderBy(p => p.UnitPrice);
                    break;
                case "unitprice_desc":
                    products = products.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    products = products.OrderBy(p => p.ProductId);
                    break;
            }

            int pageSize = 9;
            Products = await PaginatedList<Product>.CreateAsync(products.AsNoTracking(), pageNumber ?? 1, pageSize);
        }
    }
}

