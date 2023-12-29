using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Data;
using Project3.Models;

namespace Project3.Controllers
{
    public class OrderController : Controller
    {
        private readonly Sem3DBContext _context;

        public OrderController(Sem3DBContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var sem3DBContext = _context.Orders.Include(o => o.Account).Include(o => o.Product);
            return View(await sem3DBContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrdersId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Order/Create
        public IActionResult Create(Cart cart)
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
            //List<Cart> list = new List<Cart>();
            //list.Add(new Cart() { Quantity = sem3DBContext.Quantity });
            //ViewData["cart"] = list;
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrdersId,ReceiverName,ReceiverPhone,ReceiverAddress,Note,Quantity,TotalPrice,OrderDate,ProductId,AccountId")] Orders orders, [Bind("OrderDetailId,OrderDetailStatus,OrdersId")] OrderDetail orderDetail)
        {
            //var sem3DBContext = _context.Carts.Include(c => c.Account).Include(p => p.Product).Where(c => c.AccountId == HttpContext.Session.GetInt32("LoginId"));

            if (ModelState.IsValid)
            {
                //foreach (var item in sem3DBContext)
                //{
                orders.OrderDate = DateTime.Now;
                //orders.ProductId = item.ProductId;
                orders.AccountId = HttpContext.Session.GetInt32("LoginId");
                //orders.Quantity = item.Quantity;
                //orders.TotalPrice= item.TotalPrice;
                _context.Add(orders);

                await _context.SaveChangesAsync();
                //}
                var a = true;
                do
                {
                    var sem3DBContext = _context.Carts.Include(c => c.Account).Include(p => p.Product).Where(c => c.AccountId == HttpContext.Session.GetInt32("LoginId"));

                    if (sem3DBContext != null)
                    {
                        foreach (var item in sem3DBContext)
                        {
                            
                            orderDetail.OrderDetailStatus = item.Product.ProductName;
                            orderDetail.OrdersId = orders.OrdersId;
                            _context.OrderDetails.Add(orderDetail);
                            await _context.SaveChangesAsync();

                            _context.Carts.Remove(_context.Carts.Find(item.CartId));
                            //_context.SaveChanges();
                            await _context.SaveChangesAsync();
                            break;
                        }
                    }
                    else
                    {
                        a = false;
                    }

                } while (a == true);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address", orders.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            return View(orders);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address", orders.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            return View(orders);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdersId,ReceiverName,ReceiverPhone,ReceiverAddress,Note,Quantity,TotalPrice,OrderDate,ProductId,AccountId")] Orders orders)
        {
            if (id != orders.OrdersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrdersId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Address", orders.AccountId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "Description", orders.ProductId);
            return View(orders);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Account)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrdersId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'Sem3DBContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrdersId == id)).GetValueOrDefault();
        }
    }
}
