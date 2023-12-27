
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project3.Controllers;
using Project3.Data;
using Project3.Models;

namespace Project3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailsAdminController : Base1Controller
    {
        private readonly Sem3DBContext _contextOD;

        public OrderDetailsAdminController(Sem3DBContext context)
        {
            _contextOD = context;
        }

        // GET: Admin/OrderDetailsAdmin
        public async Task<IActionResult> Index()
        {
            var sem3DBContext = _contextOD.OrderDetails.Include(o => o.Orders);
            return View(await sem3DBContext.ToListAsync());
        }

        // GET: Admin/OrderDetailsAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _contextOD.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _contextOD.OrderDetails
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(o => o.OrderDetailId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // GET: Admin/OrderDetailsAdmin/Create

        // GET: Admin/OrderDetailsAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _contextOD.OrderDetails == null)
            {
                return NotFound();
            }

            var orderDetail = await _contextOD.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            ViewData["OrdersId"] = new SelectList(_contextOD.Orders, "OrdersId", "OrdersId", orderDetail.OrdersId);
            return View(orderDetail);
        }

        // POST: Admin/OrderDetailsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("OrderDetailId,OrderDetailStatus,OrdersId")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _contextOD.Update(orderDetail);
                    await _contextOD.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailExists(orderDetail.OrderDetailId))
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
            ViewData["OrdersId"] = new SelectList(_contextOD.Orders, "OrdersId", "OrdersId", orderDetail.OrdersId);
            return View(orderDetail);
        }

        // GET: Admin/OrderDetailsAdmin/Delete/5

        private bool OrderDetailExists(int? id)
        {
          return (_contextOD.OrderDetails?.Any(o => o.OrderDetailId == id)).GetValueOrDefault();
        }
    }
}
