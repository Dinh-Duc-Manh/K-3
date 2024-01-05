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
        public async Task<IActionResult> Index(string? id, string? name, int? page)
        {
            int pageLimit = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

           
            if (id == "Medical")
            {
                var product = await _context.Products.Include(c => c.Category).Where(c => c.Category.CategoryType == "Medical").OrderByDescending(p => p.ProductId).ToPagedListAsync(pageNumber, pageLimit);
                TempData["active"] = "";
                TempData["active1"] = "active";
                TempData["active2"] = "";
                if (!String.IsNullOrEmpty(name))
                {
                    product = await _context.Products.Where(a => a.ProductName.Contains(name)).OrderBy(a => a.ProductId).ToPagedListAsync(pageNumber, pageLimit);
                    TempData["active"] = "active";
                    TempData["active1"] = "";
                }
                return View(product);
            }
            else if (id == "Science")
            {
                var product = await _context.Products.Include(c => c.Category).Where(c => c.Category.CategoryType == "Science").OrderByDescending(p => p.ProductId).ToPagedListAsync(pageNumber, pageLimit);
                TempData["active"] = "";
                TempData["active1"] = "";
                TempData["active2"] = "active";
                if (!String.IsNullOrEmpty(name))
                {
                    product = await _context.Products.Where(a => a.ProductName.Contains(name)).OrderBy(a => a.ProductId).ToPagedListAsync(pageNumber, pageLimit);
                    TempData["active"] = "active";
                    TempData["active2"] = "";
                }
                return View(product);
            }
            else
            {

                var product = await _context.Products.Include(c => c.Category).OrderByDescending(p => p.ProductId).ToPagedListAsync(pageNumber, pageLimit);

                TempData["active"] = "active";
                TempData["active1"] = "";
                TempData["active2"] = "";
                if (!String.IsNullOrEmpty(name))
                {
                    product = await _context.Products.Where(a => a.ProductName.Contains(name)).OrderBy(a => a.ProductId).ToPagedListAsync(pageNumber, pageLimit);
                }
                return View(product);
            }
        }
        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(c => c.Category).FirstOrDefaultAsync(p => p.ProductId == id);
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
            Int32 a = 1;
            var pro = _context.Products.Include(c => c.Category).Where(c => c.Category == product.Category);
            List<Product> list = new List<Product>();
            foreach (var p in pro)
            {
                if (product.ProductId != p.ProductId)
                {
                    list.Add(new Product() { ProductId = p.ProductId, ProductName = p.ProductName, ProductImage = p.ProductImage, ProductStatus = p.ProductStatus, Price = p.Price });
                    a++;
                }
                if(a >= 5)
                {
                    break;
                }
            }

            ViewData["pro"] = list;

            ViewData["pro_id"] = id;
            ViewData["price"] = product.Price;
            return View(Cart_Pro);
        }
    }
}
