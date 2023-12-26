using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;
using Project3.ViewModels;
using X.PagedList;

namespace Project3.Controllers
{
    public class ProductController : Controller
    {
        private readonly Sem3DBContext _context;

        public ProductController(Sem3DBContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(int? page)
        {
            int pageLimit = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var pro = await _context.Products.OrderBy(c => c.ProductId).ToPagedListAsync(pageNumber, pageLimit);

            //if (!String.IsNullOrEmpty(name))
            //{
            //    pro = await _context.Products.Where(c => c.ProductName.Contains(name)).OrderBy(c => c.ProductId).ToPagedListAsync(pageNumber, pageLimit);
            //}

            return View(pro);
        }
        public async Task<IActionResult> Medical(int? page)
        {
            int pageLimit = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var pro = await _context.Products.Where(c => c.Category.CategoryType == "Medical").OrderBy(c => c.ProductId).ToPagedListAsync(pageNumber, pageLimit);

            return View(pro);
        }
        public async Task<IActionResult> Science(int? page)
        {
            int pageLimit = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var pro = await _context.Products.Where(c => c.Category.CategoryType == "Science").OrderBy(c => c.ProductId).ToPagedListAsync(pageNumber, pageLimit);

            return View(pro);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(m => m.ProductId == id);
            //var cart = await _context.Carts.
            var Cart_Pro = new Cart_Pro
            {
                MPro = product,
                //MCart = cart
            };
            if (product == null)
            {
                return NotFound();
            }
            ViewData["pro_id"] = id;
            return View(Cart_Pro);
        }


        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
