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

namespace Project3.Controllers
{
    public class CartController : Controller
    {
        private readonly Sem3DBContext _context;

        public CartController(Sem3DBContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var sem3DBContext = _context.Carts.Include(c => c.Account).Include(p => p.Product);
            return View(await sem3DBContext.ToListAsync());
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,Quantity,TotalPrice,ProductId,AccountId")] Cart cart)
        {
            //cart.TotalPrice = cart.Product.GetType * cart.Quantity;
            //cart = cart_Pro;
            if (ModelState.IsValid)
            {
                var check = await _context.Carts.Where(a => a.ProductId == cart.ProductId && a.AccountId == cart.AccountId).FirstOrDefaultAsync();
                if (check != null)
                {
                    check.Quantity += cart.Quantity;
                    _context.Update(check);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }


            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "AccountId", cart.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", cart.ProductId);
            return RedirectToAction(nameof(Index));
        }

        // GET: Cart/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Carts == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Carts.FindAsync(id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address", cart.AccountId);
        //    ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", cart.ProductId);
        //    return View(cart);
        //}

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int CartId, [Bind("CartId,Quantity,TotalPrice,ProductId,AccountId")] Cart cart)
        {
            if (CartId != cart.CartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address", cart.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", cart.ProductId);
            return View(cart);
        }
        public IActionResult Delete(int id)
        {
            //TempData["Message"] = "";
            _context.Remove(_context.Carts.Find(id));
            _context.SaveChanges();
            //TempData["Message"] = "Cart deletion successful";
            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return (_context.Carts?.Any(e => e.CartId == id)).GetValueOrDefault();
        }
    }
}
