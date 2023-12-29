using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;
using Project3.ViewModels;

namespace Project3.Controllers
{
    public class CartController : BaseController
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
            int c = 0;
            Int32 a = 0;
            foreach (var item in sem3DBContext)
            {
                if (item.AccountId == HttpContext.Session.GetInt32("LoginId"))
                {

                    c++;
                    ViewData["Number_Pro"] = c;
                    a += (Int32)item.TotalPrice;
                    ViewData["Total_Cart"] = a.ToString("#,##0 $");


                }
            }
            return View(await sem3DBContext.ToListAsync());
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartId,Quantity,TotalPrice,ProductId,AccountId,")] Cart cart)
        {
            cart.TotalPrice *= cart.Quantity;
            if (cart.Quantity < 1)
            {

                cart.Quantity = 1;
            }
            if (ModelState.IsValid)
            {
                var check = await _context.Carts.Where(a => a.ProductId == cart.ProductId && a.AccountId == cart.AccountId).FirstOrDefaultAsync();

                //double TotalPrice = (double)(cart.Product.Price * (double)cart.Quantity);


                if (check != null)
                {
                    check.Quantity += cart.Quantity;
                    _context.Update(check);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }


            }
            return RedirectToAction(nameof(Index));
        }

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
                    if (cart.Quantity < 1)
                    {
                        cart.Quantity = 1;
                    }

                    cart.TotalPrice *= cart.Quantity;
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
